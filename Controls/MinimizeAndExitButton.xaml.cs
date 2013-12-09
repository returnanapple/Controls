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
    public partial class MinimizeAndExitButton : Button
    {
        public MinimizeAndExitButton()
        {
            InitializeComponent();
            this.Style = (Style)this.Resources["NewButtonStyle"];
        }

        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            textImage = (Image)GetTemplateChild("ImageOfText");
            normalImage = (Image)GetTemplateChild("ImageOfNormal");
            pressedImage = (Image)GetTemplateChild("ImageOfPressed");
            textImage.Source = new BitmapImage(new Uri("Images/MinimizeAndExitButton_Bg.png", UriKind.RelativeOrAbsolute));
            normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", Text), UriKind.RelativeOrAbsolute));
            pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", Text), UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region 私有变量
        Image textImage;
        Image normalImage;
        Image pressedImage;
        #endregion

        #region 依赖属性


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MinimizeAndExitButton), new PropertyMetadata("", (d, e) =>
            {
                MinimizeAndExitButton td = (MinimizeAndExitButton)d;
                string te = (string)e.NewValue;
                if (td.normalImage != null && td.pressedImage != null)
                {
                    td.normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", te), UriKind.RelativeOrAbsolute));
                    td.pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", te), UriKind.RelativeOrAbsolute));
                }
            }));


        #endregion

    }
}
