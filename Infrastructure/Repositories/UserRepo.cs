using Domain.Models;
using Domain.Services;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal sealed class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly BusinessContext _context;

        public UserRepo(BusinessContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email == email);
    }
}
