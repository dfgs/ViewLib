using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using ViewModelLib.PropertyViewModels;

namespace ViewLib
{
	public class AllowedValuesExtension : MarkupExtension
	{
		

		public AllowedValuesExtension()
		{
		}
		

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			PropertyViewModel propertyViewModel;

			IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

			if (target == null) return null;

			FrameworkElement targetObject = target.TargetObject as FrameworkElement;

			if (targetObject == null) return this;

			propertyViewModel = targetObject.DataContext as PropertyViewModel;
			if (propertyViewModel?.AllowedValuesPath == null) return null;

			DependencyProperty targetProperty = (DependencyProperty)target.TargetProperty;

			Binding binding = new Binding() { Path = new PropertyPath(propertyViewModel.AllowedValuesPath), Source=propertyViewModel.DataContext};

			BindingOperations.SetBinding(targetObject, targetProperty, binding);
			
			return binding.ProvideValue(serviceProvider);


		}
	}

}
