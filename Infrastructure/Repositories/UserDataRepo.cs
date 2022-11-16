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
    internal sealed class UserDataRepo : GenericRepo<UserData>, IUserDataRepo
    {
        private readonly BusinessContext _context;

        public UserDataRepo(BusinessContext context) : base(context)
        {
            _context = context;
        }

        public UserData GetByEmail(string email) => _context.UserData.FirstOrDefault(u => u.Email == email);
    }
}
