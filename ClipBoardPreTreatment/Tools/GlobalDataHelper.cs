using ClipBoardPreTreatment.Models;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace ClipBoardPreTreatment.Tools
{
    static class GlobalDataHelper
    {
        /// <summary>
        /// 存储当前App实例的版本信息
        /// </summary>
        public static string appVersion = Assembly.GetEntryAssembly()!.GetName().Version!.ToString();

        /// <summary>
        /// 存储当前App实例的配置信息
        /// </summary>
        public static AppConfig? appConfig;

        /// <summary>
        /// 存储当前App实例的历史记录
        /// </summary>
        public static AppHistory? appHistory;

        /// <summary>
        /// 存储当前系统是否是浅色模式
        /// </summary>
        public static bool isLightMode = true;

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

            try
            {
                var v = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", "1");
                if (v != null && v.ToString() == "0")
                    isLightMode = false;
            }
            catch { }
        }

        /// <summary>
        /// 保存本地存储的配置信息
        /// </summary>
        public static void Save()
        {
            var json1 = JsonConvert.SerializeObject(appConfig, Formatting.Indented);
            File.WriteAllText(AppConfig.SavePath, json1);

            var json2 = JsonConvert.SerializeObject(appHistory, Formatting.Indented);
            File.WriteAllText(AppHistory.SavePath, json2);
        }
    }
}
