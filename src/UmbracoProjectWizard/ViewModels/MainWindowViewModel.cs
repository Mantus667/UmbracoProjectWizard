using ReactiveUI;

namespace UmbracoProjectWizard.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;

#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    public MainWindowViewModel()
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    {
        Content = new HomeViewModel();
    }

    public ViewModelBase Content
    {
        get => _content;
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