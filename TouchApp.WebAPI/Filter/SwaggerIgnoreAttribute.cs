using System;

namespace shopazclient.Filter
{
    /// <summary>
    /// Swaggerde properilerin gizledilmesi
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}
