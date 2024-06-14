using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace ClipBoardPreTreatment.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal partial class RuleItem : ObservableValidator
    {
        /// <summary>
        /// 启用
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private bool ruleEnabled = true;

        /// <summary>
        /// 匹配次数
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private int ruleDetectionCount = 0;

        /// <summary>
        /// 检测规则
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        [property: System.ComponentModel.DataAnnotations.Required(ErrorMessage = "此为必填项")]
        private string? ruleDetectPattern = "必填";
        partial void OnRuleDetectPatternChanged(string? value)
        {
            ValidateProperty(value, nameof(RuleDetectPattern));
            if (HasErrors)
            {
                RuleEnabled = false;
            }
        }

        /// <summary>
        /// 替换规则
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        [property: System.ComponentModel.DataAnnotations.Required(ErrorMessage = "此为必填项")]
        private string? ruleReplacePattern = "必填";
        partial void OnRuleReplacePatternChanged(string? value)
        {
            ValidateProperty(value, nameof(RuleReplacePattern));
            if (HasErrors)
            {
                RuleEnabled = false;
            }
        }

        /// <summary>
        /// 替换文本
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private string? ruleReplaceText = "可空";

        /// <summary>
        /// 备注
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private string? ruleRemark = "可空";

        /// <summary>
        /// 重写ToString()方法
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"匹配规则：{RuleDetectPattern}\n替换规则：{RuleReplacePattern}\n替换文本：{RuleReplaceText}\n备　　注：{RuleRemark}";
    }
}
