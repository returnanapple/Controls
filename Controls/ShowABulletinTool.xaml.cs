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


        public string Tittle
        {
            get { return (string)GetValue(TittleProperty); }
            set { SetValue(TittleProperty, value); }
        }
        public static readonly DependencyProperty TittleProperty =
            DependencyProperty.Register("Tittle", typeof(string), typeof(ShowABulletinTool), new PropertyMetadata("", (d, e) =>
            {
                ShowABulletinTool td = (ShowABulletinTool)d;
                string te = (string)e.NewValue;
                td.TittleTextBlock.Text = te;
            }));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ShowABulletinTool), new PropertyMetadata("", (d, e) =>
            {
                ShowABulletinTool td = (ShowABulletinTool)d;
                string te = (string)e.NewValue;
                td.TextTextBlock.Text = te;
            }));



        #endregion
    }
}
