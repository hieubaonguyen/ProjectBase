using System;

namespace Solution.Core.Shared.Kernel
{
    public interface IModifiedEntity
    {
        DateTime DateModified { get; set; }
        string ModifiedBy { get; set; }
    }
}
