using DemoMauiApp.Services;

namespace DemoMauiApp.ViewModel;

public partial class MyViewModel : BaseViewModel
{
    public ObservableCollection<MyModel> Groceries { get; } = new();
    MyServices myService;
    IConnectivity connectivity;
    IGeolocation geolocation;
    public MyViewModel(MyServices myService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "My Groceries";
        this.myService = myService;
        this.connectivity = connectivity;
        //this.geolocation = geolocation;
    }

    [RelayCommand]
    async Task GoToDetails(MyModel myModel)
    {
        if (myModel == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailsPage));
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetGroceriesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            IsBusy = true;
            var items = await myService.GetGroceries();

            if (items.Count != 0)
                Groceries.Clear();

            foreach (var item in items)
                Groceries.Add(item);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get your groceries: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }


  

    [RelayCommand]
    async Task GetClosest()
    {
        if (IsBusy || Groceries.Count == 0)
            return;

        /*try
        {
            // Get cached location, else get real location.
            var location = await geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }

            // Find closest 
            var first = Groceries.OrderBy(m => location.CalculateDistance(
                new Location(m.Latitude, m.Longitude), DistanceUnits.Miles))
                .FirstOrDefault();

            await Shell.Current.DisplayAlert("", first.Name + " " +
                first.Location, "OK");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to query location: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }*/
    }
}
