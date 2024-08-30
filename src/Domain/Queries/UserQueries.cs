using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public static class UserQueries
    {
        
        public static Expression<Func<Posts,bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

    }
}