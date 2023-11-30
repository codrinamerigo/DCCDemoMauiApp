namespace DemoMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MyViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }

        
    }

}
