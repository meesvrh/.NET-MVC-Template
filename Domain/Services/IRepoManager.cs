using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRepoManager
    {
        IUserDataRepo UserData { get; }

        void Save();

        Task SaveAsync();

    }
}
