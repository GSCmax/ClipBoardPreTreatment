using System.Windows;
using System.Windows.Controls;

namespace ClipBoardPreTreatment.Views
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private static ConfigWindow? configWindow_instance;

        private ConfigWindow()
        {
            InitializeComponent();
        }

        public static ConfigWindow Instance
        {
            get
            {
                if (configWindow_instance == null)
                {
                    configWindow_instance = new ConfigWindow();
                }
                return configWindow_instance;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            configWindow_instance = null;
            base.OnClosed(e);
        }

        private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)sender;
            dg.CommitEdit(DataGridEditingUnit.Row, true);
        }
    }
}
