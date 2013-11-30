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
    public partial class DataButton : UserControl
    {
        public DataButton()
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
            DependencyProperty.Register("ButtonText", typeof(string), typeof(DataButton), new PropertyMetadata("", (d, e) =>
            {
                DataButton td = (DataButton)d;
                string te = (string)e.NewValue;
                td.ButtonTextImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(DataButton), new PropertyMetadata(false, (d, e) =>
            {
                DataButton td = (DataButton)d;
                bool te = (bool)e.NewValue;
                if (te)
                {
                    td.Bg.Style = (Style)td.Resources["DataButton_SelectedEffect"];
                }
                else
                {
                    td.Bg.Style = null;
                }
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
            if (!Selected)
            {
                Bg.Style = (Style)this.Resources["DataButton_HoverEffect"];
            }
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveAction(object sender, MouseEventArgs e)
        {
            if (!Selected)
            {
                Bg.Style = null;
            }
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeftButtonDownAction(object sender, MouseButtonEventArgs e)
        {
            if (!Selected)
            {
                Selected = true;
            }
        }
        #endregion
    }
}
