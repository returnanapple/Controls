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
    public partial class TableTool : ItemsControl
    {
        public TableTool()
        {
            InitializeComponent();
        }
        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            tableHead = (StackPanel)GetTemplateChild("HeadOfTable");
            table = (Grid)GetTemplateChild("Table");
            if (TableInfo != "")
            {
                Paint(TableInfo, tableHead, table);
            }
        }
        #endregion

        #region 私有变量
        StackPanel tableHead;
        Grid table;
        #endregion

        #region 依赖属性
        public string TableInfo
        {
            get { return (string)GetValue(TableInfoProperty); }
            set { SetValue(TableInfoProperty, value); }
        }
        public static readonly DependencyProperty TableInfoProperty =
            DependencyProperty.Register("TableInfo", typeof(string), typeof(TableTool), new PropertyMetadata("", (d, e) =>
            {
                TableTool td = (TableTool)d;
                string te = (string)e.NewValue;
                if (td.tableHead != null && td.table != null)
                {
                    td.Paint(te, td.tableHead, td.table);
                }
            }));
        #endregion

        #region 函数
        private void Paint(string ti, StackPanel th, Grid t)
        {
            th.Children.Clear();
            t.Children.ToList().ForEach(x =>
            {
                if (x.GetType() == typeof(Rectangle))
                {
                    t.Children.Remove(x);
                }
            });
            List<string> sl = ti.Split(new char[] { '|' }).ToList();
            sl.ForEach(x =>
            {
                List<string> sl2 = x.Split(new char[] { ',' }).ToList();
                th.Children.Add(new TextBlock { Text = sl2[0], Width = Convert.ToDouble(sl2[1]), Style = (Style)this.Resources["FontStyleOfTittle"] });
            });
            double w = 0;
            for (int i = 0; i < sl.Count - 1; i++)
            {
                List<string> sl2 = sl[i].Split(new char[] { ',' }).ToList();
                w = w + Convert.ToDouble(sl2[1]);
                Rectangle r = new Rectangle();
                r.SetValue(Grid.RowProperty, 0);
                r.SetValue(Grid.RowSpanProperty, 2);
                r.Margin = new Thickness(w, 0, this.Width-w-1, 0);
                r.Style = (Style)this.Resources["StyleOfRectangle"];
                t.Children.Add(r);
            }
        }
        #endregion
    }
}
