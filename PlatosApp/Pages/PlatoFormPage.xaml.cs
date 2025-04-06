using PlatosApp.Helpers;
using PlatosApp.Models;

namespace PlatosApp.Pages;

[QueryProperty(nameof(Plato), "Plato")]
public partial class PlatoFormPage : ContentPage
{
	private readonly IRestClient _restClient;
	private Plato _plato;

	public Plato Plato {
		get => _plato ?? new Plato();
		set
		{
			_plato = value;
            OnPropertyChanged();
		}
	}

	public PlatoFormPage(IRestClient restClient)
	{
		InitializeComponent();
		_restClient = restClient;
        BindingContext = this;
    }

    public async void OnSave(Object sender, EventArgs e)
	{
		if(_plato!.Id == 0)
		{
			await _restClient.AddPlatoAsync(_plato!.ToAddOrModifyPlato());
		}
		else
		{
            await _restClient.UpdatePlatoAsync(_plato!);
        }

        await Shell.Current.GoToAsync("..");
    }

    async void OnDelete(Object sender, EventArgs e)
    {
        await _restClient.DeletePlatoAsync(Plato.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancel(Object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("..");
    }
}