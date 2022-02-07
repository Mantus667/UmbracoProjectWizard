using ReactiveUI;

namespace UmbracoProjectWizard.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainWindowViewModel()
    {
        Content = new HomeViewModel();
    }

    public ViewModelBase Content
    {
        get => _content ?? new HomeViewModel();
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void ShowHomeView()
    {
        Content = new HomeViewModel();
    }

    public void StartWizard()
    {
        Content = new GeneralInfosViewModel();
    }
}