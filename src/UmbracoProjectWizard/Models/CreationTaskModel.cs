namespace UmbracoProjectWizard.Models;

using ReactiveUI;

public class CreationTaskModel : ReactiveObject
{
    public CreationTaskModel(string taskName) => TaskName = taskName;

    private int _value;
    public int Value
    {
        get => _value;
        set
        {
            this.RaiseAndSetIfChanged(ref _value, value);
            this.RaisePropertyChanged(nameof(IsFinished));
        }
    }
    public string TaskName { get; init; }
    public bool IsFinished => Value == 100 && !IsRunning;
    private bool _isRunning;
    public bool IsRunning
    {
        get => _isRunning;
        set
        {
            this.RaiseAndSetIfChanged(ref _isRunning, value);
            this.RaisePropertyChanged(nameof(IsFinished));
        }
    }
}
