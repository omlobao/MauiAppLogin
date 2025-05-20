namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Inicia a verificação do usuário logado no contexto correto
            _ = InitializeAppAsync();
        }

        private async Task InitializeAppAsync()
        {
            try
            {
                string? usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                // Define a página inicial baseada na presença de um usuário logado
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    MainPage = usuario_logado == null ? new Login() : new Protegida();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar SecureStorage: {ex.Message}");
                MainThread.BeginInvokeOnMainThread(() => MainPage = new Login()); // Garante que pelo menos a página de Login seja carregada
            }
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600; // Tamanho parecido com o de um smartphone

            return window;
        }
    }
}