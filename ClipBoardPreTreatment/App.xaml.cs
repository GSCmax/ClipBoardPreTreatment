using ClipBoardPreTreatment.Tools;
using Hardcodet.Wpf.TaskbarNotification;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ClipBoardPreTreatment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Process p = Process.GetCurrentProcess();
            _ = new Mutex(true, p.ProcessName, out bool createNew);
            if (!createNew)
                Application.Current.Shutdown();

            //初始化
            ClipboardHelper.Init();
            GlobalDataHelper.Init();

            _ = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            //保存配置
            GlobalDataHelper.Save();
        }
    }

    /// <summary>
    /// 用于Tooltip的启用/停用显示
    /// </summary>
    public class Bool2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "启用" : "停用";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 用于状态栏深浅色图标选择
    /// </summary>
    public class Bool2ResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? ((string)parameter).Split('|')[0] : ((string)parameter).Split('|')[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
