using ClipBoardPreTreatment.Tools;
using Hardcodet.Wpf.TaskbarNotification;
using System.Diagnostics;
using System.Windows;

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

            bool createNew;
            Process p = Process.GetCurrentProcess();
            Mutex m = new Mutex(true, p.ProcessName, out createNew);
            if (!createNew)
                Application.Current.Shutdown();

            //初始化
            ClipboardHelper.Init();
            GlobalDataHelper.Init();

            TaskbarIcon notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            //保存配置
            GlobalDataHelper.Save();
        }
    }
}
