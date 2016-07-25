using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catchyrime.Everything.Developer
{
    public partial class Validations
    {
        public static ValidationInfo<int> ArgumentInRange(
            [Const, CallerChecked_NotNull] this ValidationInfo<int> info,
            int lower,
            int upper,
            [CanBeNull] string throwMsg = null
            )
        {
            if (info.Condition) {
                if (info.Value < lower || info.Value > upper) {
                    throw new ArgumentNullException(info.Name,
                                                    throwMsg ?? $"Argument: \"{info.Name}\" = {info.Value} should be within {lower} to {upper}");
                }
            }
            return info;
        }

        public static ValidationInfo<int> ArgumentNotNegative(
            [Const, CallerChecked_NotNull] this ValidationInfo<int> info,
            [CanBeNull] string throwMsg = null
            )
        {
            if (info.Condition)
            {
                if (info.Value < 0)
                {
                    throw new ArgumentNullException(info.Name,
                                                    throwMsg ?? $"Argument: \"{info.Name}\" = {info.Value} should not be negative");
                }
            }
            return info;
        }


        public static ValidationInfo<int> IndexInRange(
            [Const, CallerChecked_NotNull] this ValidationInfo<int> info,
            int lower,
            int upper,
            [CanBeNull] string throwMsg = null
            )
        {
            if (info.Condition) {
                if (info.Value < lower || info.Value > upper) {
                    throw new ArgumentNullException(info.Name,
                                                    throwMsg ?? $"Index: \"{info.Name}\" = {info.Value} should be within {lower} to {upper}");
                }
            }
            return info;
        }

        public static ValidationInfo<int> IndexNotNegative(
            [Const, CallerChecked_NotNull] this ValidationInfo<int> info,
            [CanBeNull] string throwMsg = null
            )
        {
            if (info.Condition) {
                if (info.Value < 0) {
                    throw new ArgumentNullException(info.Name,
                                                    throwMsg ?? $"Index: \"{info.Name}\" = {info.Value} should not be negative");
                }
            }
            return info;
        }


        public static ValidationInfo<int> GreaterOrEqual(
            [Const, CallerChecked_NotNull] this ValidationInfo<int> info,
            int lower,
            [CanBeNull] string throwMsg = null
            )
        {
            if (info.Condition) {
                if (info.Value < lower) {
                    throw new ArgumentNullException(info.Name,
                                                    throwMsg ?? $"\"{info.Name}\" = {info.Value} should not be greater than or equal to {lower}");
                }
            }
            return info;
        }



    }
}
