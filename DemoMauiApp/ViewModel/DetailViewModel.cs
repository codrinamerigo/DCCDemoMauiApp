using DemoMauiApp.ViewModel;

namespace DemoMauiApp.DetailViewModel;

[QueryProperty(nameof(MyModel), "myItem")]
public partial class DetailViewModel: BaseViewModel
    {

        [ObservableProperty]
        MyModel myItem;

    }

