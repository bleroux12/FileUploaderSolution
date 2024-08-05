using FileUploader.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Infrastructure.DbContext
{
    public class LogDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
            
        }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ExceptionLog>().ToTable("tblEventLog").Property(e => e.ID)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<ExceptionLog>().Property(e => e.CreatedDateTime).HasDefaultValueSql("getdate()");
        }
    }
}
