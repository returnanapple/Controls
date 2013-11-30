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
    public partial class ConfirmBetButton : UserControl
    {
        public ConfirmBetButton()
        {
            InitializeComponent();
        }
        #region 鼠标事件
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnterAction(object sender, MouseEventArgs e)
        {
            ImageOfConfirmBetButton.Style = (Style)this.Resources["ConfirmBetButton_HoverEffect"];
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveAction(object sender, MouseEventArgs e)
        {
            ImageOfConfirmBetButton.Style = (Style)this.Resources["ConfirmBetButton_NormalEffect"];
        }
        #endregion
    }
}
