using CommunityToolkit.Mvvm.ComponentModel;

namespace ClipBoardPreTreatment.Models
{
    internal partial class RuleItem : ObservableObject
    {
        /// <summary>
        /// 启用
        /// </summary>
        [ObservableProperty]
        private bool ruleEnabled = false;

        /// <summary>
        /// 匹配次数
        /// </summary>
        [ObservableProperty]
        private int ruleDetectionCount = 0;

        /// <summary>
        /// 检测规则
        /// </summary>
        [ObservableProperty]
        private string? ruleDetectPattern = "";

        /// <summary>
        /// 替换规则
        /// </summary>
        [ObservableProperty]
        private string? ruleReplacePattern = "";

        /// <summary>
        /// 替换文本
        /// </summary>
        [ObservableProperty]
        private string? ruleReplaceText = "";
    }
}
