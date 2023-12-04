namespace DemoMauiApp.ViewModel;

[QueryProperty(nameof(MyModel), "MyModel")]
public partial class DetailViewModel: BaseViewModel
    {

        [ObservableProperty]
        MyModel myModel;

    }

