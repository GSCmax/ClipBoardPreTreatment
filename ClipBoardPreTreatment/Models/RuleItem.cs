using CommunityToolkit.Mvvm.ComponentModel;

namespace ClipBoardPreTreatment.Models
{
    internal partial class RuleItem : ObservableObject
    {
        /// <summary>
        /// 序号
        /// </summary>
        [ObservableProperty]
        private int ruleIndex;

        /// <summary>
        /// 启用
        /// </summary>
        [ObservableProperty]
        private bool ruleEnabled;

        /// <summary>
        /// 匹配次数
        /// </summary>
        [ObservableProperty]
        private int detectionCount;

        /// <summary>
        /// 检测规则
        /// </summary>
        [ObservableProperty]
        private string? detectionRule;

        /// <summary>
        /// 操作规则
        /// </summary>
        [ObservableProperty]
        private string? operationRule;
    }
}
