using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ViewLib
{
	public class Sort
	{
		private static IDictionary<ListView, Sorter> sorting;

		public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(Boolean), typeof(Sort), new PropertyMetadata(false, OnIsEnabledPropertyChanged));
		public static readonly DependencyProperty ByProperty = DependencyProperty.RegisterAttached("By", typeof(string), typeof(Sort));

		static Sort()
		{
			sorting = new Dictionary<ListView, Sorter>();
		}

		public static string GetBy(GridViewColumn element)
		{
			return (string)element.GetValue(ByProperty);
		}

		public static void SetBy(GridViewColumn element, string value)
		{
			element.SetValue(ByProperty, value);
		}

		public static bool GetIsEnabled(ListView element)
		{
			return (bool)element.GetValue(IsEnabledProperty);
		}

		public static void SetIsEnabled(ListView element, Boolean value)
		{
			element.SetValue(IsEnabledProperty, value);
		}

		private static void OnIsEnabledPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
		{
			ListView listView = d as ListView;

			if (listView != null)
			{
				if (e.NewValue is bool)
				{
					if ((bool)e.NewValue)
					{
						listView.AddHandler(GridViewColumnHeader.ClickEvent,new RoutedEventHandler(OnColumnHeaderClicked));
						sorting.Add(listView, new Sorter());
					}
					else
					{
						listView.RemoveHandler(GridViewColumnHeader.ClickEvent,new RoutedEventHandler(OnColumnHeaderClicked));
						sorting.Remove(listView);
					}
				}
			}
		}

		private static void OnColumnHeaderClicked(object sender, RoutedEventArgs e)
		{
			ListView listView = sender as ListView;
			if (listView == null) return;
			var sorter = sorting[listView];
			sorter.Sort(e.OriginalSource, listView.Items);
		}
	}

}
