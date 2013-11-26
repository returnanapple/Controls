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
    public partial class SingleSelectButton : UserControl
    {
        public SingleSelectButton()
        {
            InitializeComponent();
        }

        #region 依赖属性
        /// <summary>
        /// 数字
        /// </summary>
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(SingleSelectButton), new PropertyMetadata("", (d, e) =>
            {
                SingleSelectButton td = (SingleSelectButton)d;
                string te = (string)e.NewValue;
                td.NumberImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        /// <summary>
        /// 是否按下
        /// </summary>
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(SingleSelectButton), new PropertyMetadata(false, (d, e) =>
            {
                SingleSelectButton td = (SingleSelectButton)d;
                bool te = (bool)e.NewValue;
                if (te)
                {
                    td.GridOfSingleSelectButton.Style = (Style)td.Resources["PressedEffect"];
                }
                else
                {
                    td.GridOfSingleSelectButton.Style = (Style)td.Resources["NormalEffect"];
                }
            }));
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridOfSingleSelectButtonMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridOfSingleSelectButtonMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标左键点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridOfSingleSelectButtonMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Selected)
            {
                this.Selected = false;
            }
            else
            {
                this.Selected = true;
            }
        }
        #endregion
    }
}
