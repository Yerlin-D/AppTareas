using AppTareas.Model;
using System;
using System.Collections.Generic;

namespace AppTareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tarea : ContentPage
    {
        public Tarea()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                MyCollectionView.ItemsSource = await App.MyDatabase.ReadTarea();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TareaDetail());
        }

        async void EditButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tarea = button?.CommandParameter as TareaModel;
            if (tarea != null)
            {
                await Navigation.PushAsync(new TareaDetail(tarea));
            }
        }

        async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tarea = button?.CommandParameter as TareaModel;
            if (tarea != null)
            {
                bool isConfirmed = await DisplayAlert("Confirme", $"¿Está seguro que quiere eliminar esta tarea {tarea.NombreTarea}?", "Yes", "No");
                if (isConfirmed)
                {
                    await App.MyDatabase.DeleteTarea(tarea);
                    MyCollectionView.ItemsSource = await App.MyDatabase.ReadTarea();
                }
            }
        }
    }
}
