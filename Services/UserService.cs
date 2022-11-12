using Domain.Models;
using Domain.Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepoManager _repoManager;

        public UserService(IRepoManager repoManager) => _repoManager = repoManager;

        public User GetByEmail(string email) => _repoManager.User.GetByEmail(email);

        public async Task<ServiceResult> InsertAsync(User user)
        {
            try
            {
                _repoManager.User.Insert(user);
                await _repoManager.SaveAsync();

                return new ServiceResult() { Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResult() { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}
