using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileUploader.Core.Domain.Entities;

namespace FileUploader.Infrastructure.DbContext
{
    public class FileUploadDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FileUploadDbContext(DbContextOptions<FileUploadDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<UploadFile> UploadFiles { get; set; }
        public virtual DbSet<FileDocument> FileDocuments { get; set; }
        public virtual DbSet<UploadFileStatus> UploadFileStatuses { get; set; }
        public virtual DbSet<DocumentStatus> DocumentStatus { get; set; }
        public virtual DbSet<FileUploader.Core.Domain.Entities.Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UploadFileStatus>().ToTable("tblFileStatus");
            builder.Entity<UploadFile>().ToTable("tblFile").Property(f => f.ID)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<Client>().ToTable("tblClient").Property(c => c.ID)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<Event>().ToTable("tblEvent").Property(e => e.ID)
                .HasDefaultValueSql("newsequentialid()");

            builder.Entity<FileDocument>().ToTable("tblFileDocument")
                .HasKey(fd => new { fd.FileID, fd.DocumentID });
            builder.Entity<FileDocument>().HasOne(fd => fd.Document)
                .WithMany(d => d.FileDocuments)
                .HasForeignKey(fd => fd.DocumentID);
            builder.Entity<FileDocument>().HasOne(fd => fd.File)
                .WithMany(f => f.FileDocuments)
                .HasForeignKey(fd => fd.FileID);
            builder.Entity<FileDocument>().Property(fd => fd.ID)
                .HasDefaultValueSql("newsequentialid()");

            builder.Entity<DocumentStatus>().ToTable("tblDocumentStatus");


            builder.Entity<UploadFileStatus>().HasData(
                new UploadFileStatus
                {                    
                    Code = "New",
                    Description = "New File with no documents attached",
                    CreatedDateTime = DateTime.Now
                },
                new UploadFileStatus
                {
                    Code = "PND",
                    Description = "File has documents attached that are ready to be sent to FTP",
                    CreatedDateTime = DateTime.Now
                },
                new UploadFileStatus
                {
                    Code = "SNT",
                    Description = "All documents attached to the file have been sent to FTP",
                    CreatedDateTime = DateTime.Now
                },
                new UploadFileStatus
                {
                    Code = "Error",
                    Description = "File has an error and not all files attached have been sent to FTP",
                    CreatedDateTime = DateTime.Now
                }
                );
            builder.Entity<Client>().HasData(
                new Client
                {
                    ID = Guid.Parse("C307D31E-FB39-4B5B-824B-D38743485B0D"),
                    ClientName = "Client1",
                    FolderStructure = "Client1/Documents/{FileNumber}",
                    FileNameStructure = "/{DocumentType_DocumentFileName}",
                    FTPServer = "ftp.test.com",
                    FTPUsername = "Client1",
                    FTPPassword = "Client1",
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now
                },
                new Client
                {
                    ID = Guid.Parse("E5F946EA-18C4-4C18-AA6C-CC58F5266DE8"),
                    ClientName = "Client2",
                    FolderStructure = "Client1/Documents/{FileNumber}/{DocumentType_DocumentFileName}",
                    FileNameStructure = "/{DocumentType_DocumentFileName}",
                    FTPServer = "ftp.test.com",
                    FTPUsername = "Client2",
                    FTPPassword = "Client2",
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now
                }
                );
            builder.Entity<DocumentStatus>().HasData(
                new DocumentStatus
                {
                    Code = "ATT",
                    Description = "Document Attached",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                },
                new DocumentStatus
                {
                    Code = "SNT",
                    Description = "Document Sent",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                },
                new DocumentStatus
                {
                    Code = "ERR",
                    Description = "Document Error",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                }
                );

            builder.Entity<Document>().ToTable("tblDocument");
            builder.Entity<Document>().HasOne(d => d.DocumentType)
                .WithMany(dt => dt.Documents)
                .HasForeignKey(d => d.DocumentTypeCode);
            builder.Entity<Document>().Property(d => d.ID)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<DocumentType>().ToTable("tblDocumentType");

            builder.Entity<DocumentType>().HasData(
                new DocumentType
                {
                    Code = "INV",
                    Description = "Invoice",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                },
                new DocumentType
                {
                    Code = "MISC",
                    Description = "Miscellaneous Document",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                },
                new DocumentType
                {
                    Code = "SUPINV",
                    Description = "Supplier Invoice",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                },
                new DocumentType
                {
                    Code = "CNOTE",
                    Description = "CreditNote",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                },
                new DocumentType
                {
                    Code = "BLS",
                    Description = "Billing Sheet",
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                }
                );
        }
    }
}
