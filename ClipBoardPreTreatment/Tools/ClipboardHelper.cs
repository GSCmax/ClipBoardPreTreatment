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
                var detectedRules = GlobalDataHelper.appConfig!.RuleItems.Where(r => r.RuleEnabled == true).Where(r => Regex.IsMatch(sharpClipboard!.ClipboardText, r.RuleReplacePattern!));

                if (detectedRules.Any())
                {
                    var firstDetectedRule = detectedRules.First();
                    firstDetectedRule.RuleDetectionCount++;
                    string res = Regex.Replace(sharpClipboard!.ClipboardText, firstDetectedRule.RuleReplacePattern!, firstDetectedRule.RuleReplaceText!);
                    sharpClipboard.MonitorClipboard = false;
                    System.Windows.Clipboard.SetText(res);
                    sharpClipboard.MonitorClipboard = true;
                }
            }
        }
    }
}
