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
            RuleItems.ListChanged += (object? _, ListChangedEventArgs _) =>
            {
                OnPropertyChanged(nameof(GlobalRuleDetectionCount));
                OnPropertyChanged(nameof(GlobalEnabledRuleCount));
            };
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
        public int GlobalRuleDetectionCount => RuleItems.Sum(item => item.RuleDetectionCount);

        /// <summary>
        /// 全局匹配次数
        /// </summary>
        public int GlobalEnabledRuleCount => RuleItems.Sum(item => item.RuleEnabled ? 1 : 0);

        /// <summary>
        /// 检测文本长度限制
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        [property: System.ComponentModel.DataAnnotations.Range(10, 2000)]
        private int detectTextLengthLimit = 200;
        partial void OnDetectTextLengthLimitChanged(int value)
        {
            ValidateProperty(value, nameof(DetectTextLengthLimit));
            if (HasErrors)
            {
                if (DetectTextLengthLimit < 10)
                    DetectTextLengthLimit = 10;
                if (DetectTextLengthLimit > 2000)
                    DetectTextLengthLimit = 2000;
            }
        }

        /// <summary>
        /// 规则列表
        /// </summary>
        [property: JsonProperty]
        public BindingList<RuleItem> RuleItems { get; set; } = [];
    }
}
