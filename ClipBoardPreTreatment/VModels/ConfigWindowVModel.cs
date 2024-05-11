using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.Input;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class ConfigWindowVModel
    {
        /// <summary>
        /// 确认按钮点击
        /// </summary>
        [RelayCommand]
        private void confirmBTNClick()
        {
            GlobalDataHelper.Save();
        }

        /// <summary>
        /// 取消按钮点击
        /// </summary>
        [RelayCommand]
        private void cancelBTNClick()
        {

        }
    }
}
