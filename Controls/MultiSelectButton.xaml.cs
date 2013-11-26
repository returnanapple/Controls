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
    public partial class MultiSelectButton : UserControl
    {
        public MultiSelectButton()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 约束条件(全、大、小、单、双、清)
        /// </summary>
        public string MultiSelectText
        {
            get { return (string)GetValue(MultiSelectTextProperty); }
            set { SetValue(MultiSelectTextProperty, value); }
        }
        public static readonly DependencyProperty MultiSelectTextProperty =
            DependencyProperty.Register("MultiSelectText", typeof(string), typeof(MultiSelectButton), new PropertyMetadata("", (d, e) =>
            {
                MultiSelectButton td = (MultiSelectButton)d;
                string te = (string)e.NewValue;
                td.MultiSelectImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        #endregion

        public event EventHandler ActionOfLeftButtonDown;

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoverMouseEnter(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseEnterEffect"] as Storyboard).Begin();
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoverMouseLeave(object sender, MouseEventArgs e)
        {
            (this.Resources["MouseLeaveEffect"] as Storyboard).Begin();
            GridOfMultiSelectButton.Style = (Style)this.Resources["NormalEffect"];
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoverMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ActionOfLeftButtonDown != null)
            {
                ActionOfLeftButtonDown(this, new EventArgs());
            }
            GridOfMultiSelectButton.Style = (Style)this.Resources["PressedEffect"];
        }
        /// <summary>
        /// 鼠标左键弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoverMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridOfMultiSelectButton.Style = (Style)this.Resources["NormalEffect"];
        }
        #endregion
    }
}
