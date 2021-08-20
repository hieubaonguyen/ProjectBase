namespace Solution.Core.Shared.Kernel
{
    public interface IUserEntity
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
