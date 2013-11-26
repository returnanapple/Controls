using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Controls
{
    public partial class RemainTimeAndResultControl : UserControl
    {
        public RemainTimeAndResultControl()
        {
            InitializeComponent();
        }

        TimeSpan remainTime;

        #region 依赖属性
        /// <summary>
        /// 下期期号
        /// </summary>
        public string NextIssue
        {
            get { return (string)GetValue(NextIssueProperty); }
            set { SetValue(NextIssueProperty, value); }
        }
        public static readonly DependencyProperty NextIssueProperty =
            DependencyProperty.Register("NextIssue", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata("", (d, e) =>
            {
                RemainTimeAndResultControl td = (RemainTimeAndResultControl)d;
                td.NextIssueTextBlock.Text = (string)e.NewValue;
            }));
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(RemainTimeAndResultControl), new PropertyMetadata(new DateTime(), (d, e) =>
            {
                RemainTimeAndResultControl td = (RemainTimeAndResultControl)d;
                DateTime te = (DateTime)e.NewValue;
                if (te > DateTime.Now)
                {
                    td.remainTime = te - DateTime.Now;
                    if (td.remainTime.Hours > 0)
                    {
                        td.ThousandImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Hours) / 10)), UriKind.RelativeOrAbsolute));
                        td.HundredImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Hours) % 10)), UriKind.RelativeOrAbsolute));
                        td.TenImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Minutes) / 10)), UriKind.RelativeOrAbsolute));
                        td.OneImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Minutes) % 10)), UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        td.ThousandImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Minutes) / 10)), UriKind.RelativeOrAbsolute));
                        td.HundredImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Minutes) % 10)), UriKind.RelativeOrAbsolute));
                        td.TenImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Seconds) / 10)), UriKind.RelativeOrAbsolute));
                        td.OneImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((td.remainTime.Seconds) % 10)), UriKind.RelativeOrAbsolute));
                    }
                    (td.Resources["FlickerAndDescending"] as Storyboard).Begin();
                }
            }));
        /// <summary>
        /// 彩票类型
        /// </summary>
        public string Lottery
        {
            get { return (string)GetValue(LotteryProperty); }
            set { SetValue(LotteryProperty, value); }
        }
        public static readonly DependencyProperty LotteryProperty =
            DependencyProperty.Register("Lottery", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata("", (d, e) =>
            {
                RemainTimeAndResultControl td = (RemainTimeAndResultControl)d;
                td.LotteryTextBlock.Text = (string)e.NewValue;
            }));


        /// <summary>
        /// 当前期号
        /// </summary>
        public string CurrentIssue
        {
            get { return (string)GetValue(LastIssueProperty); }
            set { SetValue(LastIssueProperty, value); }
        }
        public static readonly DependencyProperty LastIssueProperty =
            DependencyProperty.Register("LastIssue", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata("", (d, e) =>
            {
                RemainTimeAndResultControl td = (RemainTimeAndResultControl)d;
                td.CurrentIssueTextBlock.Text = (string)e.NewValue;
            }));
        /// <summary>
        /// 当前结果
        /// </summary>
        public string CurrentResult
        {
            get { return (string)GetValue(CurrentResultProperty); }
            set { SetValue(CurrentResultProperty, value); }
        }
        public static readonly DependencyProperty CurrentResultProperty =
            DependencyProperty.Register("CurrentResult", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata("", (d, e) =>
            {
                RemainTimeAndResultControl td = (RemainTimeAndResultControl)d;
                string te = (string)e.NewValue;
                List<string> sl = te.Split(new Char[] { ',' }).ToList();
                for (int i = 0; i < sl.Count; i++)
                {
                    sl[i] = string.Format("Images/结果{0}.png", sl[i]);
                }
                td.CurrentResultItemsControl.Items.Clear();
                td.CurrentResultItemsControl.ItemsSource = sl;
            }));
        #endregion
        #region 动画结束事件
        void FlickerAndDescendingCompleted(object sender, EventArgs e)
        {
            if (remainTime.TotalSeconds > 0)
            {
                remainTime = remainTime - new TimeSpan(0, 0, 1);
                if (remainTime.Hours == 0)
                {
                    ThousandImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) / 10)), UriKind.RelativeOrAbsolute));
                    HundredImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) % 10)), UriKind.RelativeOrAbsolute));
                    TenImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Seconds) / 10)), UriKind.RelativeOrAbsolute));
                    OneImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Seconds) % 10)), UriKind.RelativeOrAbsolute));
                }
                else
                {
                    ThousandImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Hours) / 10)), UriKind.RelativeOrAbsolute));
                    HundredImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Hours) % 10)), UriKind.RelativeOrAbsolute));
                    TenImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) / 10)), UriKind.RelativeOrAbsolute));
                    OneImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) % 10)), UriKind.RelativeOrAbsolute));
                }
                (this.Resources["FlickerAndDescending"] as Storyboard).Begin();
            }
            else
            {
                ThousandImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
                HundredImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
                TenImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
                OneImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
            }

        }
        #endregion
    }
}
