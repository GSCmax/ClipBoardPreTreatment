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
        private object? selectedRuleItem;

        /// <summary>
        /// 复制选定项
        /// </summary>
        [RelayCommand]
        private void CopyItem()
        {
            if (SelectedRuleItem is RuleItem t)
            {
                int next = GlobalDataHelper.appConfig!.RuleItems.IndexOf(t) + 1;

                GlobalDataHelper.appConfig!.RuleItems.Insert(next, new RuleItem()
                {
                    RuleEnabled = false,
                    RuleDetectionCount = 0,
                    RuleDetectPattern = t.RuleDetectPattern,
                    RuleReplacePattern = t.RuleReplacePattern,
                    RuleReplaceText = t.RuleReplaceText
                });
            }
        }
    }
}
