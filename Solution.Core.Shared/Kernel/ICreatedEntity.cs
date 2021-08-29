using System;

namespace Solution.Core.Shared.Kernel
{
    public interface ICreatedEntity
    {
        DateTime DateCreated { get; set; }
        string CreatedBy { get; set; }
    }
}
