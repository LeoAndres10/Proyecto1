using Proyecto1.Views;

namespace Proyecto1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new TareaMainView());
        }
    }
}
