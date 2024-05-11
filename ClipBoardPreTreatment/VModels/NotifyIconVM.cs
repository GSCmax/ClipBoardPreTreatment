using ClipBoardPreTreatment.Tools;
using ClipBoardPreTreatment.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace ClipBoardPreTreatment.VModels
{
    public partial class NotifyIconVM : ObservableObject
    {
        [RelayCommand]
        private void ShowWindow()
        {
            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = new ConfigWindow();
                Application.Current.MainWindow.Show();
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        [RelayCommand]
        private void ToggleGlobalEnable()
        {
            GlobalDataHelper.appConfig!.GlobalEnable = !GlobalDataHelper.appConfig!.GlobalEnable;
        }

        [RelayCommand]
        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
