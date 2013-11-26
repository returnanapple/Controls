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
    public partial class QuickButton : UserControl
    {
        public QuickButton()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 文本图片
        /// </summary>
        public string QuickImagePath
        {
            get { return (string)GetValue(QuickImagePathProperty); }
            set { SetValue(QuickImagePathProperty, value); }
        }
        public static readonly DependencyProperty QuickImagePathProperty =
            DependencyProperty.Register("QuickImagePath", typeof(string), typeof(QuickButton), new PropertyMetadata(""));
        /// <summary>
        /// 命令
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(QuickButton), new PropertyMetadata(null));
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickGridMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickGridMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickGridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.QuickGrid.Style = (Style)this.Resources["PressedEffect"];
        }

        #endregion
    }
}
