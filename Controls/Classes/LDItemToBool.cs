using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Controls.Classes
{
    public class LDItemToBool : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            LotteryAndDataItems tv = (LotteryAndDataItems)value;
            LotteryAndDataItems tp = (LotteryAndDataItems)Enum.Parse(typeof(LotteryAndDataItems), (string)parameter, false);
            if (tv == tp)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool tv = (bool)value;
            if (tv)
            {
                return (LotteryAndDataItems)Enum.Parse(typeof(LotteryAndDataItems), (string)parameter, false);
            }
            else
            {
                throw new Exception("value为false时不触发同步");
            }
        }
    }
}
