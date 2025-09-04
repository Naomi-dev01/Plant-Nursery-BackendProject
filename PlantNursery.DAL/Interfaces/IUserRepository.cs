using PlantNursery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User>PostUser(User user);
        Task<User>LoginUser(string username, string password);
        Task<User> UpdateUser(int id, User user);
    }
}
