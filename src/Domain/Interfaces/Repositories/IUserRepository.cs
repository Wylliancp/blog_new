using System;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User GetUserPeriodAsync(DateTime dateInitial, DateTime DateEnd); 
    }
}   