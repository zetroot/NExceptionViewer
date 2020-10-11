using System;
using System.Collections.Generic;
using System.Text;

namespace GroupByTech.NExceptionViewer.Core
{
    public class ExceptionVMFactory
    {
        public static ExceptionVM CreateViewModel(Exception e) => e switch
        {
            null => throw new ArgumentNullException(nameof(e)),
            AggregateException aggregateException => new AggregateExceptionVM(aggregateException),
            Exception exception => new ExceptionVM(exception)            
        };
    }
}
