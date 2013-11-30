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
using System.Windows.Shapes;

namespace Controls
{
    public partial class ShowAWinningTool : UserControl
    {
        public ShowAWinningTool()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 期号
        /// </summary>
        public string Issue
        {
            get { return (string)GetValue(IssueProperty); }
            set { SetValue(IssueProperty, value); }
        }
        public static readonly DependencyProperty IssueProperty =
            DependencyProperty.Register("Issue", typeof(string), typeof(ShowAWinningTool), new PropertyMetadata("", (d, e) =>
            {
                ShowAWinningTool td = (ShowAWinningTool)d;
                string te = (string)e.NewValue;
                td.IssueTextBlock.Text = te;
            }));
        /// <summary>
        /// 金额
        /// </summary>
        public double Money
        {
            get { return (double)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }
        public static readonly DependencyProperty MoneyProperty =
            DependencyProperty.Register("Money", typeof(double), typeof(ShowAWinningTool), new PropertyMetadata(0.0, (d, e) =>
            {
                ShowAWinningTool td = (ShowAWinningTool)d;
                double te = (double)e.NewValue;
                td.MoneyTextBlock.Text = te.ToString();
            }));
        #endregion

    }
}
