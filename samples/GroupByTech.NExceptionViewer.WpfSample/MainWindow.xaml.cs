using GroupByTech.NExceptionViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupByTech.NExceptionViewer.WpfSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var exc = new Exception("Sample exception", new Exception("inner exception"));
                exc.Data.Add("sample key", "sampleValue");
                throw exc;
            }
            catch(Exception exc)
            {
                var dialog = new DialogWin();
                dialog.DataContext = ExceptionVMFactory.CreateViewModel(exc);
                dialog.ShowDialog();
            }
        }
    }
}
