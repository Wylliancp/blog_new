using System;

namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DateUpdate { get; set; }
        
    }
}