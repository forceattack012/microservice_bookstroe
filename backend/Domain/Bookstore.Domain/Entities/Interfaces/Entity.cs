using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Entities.Interfaces
{
    public abstract class Entity<T> : IBaseEntity<T>
    {
        public virtual T Id { get; set; }
        T IBaseEntity<T>.Id
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
