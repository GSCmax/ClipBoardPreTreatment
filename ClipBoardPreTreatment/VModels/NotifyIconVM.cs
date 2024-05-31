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
            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = new ConfigWindow();
                Application.Current.MainWindow.Show();
            }
        }

        /// <summary>
        /// 显示历史查看器
        /// </summary>
        [RelayCommand]
        private void ShowHistoryWindow()
        {
            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = new HistoryWindow();
                Application.Current.MainWindow.Show();
            }
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
