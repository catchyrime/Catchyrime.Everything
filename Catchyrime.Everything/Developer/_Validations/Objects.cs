using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catchyrime.Everything.Developer
{
    public static partial class Validations
    {
        public static ValidationInfo<T> ArgumentNotNull<T>(
            [Const, CallerChecked_NotNull] this ValidationInfo<T> info, 
            [CanBeNull] string throwMsg = null
            )
        {
            if (info.Condition) {
                if (ReferenceEquals(info.Value, null)) {
                    throw new ArgumentNullException(info.Name, 
                        throwMsg ?? $"Argument: \"{info.Name}\" is null");
                }
            }
            return info;
        }


    }
}
