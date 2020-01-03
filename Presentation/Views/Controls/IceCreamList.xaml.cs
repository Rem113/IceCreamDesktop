using IceCreamDesktop.Presentation.ViewModels;
using System.Windows.Controls;

namespace IceCreamDesktop.Presentation.Views.Controls
{
    /// <summary>
    /// Interaction logic for IceCreamList.xaml
    /// </summary>
    public partial class IceCreamList : UserControl
    {
        public IceCreamList()
        {
            var viewModel = new IceCreamViewModel();

            DataContext = viewModel;

            InitializeComponent();
        }
    }
}