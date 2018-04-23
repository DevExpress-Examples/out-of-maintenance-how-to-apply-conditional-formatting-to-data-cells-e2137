using System.Data;
using System.Data.OleDb;
using System.Windows;
using DevExpress.Xpf.PivotGrid;
using HowToBindToMDB.NwindDataSetTableAdapters;
using System.Windows.Markup;
using System.Windows.Data;
using System;
using System.Windows.Media;

namespace HowToBindToMDB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        NwindDataSet.SalesPersonDataTable salesPersonDataTable = new NwindDataSet.SalesPersonDataTable();
        SalesPersonTableAdapter salesPersonDataAdapter = new SalesPersonTableAdapter();

        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = salesPersonDataTable;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            salesPersonDataAdapter.Fill(salesPersonDataTable);
        }
    }

    public class ValueToColorConverter : MarkupExtension, IValueConverter {
        #region IValueConverter Members
        public object Convert(object value, System.Type targetType, object parameter, 
            System.Globalization.CultureInfo culture) {
                if(System.Convert.ToDecimal(value) < 10000)
                    return Brushes.Yellow;
                else
                    return Brushes.Transparent;
        }

        public object ConvertBack(object value, System.Type targetType,
                    object parameter, System.Globalization.CultureInfo culture) {
            throw new System.NotImplementedException();
        }
        #endregion

        public override object ProvideValue(System.IServiceProvider serviceProvider) {
            return this;
        }
    }
}
