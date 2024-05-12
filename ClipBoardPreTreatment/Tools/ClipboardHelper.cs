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
                    GlobalDataHelper.appConfig!.HistoryItems.Insert(0, tempStr);
                    var firstDetectedRule = GlobalDataHelper.appConfig!.RuleItems.Where(r => r.RuleEnabled == true).FirstOrDefault(r => Regex.IsMatch(tempStr, r.RuleReplacePattern!));
                    if (firstDetectedRule != null)
                    {
                        firstDetectedRule.RuleDetectionCount++;
                        string res = Regex.Replace(tempStr, firstDetectedRule.RuleReplacePattern!, firstDetectedRule.RuleReplaceText!);
                        ((SharpClipboard)sender!).MonitorClipboard = false;
                        System.Windows.Clipboard.SetText(res);
                        ((SharpClipboard)sender!).MonitorClipboard = true;
                    }
                }
            }
        }
    }
}
