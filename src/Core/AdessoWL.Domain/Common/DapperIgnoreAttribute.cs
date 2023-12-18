using System;

namespace AdessoWL.Domain.Common
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple = true)]
    public class DapperIgnoreAttribute:Attribute
    {
    }
}
