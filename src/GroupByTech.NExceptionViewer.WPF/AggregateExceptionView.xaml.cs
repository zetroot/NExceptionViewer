using GroupByTech.NExceptionViewer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupByTech.NExceptionViewer.WPF
{
    /// <summary>
    /// Interaction logic for ExceptionView.xaml
    /// </summary>
    public partial class AggregateExceptionView : Window
    {
        protected AggregateExceptionView()
        {
            InitializeComponent();
        }

        internal AggregateExceptionView(AggregateExceptionVM viewModel) : this()
        {            
            DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void OpenInnerException(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is ExceptionVM innerExceptionVm)
            {
                var dialog = ExceptionDialogFactory.CreateDialog(innerExceptionVm);
                dialog.ShowDialog();
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
