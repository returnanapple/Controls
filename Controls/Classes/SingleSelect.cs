using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Controls.Classes
{
    public class SingleSelect : INotifyPropertyChanged
    {
        #region 私有变量
        private int number;
        private bool selected;
        #endregion

        /// <summary>
        /// 数字
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        /// <summary>
        /// 是否按下
        /// </summary>
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="s"></param>
        public SingleSelect(int n, bool s)
        {
            Number = n;
            Selected = s;
        }
        #region 属性变化通知处理事件
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
