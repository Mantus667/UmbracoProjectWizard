namespace UmbracoProjectWizard.Services;

public interface IWizardContextProvider
{
    void CreateWizardContext();
    WizardContext? GetWizardContext();
    void ClearContext();
}

internal class WizardContextProvider : IWizardContextProvider
{
    private WizardContext? _wizardContext;

    public void ClearContext() => _wizardContext = null;
    public void CreateWizardContext() => _wizardContext = new WizardContext();
    public WizardContext? GetWizardContext() => _wizardContext;
}
