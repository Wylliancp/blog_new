using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public static class UserQueries
    {
        
        public static Expression<Func<User,bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<User, bool>> Authentication(string nome, string password)
        {
            return x => x.Nome == nome && x.Password == password;
        }

    }
}