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
    public partial class QuickButton : UserControl
    {
        public QuickButton()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 按键文本
        /// </summary>
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(QuickButton), new PropertyMetadata("", (d, e) =>
            {
                QuickButton td = (QuickButton)d;
                string te = (string)e.NewValue;
                td.ButtonTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", te), UriKind.RelativeOrAbsolute));
            }));
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnterAction(object sender, MouseEventArgs e)
        {
            Bg.Style = (Style)this.Resources["QuickButton_HoverEffect"];
            ButtonTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Hover.png", ButtonText), UriKind.RelativeOrAbsolute));
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveAction(object sender, MouseEventArgs e)
        {
            Bg.Style = (Style)this.Resources["QuickButton_NormalEffect"];
            ButtonTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", ButtonText), UriKind.RelativeOrAbsolute));
        }
        #endregion
    }
}
