using ClipBoardPreTreatment.Models;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ClipBoardPreTreatment.Views
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }
    }

    public class GlobalRuleDetectionCountGetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int Count = 0;
            foreach (var item in (BindingList<RuleItem>)value)
            {
                Count += item.RuleDetectionCount;
            }
            return Count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
