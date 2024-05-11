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
        private void ShowConfigWindow()
        {
            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = new ConfigWindow();
                Application.Current.MainWindow.Show();
            }
        }

        [RelayCommand]
        private void ExitApplication()
        {
            GlobalDataHelper.Save();
            Application.Current.Shutdown();
        }
    }
}
