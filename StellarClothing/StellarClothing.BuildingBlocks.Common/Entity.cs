using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StellarClothing.BuildingBlocks.Domain
{
    public abstract class Entity<T> : IEquatable<Entity<T>>, IIdentity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; protected set; }

        public Entity()
        {

        }

        protected Entity(T id)
        {
            if (object.Equals(id, default(T)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = id;
        }

        public bool Equals(Entity<T> other)
        {
            if(other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
