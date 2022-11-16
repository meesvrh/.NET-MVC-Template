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
    internal sealed class UserDataService : IUserDataService
    {
        private readonly IRepoManager _repoManager;

        public UserDataService(IRepoManager repoManager) => _repoManager = repoManager;

        public IEnumerable<UserData> GetAll() => _repoManager.UserData.GetAll();

        public UserData GetByEmail(string email) => _repoManager.UserData.GetByEmail(email);

        public async Task<ServiceResult> InsertAsync(UserData user)
        {
            try
            {
                _repoManager.UserData.Insert(user);
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
