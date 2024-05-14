using System.Windows;
using System.Windows.Controls;

namespace ClipBoardPreTreatment.Views
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)sender;
            dg.CommitEdit(DataGridEditingUnit.Row, true);
        }
    }
}
