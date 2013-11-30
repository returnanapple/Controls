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

        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnterAction(object sender, MouseEventArgs e)
        {
            GridOfMultiSelectButton.Style = (Style)this.Resources["MultiSelectButton_HoverEffect"];
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveAction(object sender, MouseEventArgs e)
        {
            GridOfMultiSelectButton.Style = (Style)this.Resources["MultiSelectButton_NormalEffect"];
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e)
        {
            GridOfMultiSelectButton.Style = (Style)this.Resources["MultiSelectButton_SelectedEffect"];
        }
        /// <summary>
        /// 鼠标左键松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeftButtonUpAction(object sender, MouseButtonEventArgs e)
        {
            GridOfMultiSelectButton.Style = (Style)this.Resources["MultiSelectButton_HoverEffect"];
        }
        #endregion
    }
}
