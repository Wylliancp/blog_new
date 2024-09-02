﻿using Domain.interfaces.Commands;
using Domain.Utils;

namespace Application.Commands.User
{
    public class AuthenticateUserCommand : Validation<AuthenticateUserCommand>, ICommand
    {

        public AuthenticateUserCommand(string nome, string password)
        {
            ValidTasksTitle(nome);
            Nome = nome;
            Password = password;
        }
       
       public string Nome { get; set; }
       public string Password { get; set; }    
        
    }
}




