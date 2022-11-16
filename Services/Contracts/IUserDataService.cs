using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserDataService
    {
        IEnumerable<UserData> GetAll();

        UserData GetByEmail(string email);
        
        Task<ServiceResult> InsertAsync(UserData user);
    }
}
