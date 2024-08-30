using System;

namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; protected set; }
        public DateTime DateUpdate { get; protected set; }
        
    }
}