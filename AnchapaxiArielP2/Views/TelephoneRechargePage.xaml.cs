namespace AnchapaxiArielP2.Views;

public partial class TelephoneRechargePage : ContentPage
{
	public TelephoneRechargePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = "ArielAnchapaxi.txt";

        LoadInformation(Path.Combine(appDataPath, randomFileName));
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
        string randomFileName = "ArielAnchapaxi.txt";
        
        File.WriteAllText(appDataPath+randomFileName, TextEditorName.Text + "," + TextEditorNumber.Text);

        await Navigation.PopToRootAsync();
    }
}