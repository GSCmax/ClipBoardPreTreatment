using ClipBoardPreTreatment.Tools;
using Hardcodet.Wpf.TaskbarNotification;
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

            ClipboardHelper.Init();
            GlobalDataHelper.Init();

            TaskbarIcon notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
