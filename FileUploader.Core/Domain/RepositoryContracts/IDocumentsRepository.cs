using FileUploader.Core.Domain.Entities;
using FileUploader.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.RepositoryContracts
{
    public interface IDocumentsRepository
    {
        Task<IEnumerable<DocumentDTO>> GetDocumentsByUploadFileID(Guid fileID);
        Task<Document> GetDocumentByDocumentID(Guid documentID);
        Task UploadDocument(AttachDocumentResponse model);
        Task<bool> DeleteDocument(Guid DocumentID, Guid fileID);
        Task<IEnumerable<DocumentType>> GetAllDocumentTypes();
        Task<FileDocument> GetFileDocumentByFileIDAndDocumentID(Guid fileID, Guid documentID);
    }
}
