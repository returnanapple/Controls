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
    public partial class DataButton : UserControl
    {
        public DataButton()
        {
            InitializeComponent();
        }

        #region 依赖属性
        /// <summary>
        /// 数据管理选项图片路径
        /// </summary>
        public string DataImagePath
        {
            get { return (string)GetValue(DataImagePathProperty); }
            set { SetValue(DataImagePathProperty, value); }
        }
        public static readonly DependencyProperty DataImagePathProperty =
            DependencyProperty.Register("DataImagePath", typeof(string), typeof(DataButton), new PropertyMetadata(""));
        /// <summary>
        /// 已选择的数据管理选项图片路径
        /// </summary>
        public string DataImagePathOfSelected
        {
            get { return (string)GetValue(DataImagePathOfSelectedProperty); }
            set { SetValue(DataImagePathOfSelectedProperty, value); }
        }
        public static readonly DependencyProperty DataImagePathOfSelectedProperty =
            DependencyProperty.Register("DataImagePathOfSelected", typeof(string), typeof(DataButton), new PropertyMetadata(""));
        /// <summary>
        /// 选中
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
                    td.DataImage.Opacity = 0;
                    td.DataImageOfSelected.Opacity = 1;
                }
                else
                {
                    td.DataImage.Opacity = 1;
                    td.DataImageOfSelected.Opacity = 0;
                }
            }));
        #endregion

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
        }
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoverMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.Selected)
            {
                this.Selected = true;
            }
        }
        #endregion
    }
}
