using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupByTech.NExceptionViewer.Core
{
    /// <summary>
    /// Вьюмодель аггрегированного исключения для многопоточной среды
    /// </summary>
    public class AggregateExceptionVM : ExceptionVM
    {
        /// <summary>
        /// Коллекция вьюмоделей внутренних исключений
        /// </summary>
        public IReadOnlyCollection<ExceptionVM> InnerExceptions { get; }

        protected override List<CustomPropertyEntryVM> GetCustomProperties()
        {
            return base.GetCustomProperties().Where(x => x.Name != "InnerExceptions").ToList();
        }

        internal AggregateExceptionVM(AggregateException exception) : base(exception)
        {
            InnerExceptions = exception.InnerExceptions.Select(x => ExceptionVMFactory.CreateViewModel(x)).ToList();
        }
    }
}
