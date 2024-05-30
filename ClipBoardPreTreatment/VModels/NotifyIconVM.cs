using ClipBoardPreTreatment.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class NotifyIconVM : ObservableObject
    {
        [RelayCommand]
        private void ShowConfigWindow()
        {
            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = new ConfigWindow();
                Application.Current.MainWindow.Show();
            }
        }

        [RelayCommand]
        private void ShowHistoryWindow()
        {
            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = new HistoryWindow();
                Application.Current.MainWindow.Show();
            }
        }

        [RelayCommand]
        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
