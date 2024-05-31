using ClipBoardPreTreatment.Models;
using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClipBoardPreTreatment.VModels
{
    internal partial class ConfigWindowVModel : ObservableObject
    {
        /// <summary>
        /// 匹配规则列表的选定项
        /// </summary>
        [ObservableProperty]
        private RuleItem? selectedRuleItem;

        /// <summary>
        /// 复制选定项
        /// </summary>
        [RelayCommand]
        private void CopyItem()
        {
            if (SelectedRuleItem != null)
            {
                GlobalDataHelper.appConfig!.RuleItems.Add(new RuleItem()
                {
                    RuleEnabled = false,
                    RuleDetectionCount = 0,
                    RuleDetectPattern = SelectedRuleItem.RuleDetectPattern,
                    RuleReplacePattern = SelectedRuleItem.RuleReplacePattern,
                    RuleReplaceText = SelectedRuleItem.RuleReplaceText,
                });
            }
        }
    }
}
