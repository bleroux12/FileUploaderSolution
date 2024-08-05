using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await _authDbContext.Users.ToListAsync();

            var rootAdminUser = await _authDbContext.Users.FirstOrDefaultAsync(u => u.Email == "admin@fileuploder.com");

            if (rootAdminUser != null)
            {
                users.Remove(rootAdminUser);
            }

            return users;
        }
    }
}
