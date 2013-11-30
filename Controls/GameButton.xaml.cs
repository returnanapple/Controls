﻿using System;
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
    public partial class GameButton : UserControl
    {
        public GameButton()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 按键内容
        /// </summary>
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(GameButton), new PropertyMetadata("十一选五", (d, e) =>
            {
                GameButton td = (GameButton)d;
                string te = (string)e.NewValue;
                td.ImageOfButtonText.Source = new BitmapImage(new Uri(String.Format("Images/{0}_Normal.png", te), UriKind.RelativeOrAbsolute));
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
            DependencyProperty.Register("Selected", typeof(bool), typeof(GameButton), new PropertyMetadata(false, (d, e) =>
            {
                GameButton td = (GameButton)d;
                bool te = (bool)e.NewValue;
                if (te)
                {
                    td.GridOfGameButton.Style = (Style)td.Resources["GameButton_SelectedEffect"];
                    td.ImageOfButtonText.Source = new BitmapImage(new Uri(String.Format("Images/{0}_Hover.png", td.ButtonText), UriKind.RelativeOrAbsolute));
                }
                else
                {
                    td.GridOfGameButton.Style = null;
                    td.ImageOfButtonText.Source = new BitmapImage(new Uri(String.Format("Images/{0}_Normal.png", td.ButtonText), UriKind.RelativeOrAbsolute));
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
                GridOfGameButton.Style = (Style)this.Resources["GameButton_HoverEffect"];
                ImageOfButtonText.Source = new BitmapImage(new Uri(String.Format("Images/{0}_Hover.png", ButtonText), UriKind.RelativeOrAbsolute));
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
                GridOfGameButton.Style = null;
                ImageOfButtonText.Source = new BitmapImage(new Uri(String.Format("Images/{0}_Normal.png", ButtonText), UriKind.RelativeOrAbsolute));
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