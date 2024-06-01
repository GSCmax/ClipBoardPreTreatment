using ClipBoardPreTreatment.Models;
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
        private static void OnClipboardChanged(object? sender, ClipboardChangedEventArgs e)
        {
            if (sender is SharpClipboard sClipboard)
            {
                if (e.ContentType == ContentTypes.Text)
                {
                    var tempStr = sClipboard.ClipboardText;
                    if (tempStr.Length <= GlobalDataHelper.appConfig!.DetectTextLengthLimit)
                    {
                        if (tempStr != GlobalDataHelper.appHistory!.HistoryItems.FirstOrDefault()?.ClipboardText)
                        {
                            var firstDetectedRule = GlobalDataHelper.appConfig!.RuleItems.Where(r => r.RuleEnabled == true).FirstOrDefault(r => Regex.IsMatch(tempStr, r.RuleDetectPattern!));
                            if (firstDetectedRule != null)
                            {
                                firstDetectedRule.RuleDetectionCount++;
                                string res = Regex.Replace(tempStr, firstDetectedRule.RuleReplacePattern!, firstDetectedRule.RuleReplaceText!);
                                GlobalDataHelper.appHistory!.HistoryItems.Insert(0, new HistoryItem() { ClipboardText = tempStr, DetectedRule = firstDetectedRule.RuleDetectPattern!, AddTime = DateTime.Now });
                                System.Windows.Clipboard.SetText(res);
                            }
                            else
                            {
                                GlobalDataHelper.appHistory!.HistoryItems.Insert(0, new HistoryItem() { ClipboardText = tempStr, DetectedRule = "无", AddTime = DateTime.Now });
                            }
                        }
                    }
                }
            }
        }
    }
}
