

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }


        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow (activationState);

            window.Width = 400;
            window.Height = 600; //tamanho precido com o de um smarthphone

            return window;
        }
    }
}

