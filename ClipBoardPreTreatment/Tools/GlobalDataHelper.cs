using ClipBoardPreTreatment.Models;
using Newtonsoft.Json;
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
        /// 获取本地存储的配置信息
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
        }

        /// <summary>
        /// 保存本地存储的配置信息
        /// </summary>
        public static void Save()
        {
            var json = JsonConvert.SerializeObject(appConfig, Formatting.Indented);
            File.WriteAllText(AppConfig.SavePath, json);
        }
    }
}
