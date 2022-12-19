namespace Bookstore.Domain.Entities.Interfaces
{
    public abstract class Entity<T> : IBaseEntity<T>
    {
        public virtual T Id { get; protected set; }
        T IBaseEntity<T>.Id
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
