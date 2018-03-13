using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace ViewLib
{
	public class Sorter
	{
		private ListSortDirection direction;
		private GridViewColumnHeader column;

		private string SetAdorner(object columnHeader)
		{
			GridViewColumnHeader column = columnHeader as GridViewColumnHeader;
			if ((column == null) || (column.Column==null)) return null;


			// Remove arrow from previously sorted header
			if (this.column != null)
			{
				var adornerLayer = AdornerLayer.GetAdornerLayer(this.column);
				try { adornerLayer.Remove((adornerLayer.GetAdorners(this.column))[0]); }
				catch { }
			}

			if (this.column == column)
			{
				// Toggle sorting direction
				direction = direction == ListSortDirection.Ascending ?ListSortDirection.Descending :ListSortDirection.Ascending;
			}
			else
			{
				this.column = column;
				direction = ListSortDirection.Ascending;
			}

			var sortingAdorner = new SortAdorner(column, direction);
			AdornerLayer.GetAdornerLayer(column).Add(sortingAdorner);

			string header = string.Empty;

			// if binding is used and property name doesn't match header content
			Binding b = this.column.Column.DisplayMemberBinding as Binding;
			if (b != null) header = b.Path.Path;
			else header = ViewLib.Sort.GetBy(column.Column);

			return header;
		}

		public void Sort(object columnHeader, System.Windows.Data.CollectionView list)
		{
			string column = SetAdorner(columnHeader);
			if (string.IsNullOrEmpty(column )) return;

			list.SortDescriptions.Clear();
			list.SortDescriptions.Add(new SortDescription(column, direction));
		}
	}

}
