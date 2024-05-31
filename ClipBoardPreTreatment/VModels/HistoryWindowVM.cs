using ClipBoardPreTreatment.Models;
using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class HistoryWindowVM : ObservableObject
    {
        /// <summary>
        /// 历史记录列表的选定项
        /// </summary>
        [ObservableProperty]
        private HistoryItem? selectedHistoryItem;

        /// <summary>
        /// 删除选定项
        /// </summary>
        [RelayCommand]
        private void DeleteItem()
        {
            if (SelectedHistoryItem != null)
                GlobalDataHelper.appHistory!.HistoryItems.Remove(SelectedHistoryItem);
        }

        /// <summary>
        /// 复制选定项
        /// </summary>
        [RelayCommand]
        private void Copy()
        {
            if (SelectedHistoryItem != null)
                System.Windows.Clipboard.SetText(SelectedHistoryItem.ClipboardText);
        }
    }
}
