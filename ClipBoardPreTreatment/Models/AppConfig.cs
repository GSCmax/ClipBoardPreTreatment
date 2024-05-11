using ClipBoardPreTreatment.Tools;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace ClipBoardPreTreatment.Models
{
    internal partial class AppConfig : ObservableObject
    {
        /// <summary>
        /// 配置文件存储路径
        /// </summary>
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

        /// <summary>
        /// 全局启用
        /// </summary>
        [ObservableProperty]
        private bool globalEnable = true;
        partial void OnGlobalEnableChanged(bool value) => ClipboardHelper.sharpClipboard!.MonitorClipboard = value;

        /// <summary>
        /// 规则列表
        /// </summary>
        public BindingList<RuleItem> RuleItems { get; set; } = new BindingList<RuleItem>();
    }
}
