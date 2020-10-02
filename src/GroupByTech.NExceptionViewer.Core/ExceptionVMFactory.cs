using System;
using System.Collections.Generic;
using System.Text;

namespace GroupByTech.NExceptionViewer.Core
{
    public class ExceptionVMFactory
    {
        public static ExceptionVM CreateViewModel(Exception e)
        {
            return new ExceptionVM(exception: e);
        }
    }
}
