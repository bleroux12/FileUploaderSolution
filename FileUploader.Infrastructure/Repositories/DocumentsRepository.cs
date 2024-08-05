using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using FileUploader.Infrastructure.DbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Infrastructure.Repositories
{   
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly FileUploadDbContext _fileDb;
        private readonly IHostingEnvironment _environment;

        public DocumentsRepository(FileUploadDbContext fileDb, IHostingEnvironment environment)
        {
            _fileDb = fileDb;
            _environment = environment;
        }

        public async Task<FileDocument> GetFileDocumentByFileIDAndDocumentID(Guid fileID, Guid documentID)
        {
            var existingFileDocument = await _fileDb.FileDocuments.FirstOrDefaultAsync(fd =>
            fd.FileID == fileID && fd.DocumentID == documentID && fd.IsDeleted == false);
            if (existingFileDocument != null)
            {
                return existingFileDocument;
            }

            return null;
        }

        public async Task<bool> DeleteDocument(Guid documentID, Guid fileID)
        {
            var exisitingDocument = await _fileDb.Documents.FirstOrDefaultAsync(d => d.ID == documentID
            && d.IsDeleted == false);
            var existingFileDocument = await _fileDb.FileDocuments.FirstOrDefaultAsync(fd =>
            fd.FileID == fileID && fd.DocumentID == documentID && fd.IsDeleted == false);
            if (exisitingDocument != null && existingFileDocument != null 
                && existingFileDocument.DocumentStatusCode != "SNT")
            {
                exisitingDocument.IsDeleted = true;
                exisitingDocument.ModifiedDateTime = DateTime.Now;

                existingFileDocument.IsDeleted = true;
                existingFileDocument.ModifiedDateTime = DateTime.Now;

                await _fileDb.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<DocumentType>> GetAllDocumentTypes()
        {
            return await _fileDb.DocumentTypes.Where(dt => dt.IsDeleted == false).ToListAsync();
        }

        public async Task<Core.Domain.Entities.Document> GetDocumentByDocumentID(Guid documentID)
        {
            return await _fileDb.Documents.FirstOrDefaultAsync(d => d.ID == documentID 
            && d.IsDeleted == false);
        }

        public async Task<IEnumerable<DocumentDTO>> GetDocumentsByUploadFileID(Guid fileID)
        {
            return await _fileDb.FileDocuments.Where(fd => fd.FileID == fileID && fd.IsDeleted == false)
                .Select(fd => new DocumentDTO
                {
                    DocumentID = fd.Document.ID,
                    DocumentTypeCode = fd.Document.DocumentTypeCode,
                    DocumentTypeDescription = fd.Document.DocumentType.Description,
                    DocumentFileName = fd.Document.DocumentFileName,
                    OutputFileName = fd.Document.OutputFileName,
                    CreatedDateTime = fd.Document.CreatedDateTime,
                    FileExtension = fd.Document.FileExtension,
                    FileDocuments = fd.Document.FileDocuments,
                })
                .ToListAsync();
        }

        public async Task UploadDocument(AttachDocumentResponse model)
        {
            if (model.File != null && model.File.Length > 0)
            {
                var uploads = Path.Combine(@"c:\DocumentStore\", DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var newFileName = Guid.NewGuid().ToString();
                var filePath = Path.Combine(uploads, newFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }

                //Create Document Record
                var document = new Core.Domain.Entities.Document
                {
                    DocumentFileName = filePath,
                    OutputFileName = model.File.FileName,
                    FileExtension = Path.GetExtension(model.File.FileName),
                    DocumentTypeCode = model.DocumentTypeCode,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    IsDeleted = false
                };

                _fileDb.Documents.Add(document);
                await _fileDb.SaveChangesAsync();

                //Create FileDocument Record
                var fileDocument = new FileDocument
                {
                    FileID = model.FileID,
                    DocumentID = document.ID,
                    DocumentStatusCode = "ATT",
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    IsDeleted = false
                };

                _fileDb.FileDocuments.Add(fileDocument);
                await _fileDb.SaveChangesAsync();
            }
        }
    }
}
