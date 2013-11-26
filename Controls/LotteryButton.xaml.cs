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
    public partial class LotteryButton : UserControl
    {
        public LotteryButton()
        {
            InitializeComponent();
        }

        #region 依赖属性
        /// <summary>
        /// 彩票
        /// </summary>
        public string LotteryText
        {
            get { return (string)GetValue(LotteryTextProperty); }
            set { SetValue(LotteryTextProperty, value); }
        }
        public static readonly DependencyProperty LotteryTextProperty =
            DependencyProperty.Register("LotteryText", typeof(string), typeof(LotteryButton), new PropertyMetadata("", (d, e) =>
            {
                LotteryButton td = (LotteryButton)d;
                string te = (string)e.NewValue;
                td.LotteryImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        /// <summary>
        /// 是否被选择
        /// </summary>
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(LotteryButton), new PropertyMetadata(false, (d, e) =>
            {
                LotteryButton td = (LotteryButton)d;
                bool te = (bool)e.NewValue;
                if (te)
                {
                    Style ts = td.Resources["SelectedEffect"] as Style;
                    td.LotteryGrid.Style = ts;
                }
                else
                {
                    td.LotteryGrid.Style = null;
                }
            }));
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LotteryImageMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }

        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LotteryImageMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
        }

        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LotteryImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.Selected)
            {
                this.Selected = true;
            }
        }
        #endregion
    }
}
