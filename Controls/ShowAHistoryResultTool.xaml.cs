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
    public partial class ShowAHistoryResultTool : UserControl
    {
        public ShowAHistoryResultTool()
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
            DependencyProperty.Register("Issue", typeof(string), typeof(ShowAHistoryResultTool), new PropertyMetadata("", (d, e) =>
            {
                ShowAHistoryResultTool td = (ShowAHistoryResultTool)d;
                td.TextBlockOfIssue.Text = (string)e.NewValue;
            }));

        /// <summary>
        /// 一条历史结果
        /// </summary>
        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(string), typeof(ShowAHistoryResultTool), new PropertyMetadata("", (d, e) =>
            {
                ShowAHistoryResultTool td = (ShowAHistoryResultTool)d;
                string te = (string)e.NewValue;
                List<string> sl = te.Split(new char[] { ',' }).ToList();
                td.ItemsControlOfResult.Items.Clear();
                td.ItemsControlOfResult.ItemsSource = sl;
            }));



        #endregion
    }
}
