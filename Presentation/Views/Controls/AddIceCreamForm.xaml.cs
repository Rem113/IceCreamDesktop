using IceCreamDesktop.Core.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IceCreamDesktop.Presentation.Views.Controls
{
	public partial class AddIceCreamForm : UserControl
	{
		public IceCream NewIceCream { get; set; } = new IceCream();

		public ICommand AddIceCreamCommand
		{
			get { return (ICommand)GetValue(AddIceCreamCommandProperty); }
			set { SetValue(AddIceCreamCommandProperty, value); }
		}

		public bool IsAddingIceCream
		{
			get { return (bool)GetValue(IsAddingIceCreamProperty); }
			set { SetValue(IsAddingIceCreamProperty, value); }
		}

		public string IceCreamNameText
		{
			get { return (string)GetValue(IceCreamNameTextProperty); }
			set { SetValue(IceCreamNameTextProperty, value); }
		}

		public string IceCreamBrandText
		{
			get { return (string)GetValue(IceCreamBrandTextProperty); }
			set { SetValue(IceCreamBrandTextProperty, value); }
		}

		public string IceCreamImageUrlText
		{
			get { return (string)GetValue(IceCreamImageUrlTextProperty); }
			set { SetValue(IceCreamImageUrlTextProperty, value); }
		}

		public static readonly DependencyProperty AddIceCreamCommandProperty =
			DependencyProperty.Register("AddIceCreamCommand", typeof(ICommand), typeof(AddIceCreamForm));

		public static readonly DependencyProperty IsAddingIceCreamProperty =
			DependencyProperty.Register("IsAddingIceCream", typeof(bool), typeof(AddIceCreamForm));

		public static readonly DependencyProperty IceCreamNameTextProperty =
			DependencyProperty.Register("IceCreamNameText", typeof(string), typeof(AddIceCreamForm));

		public static readonly DependencyProperty IceCreamBrandTextProperty =
			DependencyProperty.Register("IceCreamBrandText", typeof(string), typeof(AddIceCreamForm));

		public static readonly DependencyProperty IceCreamImageUrlTextProperty =
			DependencyProperty.Register("IceCreamImageUrlText", typeof(string), typeof(AddIceCreamForm));

		public AddIceCreamForm()
		{
			InitializeComponent();
		}
	}
}