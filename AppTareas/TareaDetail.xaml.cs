using AppTareas.Model;
using System.Threading.Tasks;

namespace AppTareas
{
    public partial class TareaDetail : ContentPage
    {
        private TareaModel _tarea;

        public TareaDetail(TareaModel tarea = null)
        {
            InitializeComponent();
            if (tarea != null)
            {
                _tarea = tarea;
                NombreTareaEntry.Text = tarea.NombreTarea;
                DescripcionEntry.Text = tarea.Description;
            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreTareaEntry.Text))
            {
                await DisplayAlert("Inválido", "Espacio en blanco es inválido", "Ok");
            }
            else
            {
                await SaveTarea();
            }
        }

        async Task SaveTarea()
        {
            if (_tarea == null)
            {
                _tarea = new TareaModel();
            }
            _tarea.NombreTarea = NombreTareaEntry.Text;
            _tarea.Description = DescripcionEntry.Text;

            if (_tarea.Id == 0)
            {
                await App.MyDatabase.CreateTarea(_tarea);
            }
            else
            {
                await App.MyDatabase.UpdateTarea(_tarea);
            }

            await Navigation.PopAsync();
        }
    }
}
