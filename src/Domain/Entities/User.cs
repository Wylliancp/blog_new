using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string Nome { get; private set; }
        public string Password { get; set; }
        //public DateTime DateEnd { get; private set; }
        public IList<Posts> Posts { get; private set; } = new List<Posts>();



        public User(string nome, string password)
        {
            Nome = nome;
            Password = password;
            AddDateCreate();
        }

        public User()
        {

        }
        public void AddDateCreate()
        {
            DateCreate = DateTime.Now;
        }


        public void UpdataUser(string nome, string password)
        {
            Nome = nome;
            Password = password;
            DateUpdate = DateTime.Now;
        }

    }
}
