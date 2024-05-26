namespace AppTareas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnNavigateToTarea(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tarea());
        }
    }

}
