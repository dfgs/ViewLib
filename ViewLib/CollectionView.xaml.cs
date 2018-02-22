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
using ViewModelLib.PropertyViewModels;

namespace ViewLib
{
	/// <summary>
	/// Logique d'interaction pour CollectionView.xaml
	/// </summary>
	public partial class CollectionView : UserControl
	{


		public static readonly DependencyProperty ShowRemoveDialogProperty = DependencyProperty.Register("ShowRemoveDialog", typeof(bool), typeof(CollectionView),new PropertyMetadata(true));
		public bool ShowRemoveDialog
		{
			get { return (bool)GetValue(ShowRemoveDialogProperty); }
			set { SetValue(ShowRemoveDialogProperty, value); }
		}


		public static readonly DependencyProperty ViewModelCollectionProperty = DependencyProperty.Register("ViewModelCollection", typeof(IViewModelCollection), typeof(CollectionView));
		public IViewModelCollection ViewModelCollection
		{
			get { return (IViewModelCollection)GetValue(ViewModelCollectionProperty); }
			set { SetValue(ViewModelCollectionProperty, value); }
		}

		public CollectionView()
		{
			InitializeComponent();
		}

		private bool OnEditViewModel(IEnumerable<PropertyViewModel> Properties)
		{
			EditWindow editWindow;

			editWindow = new EditWindow() { Owner = Application.Current.MainWindow, DataContext = Properties };
			return editWindow.ShowDialog() ?? false;
		}

		private bool OnRemoveViewModel(IEnumerable<PropertyViewModel> Properties)
		{
			if (!ShowRemoveDialog) return true;
			return MessageBox.Show(Application.Current.MainWindow, "Do you want to delete this item(s)", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes;
		}


		private void AddCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.Handled = true; e.CanExecute = ViewModelCollection?.CanAdd() ?? false;
		}

		private async void AddCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			try
			{
				await ViewModelCollection.AddAsync(OnEditViewModel);
			}
			catch
			{
				ViewModelCollection.ErrorMessage = "Failed to add item";
			}
		}

		private void RemoveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.Handled = true; e.CanExecute = ViewModelCollection?.CanRemove() ?? false;
		}

		private async void RemoveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			try
			{
				await ViewModelCollection.RemoveAsync(OnRemoveViewModel);
			}
			catch
			{
				ViewModelCollection.ErrorMessage = "Failed to remove item";
			}
		}

		private void EditCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.Handled = true; e.CanExecute = ViewModelCollection?.CanEdit() ?? false;
		}

		private async void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			try
			{
				await ViewModelCollection.EditAsync(OnEditViewModel);
			}
			catch
			{
				ViewModelCollection.ErrorMessage = "Failed to edit item";
			}
		}

		private async void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (ViewModelCollection?.CanEdit() ?? false) await ViewModelCollection.EditAsync(OnEditViewModel);
			}
			catch
			{
				ViewModelCollection.ErrorMessage = "Failed to edit item";
			}
		}

	}
}
