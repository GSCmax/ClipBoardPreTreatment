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

            // 获取工作区域的宽度和高度
            double screenWidth = SystemParameters.WorkArea.Width;
            double screenHeight = SystemParameters.WorkArea.Height;

            // 设置窗口的宽度和高度
            double windowWidth = Width;
            double windowHeight = Height;

            // 计算窗口的左边距和上边距，使其位于右下角
            Left = screenWidth - windowWidth;
            Top = screenHeight - windowHeight;
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
