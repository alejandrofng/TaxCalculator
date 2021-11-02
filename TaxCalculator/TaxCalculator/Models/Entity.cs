using System;

namespace TaxCalculator.Models
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; protected set; }
        protected Entity()
        {
        }

        protected Entity(T id) : this()
        {
            Id = id;
        }
    }
}
