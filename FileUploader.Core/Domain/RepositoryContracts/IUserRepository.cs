using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
