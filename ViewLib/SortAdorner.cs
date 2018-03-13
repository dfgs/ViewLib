using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ViewLib
{
	public class SortAdorner : Adorner
	{
		private static Geometry up = Geometry.Parse("M 0,8 8,8 4,0 0,8");
		private static Geometry down = Geometry.Parse("M 0,0 4,8 8,0 0,0");
		private Geometry direction;
		private static Brush brush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
		private static Pen pen =new Pen( new SolidColorBrush(Color.FromArgb(128, 255, 255, 255)),1);

		public SortAdorner(GridViewColumnHeader AdornedElement, ListSortDirection SortDirection)
			: base(AdornedElement)
		{
			direction = SortDirection == ListSortDirection.Ascending ? up : down;
		}

		protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
		{
			double x = AdornedElement.RenderSize.Width - 12;
			double y = (AdornedElement.RenderSize.Height - 8) / 2;

			if (x >= 10)
			{
				// Right order of the statements is important
				drawingContext.PushTransform(new TranslateTransform(x, y));
				drawingContext.DrawGeometry(brush, pen, direction);
				drawingContext.Pop();
			}
		}
	}
}
