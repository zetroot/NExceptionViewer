using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GroupByTech.NExceptionViewer.Core
{
    /// <summary>
    /// View model of custom property entry
    /// </summary>
    public class CustomPropertyEntryVM
    {
        protected readonly PropertyInfo propertyInfo;
        protected readonly object value;

        /// <summary>
        /// Property name
        /// </summary>
        public virtual string Name => propertyInfo.Name;

        /// <summary>
        /// property type name
        /// </summary>
        public virtual string PropertyType => propertyInfo.PropertyType.Name;

        /// <summary>
        /// property type full name
        /// </summary>
        public virtual string PropertyTypeFullName => propertyInfo.PropertyType.FullName;

        /// <summary>
        /// string representation of property value
        /// </summary>
        public virtual string Value => value.ToString();

        public CustomPropertyEntryVM(PropertyInfo propertyInfo, object value)
        {
            this.propertyInfo = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));
            this.value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
