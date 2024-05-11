using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class ConfigWindowVModel : ObservableObject
    {
        /// <summary>
        /// 确认按钮点击
        /// </summary>
        [RelayCommand]
        private void SaveBTNClick()
        {
            GlobalDataHelper.Save();
        }
    }
}
