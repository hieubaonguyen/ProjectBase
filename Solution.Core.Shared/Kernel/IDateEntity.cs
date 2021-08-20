using System;

namespace Solution.Core.Shared.Kernel
{
    public interface IDateEntity
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
