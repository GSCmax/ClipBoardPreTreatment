using ClipBoardPreTreatment.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class NotifyIconVM : ObservableObject
    {
        /// <summary>
        /// 显示配置管理器
        /// </summary>
        [RelayCommand]
        private void ShowConfigWindow()
        {
            var cw = ConfigWindow.Instance;
            cw.Show();
            cw.WindowState = WindowState.Normal;
            cw.Activate();
        }

        /// <summary>
        /// 显示历史查看器
        /// </summary>
        [RelayCommand]
        private void ShowHistoryWindow()
        {
            var hw = HistoryWindow.Instance;
            hw.Show();
            hw.WindowState = WindowState.Normal;
            hw.Activate();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        [RelayCommand]
        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
