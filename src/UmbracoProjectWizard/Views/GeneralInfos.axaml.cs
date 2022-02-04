using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UmbracoProjectWizard.Views
{
    public partial class GeneralInfosView : UserControl
    {
        public GeneralInfosView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
