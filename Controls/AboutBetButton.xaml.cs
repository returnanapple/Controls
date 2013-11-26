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
    public partial class AboutBetButton : UserControl
    {
        public AboutBetButton()
        {
            InitializeComponent();
        }

        #region 依赖属性
        public string AboutBetImagePath
        {
            get { return (string)GetValue(AboutBetImagePathProperty); }
            set { SetValue(AboutBetImagePathProperty, value); }
        }
        public static readonly DependencyProperty AboutBetImagePathProperty =
            DependencyProperty.Register("AboutBetImagePath", typeof(string), typeof(AboutBetButton), new PropertyMetadata(""));
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutBetGridMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutBetGridMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutBetGridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.AboutBetGrid.Style = (Style)this.Resources["PressedEffect"];
        }

        #endregion
    }
}
