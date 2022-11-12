using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        User GetByEmail(string email);
        
        Task<ServiceResult> InsertAsync(User user);
    }
}
