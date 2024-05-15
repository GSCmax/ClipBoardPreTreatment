using ClipBoardPreTreatment.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace ClipBoardPreTreatment.Tools
{
    static class GlobalDataHelper
    {
        /// <summary>
        /// 存储当前App实例的配置信息
        /// </summary>
        public static AppConfig? appConfig;

        /// <summary>
        /// 存储当前App实例的历史记录
        /// </summary>
        public static AppHistory? appHistory;

        /// <summary>
        /// 获取本地存储的配置信息与历史记录
        /// </summary>
        public static void Init()
        {
            if (File.Exists(AppConfig.SavePath))
                try
                {
                    var json = File.ReadAllText(AppConfig.SavePath);
                    appConfig = (string.IsNullOrEmpty(json) ? new AppConfig() : JsonConvert.DeserializeObject<AppConfig>(json)) ?? new AppConfig();
                }
                catch
                {
                    appConfig = new AppConfig();
                }
            else
                appConfig = new AppConfig();

            if (File.Exists(AppHistory.SavePath))
                try
                {
                    var json = File.ReadAllText(AppHistory.SavePath);
                    appHistory = (string.IsNullOrEmpty(json) ? new AppHistory() : JsonConvert.DeserializeObject<AppHistory>(json)) ?? new AppHistory();
                }
                catch
                {
                    appHistory = new AppHistory();
                }
            else
                appHistory = new AppHistory();
        }

        /// <summary>
        /// 保存本地存储的配置信息
        /// </summary>
        public static void Save()
        {
            var json1 = JsonConvert.SerializeObject(appConfig, Formatting.Indented);
            File.WriteAllText(AppConfig.SavePath, json1);

            appHistory!.HistoryItems = new BindingList<Tuple<string, string>>(appHistory!.HistoryItems.Take(appConfig!.HistorySaveCountLimit).ToList());
            var json2 = JsonConvert.SerializeObject(appHistory, Formatting.Indented);
            File.WriteAllText(AppHistory.SavePath, json2);
        }
    }
}
