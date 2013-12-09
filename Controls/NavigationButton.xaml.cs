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
    public partial class NavigationButton : RadioButton
    {
        public NavigationButton()
        {
            InitializeComponent();
            this.Style = (Style)this.Resources["NewRadioButtonStyle"];
        }
        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            normalImage = (Image)GetTemplateChild("ImageOfNormal");
            pressedImage = (Image)GetTemplateChild("ImageOfPressed");
            checkedImage = (Image)GetTemplateChild("ImageOfChecked");
            normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", Text), UriKind.RelativeOrAbsolute));
            pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", Text), UriKind.RelativeOrAbsolute));
            checkedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Checked.png", Text), UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region 私有变量
        Image normalImage;
        Image pressedImage;
        Image checkedImage;
        #endregion

        #region 依赖属性
        /// <summary>
        /// 按键文本
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavigationButton), new PropertyMetadata("", (d, e) =>
            {
                NavigationButton td = (NavigationButton)d;
                string te = (string)e.NewValue;
                if (td.normalImage != null && td.pressedImage != null && td.checkedImage != null)
                {
                    td.normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", te), UriKind.RelativeOrAbsolute));
                    td.pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", te), UriKind.RelativeOrAbsolute));
                    td.checkedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Checked.png", te), UriKind.RelativeOrAbsolute));
                }
            }));
        #endregion
    }
}
