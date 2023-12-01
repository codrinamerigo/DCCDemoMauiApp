namespace DemoMauiApp;
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(MyViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }

        
    }


