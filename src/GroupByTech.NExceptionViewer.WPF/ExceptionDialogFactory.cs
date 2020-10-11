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
        public static Window OpenDialog(Exception exception)
        {
            var viewmodel = ExceptionVMFactory.CreateViewModel(exception);
            var dialogContents = viewmodel switch
            {
                AggregateExceptionVM aggregateExceptionVM => new AggregateExceptionViewControl(aggregateExceptionVM) as UserControl,
                ExceptionVM exceptionVM => new ExceptionViewControl(exceptionVM) as UserControl,
                _ => throw new NotSupportedException()
            };

            var dialogWindow = new Window
            {
                Content = dialogContents,
                WindowStyle = WindowStyle.ToolWindow,
                Topmost = true
            };

            return dialogWindow;
        }
    }
}
