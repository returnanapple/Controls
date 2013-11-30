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
    public partial class AboutBetButton : UserControl
    {
        public AboutBetButton()
        {
            InitializeComponent();
        }

        #region 依赖属性
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(AboutBetButton), new PropertyMetadata("添加", (d, e) =>
            {
                AboutBetButton td = (AboutBetButton)d;
                string te = (string)e.NewValue;
                td.ButtonTextImage.Source = new BitmapImage(new Uri(String.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        #endregion

        #region 鼠标事件
        private void MouseEnterAction(object sender, MouseEventArgs e)
        {
            GridOfAboutBetButton.Style = (Style)this.Resources["AboutBetButton_HoverEffect"];
        }
        private void MouseLeaveAction(object sender, MouseEventArgs e)
        {
            GridOfAboutBetButton.Style = (Style)this.Resources["AboutBetButton_NormalEffect"];
        }
        #endregion
    }
}
