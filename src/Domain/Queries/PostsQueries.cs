using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public static class PostsQueries
    {
        
        public static Expression<Func<Posts,bool>> GetById(int id)
        {
            return x => x.Id == id;
        }


        public static Expression<Func<Posts, bool>> GetByPeriod(bool done, DateTime date)
        {
            return x => x.DateCreate.Date == date;
        }

    }
}