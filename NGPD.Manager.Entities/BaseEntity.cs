namespace NGPD.Manager.Entities;

public abstract class BaseEntity
{
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}

public class BaseEntity<TId> : BaseEntity, IBaseEntity<TId> where TId : IEquatable<TId>, IComparable<TId>
{
    public TId Id { get ; set; }
}

public interface IBaseEntity<TId> where TId : IEquatable<TId>, IComparable<TId>
{
    TId Id { get; set; }
}