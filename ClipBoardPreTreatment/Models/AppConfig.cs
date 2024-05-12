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
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

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

        private const int minimumDetectTextLengthLimit = 10;
        private const int maximumDetectTextLengthLimit = 2000;

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
        public BindingList<RuleItem> RuleItems { get; set; } = new BindingList<RuleItem>();

        private void RuleItems_ListChanged(object? sender, ListChangedEventArgs e)
        {
            int count = 0;
            foreach (var item in RuleItems)
            {
                count += item.RuleDetectionCount;
            }
            GlobalRuleDetectionCount = count;
        }
    }
}
