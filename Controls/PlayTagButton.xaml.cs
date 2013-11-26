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
    public partial class PlayTagButton : UserControl
    {
        public PlayTagButton()
        {
            InitializeComponent();
        }

        #region 依赖属性
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(PlayTagButton), new PropertyMetadata(false, (d, e) =>
            {
                PlayTagButton td = (PlayTagButton)d;
                bool te = (bool)e.NewValue;
                if (te)
                {
                    td.PlayTagGrid.Style = (Style)td.Resources["PressedEffect"];
                    td.PlayTagTextBlock.Style = (Style)td.Resources["TextBlockPressedEffect"];
                }
                else
                {
                    td.PlayTagGrid.Style = null;
                    td.PlayTagTextBlock.Style = (Style)td.Resources["TextBlockNormalEffect"]; ;
                }
            }));
        /// <summary>
        /// 玩法标签文本
        /// </summary>
        public string PlayTagText
        {
            get { return (string)GetValue(PlayTagTextProperty); }
            set { SetValue(PlayTagTextProperty, value); }
        }
        public static readonly DependencyProperty PlayTagTextProperty =
            DependencyProperty.Register("PlayTagText", typeof(string), typeof(PlayTagButton), new PropertyMetadata("", (d, e) =>
            {
                PlayTagButton td = (PlayTagButton)d;
                td.PlayTagTextBlock.Text = (string)e.NewValue;
            }));
        #endregion
        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayTagTextBlockMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayTagTextBlockMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayTagTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.Selected)
            {
                this.Selected = true;
            }
        }
        #endregion
    }
}
