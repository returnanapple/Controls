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
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(LotteryButton), new PropertyMetadata("重庆时时彩", (d, e) =>
            {
                LotteryButton td = (LotteryButton)d;
                string te = (string)e.NewValue;
                td.TextBlockOfLotteryButton.Text = te;
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
                    td.GridOfLotteryButton.Style = (Style)td.Resources["LotteryButton_SelectedEffect"];
                    td.TextBlockOfLotteryButton.Style = (Style)td.Resources["FontOfLotteryButton_HoverEffect"];
                }
                else
                {
                    td.GridOfLotteryButton.Style = null;
                    td.TextBlockOfLotteryButton.Style = (Style)td.Resources["FontOfLotteryButton_NormalEffect"];
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
                GridOfLotteryButton.Style = (Style)this.Resources["LotteryButton_HoverEffect"];
                TextBlockOfLotteryButton.Style = (Style)this.Resources["FontOfLotteryButton_HoverEffect"];
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
                GridOfLotteryButton.Style = null;
                TextBlockOfLotteryButton.Style = (Style)this.Resources["FontOfLotteryButton_NormalEffect"];
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
