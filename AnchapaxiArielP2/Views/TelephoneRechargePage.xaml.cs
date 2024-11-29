namespace AnchapaxiArielP2.Views;

public partial class TelephoneRechargePage : ContentPage
{
	public TelephoneRechargePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.txt";

        LoadInformation(Path.Combine(appDataPath, randomFileName));
    }

    public void LoadInformation(string fileName)
    {
        Models.TelephoneRecharge information = new Models.TelephoneRecharge();
        information.FileName = fileName;

        if (File.Exists(fileName))
        {
            information.Name = File.ReadAllText(fileName);
            information.TelephoneNumber = File.ReadAllText(fileName);
        }

        BindingContext = information;
    }

    private async void Save_Information(object sender, EventArgs e)
    {
        if (BindingContext is Models.TelephoneRecharge information)
            File.WriteAllText(information.FileName, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }
}