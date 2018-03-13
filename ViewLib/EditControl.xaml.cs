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
using ViewModelLib.PropertyViewModels;

namespace ViewLib
{
	/// <summary>
	/// Logique d'interaction pour EditControl.xaml
	/// </summary>
	public partial class EditControl : UserControl
	{

		public static readonly DependencyProperty PropertyViewModelCollectionProperty = DependencyProperty.Register("PropertyViewModelCollection", typeof(IPropertyViewModelCollection), typeof(EditControl));
		public IPropertyViewModelCollection PropertyViewModelCollection
		{
			get { return (IPropertyViewModelCollection)GetValue(PropertyViewModelCollectionProperty); }
			set { SetValue(PropertyViewModelCollectionProperty, value); }
		}

		public EditControl()
		{
			InitializeComponent();
		}
	}
}
