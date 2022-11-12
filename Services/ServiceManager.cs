using Domain.Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IRepoManager _repoManager;

        private IUserService _userService;

        public ServiceManager(IRepoManager repoManager)
        {
            _repoManager = repoManager;
        }

        public IUserService User => _userService ??= new UserService(_repoManager);
    }
}
