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
    public partial class TableTool : UserControl
    {
        public TableTool()
        {
            InitializeComponent();
        }

        #region 依赖属性
        /// <summary>
        /// 表格信息
        /// </summary>
        public string InfoOfTable
        {
            get { return (string)GetValue(InfoOfTableProperty); }
            set { SetValue(InfoOfTableProperty, value); }
        }
        public static readonly DependencyProperty InfoOfTableProperty =
            DependencyProperty.Register("InfoOfTable", typeof(string), typeof(TableTool), new PropertyMetadata("", (d, e) =>
            {
                TableTool td = (TableTool)d;
                string te = (string)e.NewValue;
                List<string> sl = te.Split(new char[] { '|' }).ToList();
                td.TableHead.Children.Clear();
                double w = 0;
                sl.ForEach(x =>
                {
                    List<string> sl2 = x.Split(new char[] { ',' }).ToList();
                    td.TableHead.Children.Add(new TextBlock { Text = sl2[0], Width = Convert.ToDouble(sl2[1]), Style = (Style)td.Resources["FontStyleOfTableHead"] });
                });
                double lineLocation = 0;
                for (int i = 0; i < sl.Count - 1; i++)
                {
                    List<string> sl2 = sl[i].Split(new char[] { ',' }).ToList();
                    lineLocation = lineLocation + Convert.ToDouble(sl2[1]);
                    Rectangle r = new Rectangle();
                    r.Style = (Style)td.Resources["LineStyle"];
                    r.Margin = new Thickness(lineLocation - 1, 0, td.Width - lineLocation, 1);
                    r.SetValue(Grid.RowProperty, 1);
                    td.Table.Children.Add(r);
                }
            }));
        /// <summary>
        /// 行模版
        /// </summary>
        public DataTemplate RowTemplate
        {
            get { return (DataTemplate)GetValue(RowTemplateProperty); }
            set { SetValue(RowTemplateProperty, value); }
        }
        public static readonly DependencyProperty RowTemplateProperty =
            DependencyProperty.Register("RowTemplate", typeof(DataTemplate), typeof(TableTool), new PropertyMetadata(null, (d, e) =>
            {
                TableTool td = (TableTool)d;
                DataTemplate te = (DataTemplate)e.NewValue;
                td.TableBody.ItemTemplate = te;
            }));
        /// <summary>
        /// 所有内容
        /// </summary>
        public IEnumerable<object> RowsSource
        {
            get { return (IEnumerable<object>)GetValue(RowsSourceProperty); }
            set { SetValue(RowsSourceProperty, value); }
        }
        public static readonly DependencyProperty RowsSourceProperty =
            DependencyProperty.Register("RowsSource", typeof(IEnumerable<object>), typeof(TableTool), new PropertyMetadata(null, (d, e) =>
            {
                TableTool td = (TableTool)d;
                td.TableBody.Items.Clear();
                td.TableBody.ItemsSource = (IEnumerable<object>)e.NewValue;
            }));
        #endregion

    }
}
