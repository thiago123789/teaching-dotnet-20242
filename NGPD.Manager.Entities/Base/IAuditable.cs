namespace NGPD.Manager.Entities.Base;

public interface IAuditable
{
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}