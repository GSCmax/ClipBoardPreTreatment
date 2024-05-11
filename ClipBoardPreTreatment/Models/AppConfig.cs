using System.ComponentModel;

namespace ClipBoardPreTreatment.Models
{
    internal class AppConfig
    {
        /// <summary>
        /// 配置文件存储路径
        /// </summary>
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

        /// <summary>
        /// 全局启用
        /// </summary>
        public bool GlobalEnable { get; set; } = true;

        /// <summary>
        /// 规则列表
        /// </summary>
        public BindingList<RuleItem> RuleItems { get; set; } = new BindingList<RuleItem>();
    }
}
