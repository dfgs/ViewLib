using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewLib
{
	/// <summary>
	/// Logique d'interaction pour TagView.xaml
	/// </summary>
	public partial class TagView : UserControl
	{



		public static readonly DependencyProperty TagBrushProperty = DependencyProperty.Register("TagBrush", typeof(Brush), typeof(TagView),new PropertyMetadata(Brushes.Red));
		public Brush TagBrush
		{
			get { return (Brush)GetValue(TagBrushProperty); }
			set { SetValue(TagBrushProperty, value); }
		}


		public static readonly DependencyProperty TagContentProperty = DependencyProperty.Register("TagContent", typeof(object), typeof(TagView),new PropertyMetadata("Tag"));
		public object TagContent
		{
			get { return GetValue(TagContentProperty); }
			set { SetValue(TagContentProperty, value); }
		}


		public TagView()
		{
			InitializeComponent();
		}
	}
}
