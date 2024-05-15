using System.ComponentModel;

namespace ClipBoardPreTreatment.Models
{
    internal class AppHistory
    {
        /// <summary>
        /// 历史记录文件存储路径
        /// </summary>
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}History.json";

        /// <summary>
        /// 历史记录列表
        /// </summary>
        public BindingList<Tuple<string, string>> HistoryItems { get; set; } = [];
    }
}
