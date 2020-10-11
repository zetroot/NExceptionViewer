using GroupByTech.NExceptionViewer.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GroupByTech.NExceptionViewer.WPF
{
    public class ExceptionDialogFactory
    {
        public static Window CreateDialog(Exception exception)
        {
            var viewmodel = ExceptionVMFactory.CreateViewModel(exception);
            return CreateDialog(viewmodel);
        }

        public static Window CreateDialog(ExceptionVM exceptionViewModel) => exceptionViewModel switch
        {
            AggregateExceptionVM aggregateExceptionVM => new AggregateExceptionView(aggregateExceptionVM) as Window,
            ExceptionVM exceptionVM => new ExceptionView(exceptionVM) as Window,
            _ => throw new NotSupportedException()
        };
    }
}
