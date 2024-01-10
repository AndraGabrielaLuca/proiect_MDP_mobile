using proiect_MDP_mobile.Models;

namespace proiect_MDP_mobile;

public partial class DestinatiePage : ContentPage
{
    Itinerar sl;
    public DestinatiePage(Itinerar slist)
	{
		InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var destinatie = (Destinatie)BindingContext;
        await App.Database.SaveProductAsync(destinatie);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var destinatie = (Destinatie)BindingContext;
        await App.Database.DeleteProductAsync(destinatie);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Destinatie p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Destinatie;

            var lp = new ListaDestinatie()
            {
                ItinerarID = sl.ID,
                DestinatieID = p.ID
            };
            await App.Database.SaveListProductAsync(lp);
            p.ListaDestinatii = new List<ListaDestinatie> { lp };
            await Navigation.PopAsync();
        }
    }
}