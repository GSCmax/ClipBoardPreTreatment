using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace ClipBoardPreTreatment.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal partial class HistoryItem : ObservableObject
    {
        /// <summary>
        /// 剪切板文本
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private string? clipboardText;

        /// <summary>
        /// 匹配规则
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private string? detectedRule;

        /// <summary>
        /// 添加时间
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        private DateTime addTime;
    }
}
