﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NExceptionViewer.Core
{
    /// <summary>
    /// Exception viewmodel
    /// </summary>
    public class ExceptionVM
    {
        private static readonly IReadOnlyList<string> excludedProps = new List<string>
        {
            nameof(Exception.Data),
            nameof(Exception.HelpLink),
            nameof(Exception.HResult),
            nameof(Exception.InnerException),
            nameof(Exception.Message),
            nameof(Exception.Source),
            nameof(Exception.StackTrace),
            nameof(Exception.TargetSite),
        };
        protected readonly Exception exception;

        public virtual IReadOnlyCollection<DataEntryVM> DataEntries { get; }
        public virtual string HelpLink => exception.HelpLink;
        public virtual int HResult => exception.HResult;
        public virtual string Message => exception.Message;
        public virtual string InnerException => exception.InnerException?.ToString() ?? "(null)";
        public virtual bool HasInnerException => exception.InnerException != null;
        public virtual string Source => exception.Source;
        public virtual string StackTrace => exception.StackTrace;
        public virtual string TargetSite => exception.TargetSite?.ToString();
        
        public virtual IReadOnlyCollection<CustomPropertyEntryVM> CustomProperties { get; }

        public ExceptionVM(Exception exception)
        {
            this.exception = exception ?? throw new ArgumentNullException(nameof(exception));
            var dataEntries = new List<DataEntryVM>();
            foreach(var key in exception.Data.Keys)
            {
                dataEntries.Add(new DataEntryVM(key, exception.Data[key]));
            }
            CustomProperties = GetCustomProperties();
        }
        
        protected virtual List<CustomPropertyEntryVM> GetCustomProperties()
        {
            var customPropInfos = new List<CustomPropertyEntryVM>();
            var allProperties = exception.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(var propInfo in allProperties.Where(x => !excludedProps.Contains(x.Name)))
            {
                var propVal = propInfo.GetValue(exception);
                customPropInfos.Add(new CustomPropertyEntryVM(propInfo, propVal));
            }
            return customPropInfos;
        }
    }
}
