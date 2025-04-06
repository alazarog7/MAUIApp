using PlatosApp.Helpers;
using PlatosApp.Models;
using PlatosApp.Pages;
using System.Diagnostics;

namespace PlatosApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestClient _restClient;

        public MainPage(){}

        public MainPage(IRestClient restClient)
        {
            InitializeComponent();
            _restClient = restClient;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            platosCollection.ItemsSource = await _restClient.GetPlatos();
        }

        async void OnAddPlatoAsync(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>
            {
                { nameof(Plato), new Plato()}
            };

            await Shell.Current.GoToAsync(nameof(PlatoFormPage), parameters);
        }

        async void OnChangePlato(object sender, SelectionChangedEventArgs e)
        {
            var param = new Dictionary<string, object>() {
                { nameof(Plato), e.CurrentSelection.FirstOrDefault() as Plato}
            };
            await Shell.Current.GoToAsync(nameof(PlatoFormPage), param);
        }
    }

}
