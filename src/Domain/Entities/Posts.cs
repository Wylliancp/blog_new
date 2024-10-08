﻿using System;

namespace Domain.Entities
{
    public class Posts : EntityBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        //public DateTime DateEnd { get; private set; }
        public int UserId { get; private set; }


        public Posts(string title, string description, int userId)
        {
            Title = title;
            Description = description;
            UserId = userId;
            AddDateCreate();
        }
        public void AddDateCreate()
        {
            DateCreate = DateTime.Now;
        }
        public void UpdataPosts(string title, string description)
        {
            Title = title;
            Description = description;
            DateUpdate = DateTime.Now;
        }

    }
}
