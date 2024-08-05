using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Abstractions
{
    public abstract class Entity
    {

        protected Entity(Guid id)
        {
            Id = id;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            ModifyAt = null;
        }

        protected Entity()
        {
        }

        public Guid Id { get; set; }
        public bool IsDeleted { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? ModifyAt { get; init; }
    }

}


