using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.Helpers;
using FileUploader.Core.DTO;
using FileUploader.Infrastructure.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Infrastructure.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
    {
        private readonly FileUploadDbContext _db;

        public UploadFileRepository(FileUploadDbContext db)
        {
            _db = db;
        }

        public async Task<UploadFile> AddFile(UploadFile file)
        {
            await _db.AddAsync(file);
            await _db.SaveChangesAsync();
            return file;
        }

        public async Task<Response> DeleteUploadFile(Guid uploadFileID)
        {
            Response response = new Response();
            var existingFile = await _db.UploadFiles.FirstOrDefaultAsync(uf => uf.ID == uploadFileID
            && uf.IsDeleted == false);
            if (existingFile == null)
            {
                response.Type = "danger";
                response.Message = "Unable to delete file. File not found.";
                return response;
            }

            if (existingFile.FileStatusCode == "SNT")
            {
                response.Type = "danger";
                response.Message = "Unable to delete file. File has already been sent.";
                return response;
            }

            var fileDocuments = await _db.FileDocuments.Where(fd => fd.FileID == uploadFileID
            && fd.IsDeleted == false).ToListAsync();
            if (fileDocuments != null)
            {
                foreach (var fileDocument in fileDocuments)
                {
                    if (fileDocument.DocumentStatusCode == "SNT")
                    {
                        response.Type = "danger";
                        response.Message = "Unable to delete file. File has documents attached that have already been sent.";
                        return response;
                    }
                }
            }

            existingFile.IsDeleted = true;
            existingFile.ModifiedDateTime = DateTime.Now;

            await _db.SaveChangesAsync();

            response.Type = "success";
            response.Message = "File Deleted successfully.";
            return response;
        }

        public async Task<IEnumerable<UploadFile>> GetAllFiles()
        {
            return await _db.UploadFiles.Include(uf => uf.Client)
                .Where(uf => uf.IsDeleted == false).ToListAsync();
        }

        public async Task<PaginatedList<UploadFile>> GetPagedFilesAsync(int pageNumber, int pageSize)
        {
            var query = _db.UploadFiles.Include(uf => uf.Client).Where(uf => uf.IsDeleted == false)
                .AsQueryable();

            return await PaginatedList<UploadFile>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<UploadFile?> GetUploadFileByID(Guid uploadFileID)
        {
            return await _db.UploadFiles.Include(uf => uf.Client)
                .FirstOrDefaultAsync(uf => uf.ID == uploadFileID && uf.IsDeleted == false);
        }

        public async Task<UploadFile?> GetUploadFileByFilenumber(string fileNumber)
        {
            return await _db.UploadFiles.Include(uf => uf.Client)
                .FirstOrDefaultAsync(uf => uf.FileNumber == fileNumber && uf.IsDeleted == false);
        }

        public async Task<UploadFile?> UpdateUploadFile(UploadFile file)
        {
            var exisitingFile = await _db.UploadFiles.Include(uf => uf.Client)
                .FirstOrDefaultAsync(uf => uf.ID == file.ID);

            if (exisitingFile == null)
            {
                return file;
            }

            exisitingFile.FileNumber = file.FileNumber;
            exisitingFile.InvoiceNumber = file.InvoiceNumber;
            exisitingFile.InvoiceDate = file.InvoiceDate;
            exisitingFile.ClientID = file.ClientID;
            exisitingFile.ModifiedDateTime = DateTime.Now;

            await _db.SaveChangesAsync();
            return exisitingFile;
        }

        public async Task UpdateUploadFileDocumentCount(int count, Guid fileID)
        {
            var existingFile = await _db.UploadFiles.FirstOrDefaultAsync(uf => uf.ID == fileID
            && !uf.IsDeleted);
            if (existingFile != null)
            {
                if (count < 0 && existingFile.NumberOfDocs == 0)
                {

                }
                else
                {
                    existingFile.NumberOfDocs = existingFile.NumberOfDocs + count;
                    if ((existingFile.FileStatusCode != "QUE" && existingFile.FileStatusCode != "PND")
                        && count > 0)
                    {
                        existingFile.FileStatusCode = "PND";
                    }
                    else if (count < 0 && existingFile.NumberOfDocs == 0)
                    {
                        existingFile.FileStatusCode = "NEW";
                        existingFile.ModifiedDateTime = DateTime.Now;
                    }
                    await _db.SaveChangesAsync();
                }

            }
        }

        public async Task<UploadFileStatus> GetUploadFileStatus(string code)
        {
            return await _db.UploadFileStatuses.FirstOrDefaultAsync(ufs => ufs.Code == code
            && !ufs.IsDeleted);
        }

        public async Task<Response> SendFile(Guid fileID)
        {
            var existingFile = await _db.UploadFiles.FirstOrDefaultAsync(uf => uf.ID == fileID
            && !uf.IsDeleted);
            if (existingFile != null && existingFile.FileStatusCode != "SNT")
            {
                existingFile.FileStatusCode = "QUE";
                existingFile.ModifiedDateTime = DateTime.Now;
                await _db.SaveChangesAsync();
                return new Response
                {
                    Message = "File has been successfully queued for sending.",
                    Type = "success"
                };
            }
            else if (existingFile != null && existingFile.FileStatusCode == "SNT")
            {
                return new Response
                {
                    Message = "This file has already been sent.",
                    Type = "danger"
                };
            }
            return new Response
            {
                Message = "Unable to send file.",
                Type = "danger"
            };
        }

        public async Task AddEvent(Guid fileID, string EventDescription, Guid? userID, string? username)
        {
            Event e = new Event
            {
                FileID = fileID,
                EventDescription = EventDescription + username ?? "",
                UserID = userID ?? Guid.Empty
            };
            await _db.Events.AddAsync(e);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEvents(Guid fileID)
        {
            var events = await _db.Events.Where(e => e.FileID == fileID && e.IsDeleted == false)
                .OrderByDescending(e => e.CreatedDateTime)
                .ToListAsync();

            return events;
        }        
    }
}
