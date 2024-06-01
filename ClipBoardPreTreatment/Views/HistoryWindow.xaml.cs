using System.Windows;

namespace ClipBoardPreTreatment.Views
{
    /// <summary>
    /// HistoryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private static HistoryWindow? historyWindow_instance;

        private HistoryWindow()
        {
            InitializeComponent();
        }

        public static HistoryWindow Instance
        {
            get
            {
                if (historyWindow_instance == null)
                {
                    historyWindow_instance = new HistoryWindow();
                }
                return historyWindow_instance;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            historyWindow_instance = null;
            base.OnClosed(e);
        }
    }
}
