using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GroupByTech.NExceptionViewer.Core
{
    /// <summary>
    /// Viewmodel for one entry from DataArray
    /// </summary>
    public class DataEntryVM
    {
        private const string NOT_SET_STRING = "(null)";

        /// <summary>
        /// String representation of the key of data
        /// </summary>
        public virtual string Key { get; }

        /// <summary>
        /// String representation of value of data
        /// </summary>
        public virtual string Value { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public DataEntryVM(string key, string value)
        {
            Key = key ?? NOT_SET_STRING;
            Value = value ?? NOT_SET_STRING;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="key">Key value from dictionary</param>
        /// <param name="value">Value for the key</param>
        public DataEntryVM(object key, object value)
        {
            Key = key?.ToString() ?? NOT_SET_STRING;
            Value = value?.ToString() ?? NOT_SET_STRING;
        }
    }
}
