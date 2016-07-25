using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catchyrime.Everything.Developer
{
    public class ValidationInfo<T>
    {
        public readonly T Value;
        public readonly string Name;
        public bool Condition;

        public ValidationInfo(
            [Const, CanBeNull] T value, 
            [NotNull, CallerChecked] string name)
        {
            this.Value = value;
            this.Name = name;
            this.Condition = true;
        }
    }

    public static partial class Validations
    {
        public static ValidationInfo<T> Requires<T>(
            [Const, CanBeNull] T value, 
            [CallerChecked_NotNull] string name
            )
        {
            return new ValidationInfo<T>(value, name);
        }


        public static ValidationInfo<T> When<T>(
            [Update("info.Condition"), CallerChecked_NotNull] this ValidationInfo<T> info, 
            bool condition
            )
        {
            info.Condition &= condition;
            return info;
        }

        public static ValidationInfo<T> When<T>(
            [Update("info.Condition"), CallerChecked_NotNull] this ValidationInfo<T> info,
            [CallerChecked_NotNull] Func<bool> func
            )
        {
            if (info.Condition) {
                info.Condition = func.Invoke();
            }
            return info;
        }

        public static ValidationInfo<T> When<T>(
            [Update("info.Condition"), CallerChecked_NotNull] this ValidationInfo<T> info,
            [CallerChecked_NotNull] Func<ValidationInfo<T>, bool> func
            )
        {
            if (info.Condition) {
                info.Condition = func.Invoke(info);
            }
            return info;
        }

    }
}
