using System;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPostsRepository : IBaseRepository<Posts>
    {
        public Posts GetPostsPeriodAsync(DateTime dateInitial, DateTime DateEnd); 
    }
}   