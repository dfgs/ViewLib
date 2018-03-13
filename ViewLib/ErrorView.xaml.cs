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
using ViewModelLib;

namespace ViewLib
{
	/// <summary>
	/// Logique d'interaction pour ErrorView.xaml
	/// </summary>
	public partial class ErrorView : UserControl
	{
		public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register("ErrorMessage", typeof(string), typeof(ErrorView),new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		public string ErrorMessage
		{
			get { return (string)GetValue(ErrorMessageProperty); }
			set { SetValue(ErrorMessageProperty, value); }
		}


		public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand", typeof(ViewModelCommand), typeof(ErrorView));
		public ViewModelCommand CloseCommand
		{
			get { return (ViewModelCommand)GetValue(CloseCommandProperty); }
			private set { SetValue(CloseCommandProperty, value); }
		}


		public ErrorView()
		{
			InitializeComponent();

			CloseCommand = new ViewModelCommand(CloseCommandCanExecute, CloseCommandExecute);
		}

		private bool CloseCommandCanExecute(object arg)
		{
			return true;
		}

		private void CloseCommandExecute(object obj)
		{
			ErrorMessage = null;
		}


		

		



	}
}
