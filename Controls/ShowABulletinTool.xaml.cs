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
        /// <summary>
        /// 公告
        /// </summary>
        public string Bulletin
        {
            get { return (string)GetValue(BulletinProperty); }
            set { SetValue(BulletinProperty, value); }
        }
        public static readonly DependencyProperty BulletinProperty =
            DependencyProperty.Register("Bulletin", typeof(string), typeof(ShowABulletinTool), new PropertyMetadata("", (d, e) =>
            {
                ShowABulletinTool td = (ShowABulletinTool)d;
                td.TextBlockOfBulletin.Text = (string)e.NewValue;
            }));
        #endregion

    }
}
