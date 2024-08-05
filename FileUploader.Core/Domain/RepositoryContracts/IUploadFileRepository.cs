using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.RepositoryContracts
{
    public interface IUploadFileRepository
    {
        /// <summary>
        /// Adds a uploadfile object to the database
        /// </summary>
        /// <param name="file">uploadfile object to add</param>
        /// <returns>The uploadfile object after adding it to the database</returns>
        Task<UploadFile> AddFile(UploadFile file);
        /// <summary>
        /// Returns all the uploadfiles in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UploadFile>> GetAllFiles();
        /// <summary>
        /// Returns all the uploadfiles in the database with pagination
        /// </summary>
        /// <returns></returns>
        Task<PaginatedList<UploadFile>> GetPagedFilesAsync(int pageNumber, int pageSize);
        /// <summary>
        /// Returns a uploadfile object based on the given client id
        /// </summary>
        /// <param name="uploadFileID">ID to be searched</param>
        /// <returns>A uploadfile based on the uploadFileID</returns>
        Task<UploadFile?> GetUploadFileByID(Guid uploadFileID);
        /// <summary>
        /// Returns a uploadfile object based on the given file number
        /// </summary>
        /// <param name="fileNumber">ID to be searched</param>
        /// <returns>A uploadfile based on the Filenumber</returns>
        Task<UploadFile?> GetUploadFileByFilenumber(string fileNumber);
        /// <summary>
        /// Removes a uploadfile by setting its IsDeleted to true based on the fileupload id
        /// </summary>
        /// <param name="uploadFileID">uploadFileID</param>
        /// <returns></returns>
        Task<Response> DeleteUploadFile(Guid uploadFileID);
        /// <summary>
        /// Updates uploadfile object based on the given uploadfile id
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The updated UploadFile object</returns>
        Task<UploadFile?> UpdateUploadFile(UploadFile file);
        /// <summary>
        /// Updates the document counte when a document is added or deleted
        /// </summary>
        /// <param name="count">1 or -1 to show if a file was added or deleted</param>
        /// <param name="fileID"></param>
        /// <returns></returns>
        Task UpdateUploadFileDocumentCount(int count, Guid fileID);
        Task<UploadFileStatus> GetUploadFileStatus(string uploadFileStatusCode);
        Task<Response> SendFile(Guid fileID);
        Task AddEvent(Guid fileID, string EventDescription, Guid? userID, string? username);
        Task<IEnumerable<Event>> GetAllEvents(Guid fileID);
    }
}
