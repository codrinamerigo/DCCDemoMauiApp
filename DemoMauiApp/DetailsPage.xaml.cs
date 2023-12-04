namespace DemoMauiApp;
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(DetailViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }

        
    }


