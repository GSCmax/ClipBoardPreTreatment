using System.Text.RegularExpressions;
using WK.Libraries.SharpClipboardNS;
using static WK.Libraries.SharpClipboardNS.SharpClipboard;

namespace ClipBoardPreTreatment.Tools
{
    static class ClipboardHelper
    {
        /// <summary>
        /// 剪切板监测实例
        /// </summary>
        public static SharpClipboard? sharpClipboard;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            sharpClipboard = new SharpClipboard();
            sharpClipboard!.ClipboardChanged += OnClipboardChanged;
        }

        /// <summary>
        /// 剪切板变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnClipboardChanged(Object? sender, ClipboardChangedEventArgs e)
        {
            if (e.ContentType == ContentTypes.Text)
            {
                var tempStr = ((SharpClipboard)sender!).ClipboardText;
                if (tempStr.Length <= GlobalDataHelper.appConfig!.DetectTextLengthLimit)
                {
                    if (tempStr != GlobalDataHelper.appConfig!.HistoryItems.FirstOrDefault()?.Item1)
                    {
                        var firstDetectedRule = GlobalDataHelper.appConfig!.RuleItems.Where(r => r.RuleEnabled == true).FirstOrDefault(r => Regex.IsMatch(tempStr, r.RuleDetectPattern!));
                        if (firstDetectedRule != null)
                        {
                            firstDetectedRule.RuleDetectionCount++;
                            string res = Regex.Replace(tempStr, firstDetectedRule.RuleReplacePattern!, firstDetectedRule.RuleReplaceText!);
                            ((SharpClipboard)sender!).MonitorClipboard = false;
                            System.Windows.Clipboard.SetText(res);
                            ((SharpClipboard)sender!).MonitorClipboard = true;
                            Save2History(tempStr, firstDetectedRule.RuleDetectPattern!);
                        }
                        else
                        {
                            Save2History(tempStr, "无");
                        }
                    }
                }
            }
        }

        private static void Save2History(string text, string pattern)
        {
            var temp = new Tuple<string, string>(text, pattern);

            if (GlobalDataHelper.appConfig!.HistoryItems.Count < GlobalDataHelper.appConfig.HistorySaveCountLimit)
            {
                GlobalDataHelper.appConfig!.HistoryItems.Insert(0, temp);
            }
            else
            {
                GlobalDataHelper.appConfig!.HistoryItems.Remove(GlobalDataHelper.appConfig!.HistoryItems.Last());
                GlobalDataHelper.appConfig!.HistoryItems.Insert(0, temp);
            }
        }
    }
}
