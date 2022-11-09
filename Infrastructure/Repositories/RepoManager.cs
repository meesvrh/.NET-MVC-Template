using Domain.Services;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class RepoManager : IRepoManager
    {
        private readonly BusinessContext _context;

        // private IUserRepo _userRepo;

        public RepoManager(BusinessContext context)
        {
            _context = context;
        }

        // public IUserRepo User => _userRepo ??= new UserRepo(_context);

        public void Save() => _context.SaveChanges();

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
