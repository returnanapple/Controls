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
    public partial class ShowABulletinTool : UserControl
    {
        public ShowABulletinTool()
        {
            InitializeComponent();
        }

        #region 依赖属性
        public string BulletinText
        {
            get { return (string)GetValue(BulletinTextProperty); }
            set { SetValue(BulletinTextProperty, value); }
        }
        public static readonly DependencyProperty BulletinTextProperty =
            DependencyProperty.Register("BulletinText", typeof(string), typeof(ShowABulletinTool), new PropertyMetadata("", (d, e) =>
            {
                ShowABulletinTool td = (ShowABulletinTool)d;
                td.ShowABulletinTextBlock.Text = (string)e.NewValue;
            }));
        #endregion
    }
}
