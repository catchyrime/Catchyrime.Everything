using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable InconsistentNaming

namespace Catchyrime.Everything.Developer
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
    public abstract class ParameterDescriptorAttribute : Attribute { }

    public class ConstAttribute : ParameterDescriptorAttribute { }
    public class UpdateAttribute : ParameterDescriptorAttribute
    {
        public UpdateAttribute(string what = null) { }
    }

    public class CanBeNullAttribute : ParameterDescriptorAttribute { }
    public class NotNullAttribute : ParameterDescriptorAttribute { }
    public class NotNullOrEmptyAttribute : ParameterDescriptorAttribute { }
    public class InternalChecked_NotNullAttribute : ParameterDescriptorAttribute { }
    public class CallerChecked_NotNullAttribute : ParameterDescriptorAttribute { }
    public class NotChecked_NotNullAttribute : ParameterDescriptorAttribute { }

    public class InternalCheckedAttribute : ParameterDescriptorAttribute
    {
        public InternalCheckedAttribute(string cond = null) { }
    }
    public class CallerCheckedAttribute : ParameterDescriptorAttribute
    {
        public CallerCheckedAttribute(string cond = null) { }
    }
    public class NotCheckedAttribute : ParameterDescriptorAttribute
    {
        public NotCheckedAttribute(string cond = null) { }
    }
}
