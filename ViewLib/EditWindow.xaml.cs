﻿using System;
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
using System.Windows.Shapes;

namespace ViewLib
{
	/// <summary>
	/// Logique d'interaction pour EditWindow.xaml
	/// </summary>
	public partial class EditWindow : Window
	{
		public EditWindow()
		{
			InitializeComponent();
		}

		private void OKCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true; e.Handled = true;

		}

		private void OKCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			DialogResult = true;

		}

		private void CancelCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;e.Handled = true;
		}

		private void CancelCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			DialogResult = false;
		}

		

	}
}
