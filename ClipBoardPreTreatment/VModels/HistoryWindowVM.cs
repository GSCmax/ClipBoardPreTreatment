using ClipBoardPreTreatment.Models;
using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class HistoryWindowVM : ObservableObject
    {
        [ObservableProperty]
        private HistoryItem? selectedHistoryItem;

        [RelayCommand]
        private void DeleteItem()
        {
            GlobalDataHelper.appHistory?.HistoryItems.Remove(SelectedHistoryItem!);
        }
    }
}
