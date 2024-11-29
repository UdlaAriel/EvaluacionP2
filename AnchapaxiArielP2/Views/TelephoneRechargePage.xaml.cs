namespace AnchapaxiArielP2.Views;

public partial class TelephoneRechargePage : ContentPage
{
	public TelephoneRechargePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string fileName = "ArielAnchapaxi.txt";

        LoadInformation(Path.Combine(appDataPath, fileName));
    }

    public void LoadInformation(string fileName)
    {
        Models.TelephoneRecharge information = new Models.TelephoneRecharge();
        information.FileName = fileName;

        if (File.Exists(fileName))
        {
            string text = File.ReadAllText(fileName);
            int positionNewLine = text.IndexOf(',');

            if (positionNewLine != -1)
            {
                // Extraer la parte de la cadena antes de "\n"
                IEnumerable<string> strings = text.Split(new char[] { ',' });
                information.TelephoneNumber = strings.First();
                information.Name = strings.Last();
            }
        } 
        else
        {
            information.TelephoneNumber = "0992681681";
            information.Name = "Ariel Anchapaxi";
        }

        BindingContext = information;
    }

    private async void Save_Information(object sender, EventArgs e)
    {
        string appDataPath = FileSystem.AppDataDirectory;
        string fileName = "ArielAnchapaxi.txt";
        string fullFileName = Path.Combine(appDataPath, fileName);

        File.WriteAllText(fullFileName, TextEditorName.Text + "," + TextEditorNumber.Text);
        LoadInformation(fullFileName);

        await DisplayAlert("Alert", "Todo ok ;)", "OK");

        await Navigation.PopToRootAsync();
    }
}