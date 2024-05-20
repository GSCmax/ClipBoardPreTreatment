using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace ClipBoardPreTreatment.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal partial class AppConfig : ObservableValidator
    {
        public AppConfig()
        {
            RuleItems.ListChanged += RuleItems_ListChanged;
        }

        /// <summary>
        /// 配置文件存储路径
        /// </summary>
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}Config.json";

        /// <summary>
        /// 全局启用
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private bool globalEnable = true;
        partial void OnGlobalEnableChanged(bool value) => ClipboardHelper.sharpClipboard!.MonitorClipboard = value;

        /// <summary>
        /// 全局匹配次数
        /// </summary>
        [ObservableProperty]
        private int globalRuleDetectionCount = 0;

        /// <summary>
        /// 全局匹配次数
        /// </summary>
        [ObservableProperty]
        private int globalEnabledRuleCount = 0;

        private const int minimumDetectTextLengthLimit = 10;
        private const int maximumDetectTextLengthLimit = 2000;

        /// <summary>
        /// 检测文本长度限制
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        [property: System.ComponentModel.DataAnnotations.Range(minimumDetectTextLengthLimit, maximumDetectTextLengthLimit)]
        private int detectTextLengthLimit = 200;
        partial void OnDetectTextLengthLimitChanged(int value)
        {
            ValidateProperty(value, nameof(DetectTextLengthLimit));
            if (HasErrors)
            {
                if (DetectTextLengthLimit < minimumDetectTextLengthLimit)
                    DetectTextLengthLimit = minimumDetectTextLengthLimit;
                if (DetectTextLengthLimit > maximumDetectTextLengthLimit)
                    DetectTextLengthLimit = maximumDetectTextLengthLimit;
            }
        }

        /// <summary>
        /// 规则列表
        /// </summary>
        [property: JsonProperty]
        public BindingList<RuleItem> RuleItems { get; set; } = [];
        private void RuleItems_ListChanged(object? sender, ListChangedEventArgs e)
        {
            int d_count = 0;
            int e_count = 0;
            foreach (var item in RuleItems)
            {
                d_count += item.RuleDetectionCount;
                if (item.RuleEnabled)
                    e_count++;
            }
            GlobalRuleDetectionCount = d_count;
            GlobalEnabledRuleCount = e_count;
        }
    }
}
