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
    public partial class SubPlayTagButton : UserControl
    {
        public SubPlayTagButton()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(SubPlayTagButton), new PropertyMetadata(false, (d, e) =>
            {
                SubPlayTagButton td = (SubPlayTagButton)d;
                bool te = (bool)e.NewValue;
                if (te)
                {
                    td.SubPlayTagImage.Style = (Style)td.Resources["PressedEffect"];
                }
                else
                {
                    td.SubPlayTagImage.Style = (Style)td.Resources["NormalEffect"];
                }
            }));
        /// <summary>
        /// 玩法子标签文本
        /// </summary>
        public string SubPlayTagText
        {
            get { return (string)GetValue(SubPlayTagTextProperty); }
            set { SetValue(SubPlayTagTextProperty, value); }
        }
        public static readonly DependencyProperty SubPlayTagTextProperty =
            DependencyProperty.Register("SubPlayTagText", typeof(string), typeof(SubPlayTagButton), new PropertyMetadata("", (d, e) => 
            {
                SubPlayTagButton td = (SubPlayTagButton)d;
                td.SubPlayTagTextBlock.Text = (string)e.NewValue;
            }));
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubPlayTagGridMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubPlayTagGridMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubPlayTagGridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.Selected)
            {
                this.Selected = true;
            }
        }
        #endregion
    }
}
