namespace MauiAppLogin;

// Declara��o da classe Login, que representa uma p�gina de conte�do na aplica��o MAUI
public partial class Login : ContentPage
{
    // Construtor da classe Login
    public Login()
    {
        InitializeComponent(); // Inicializa os componentes da interface gr�fica da p�gina
    }

    // M�todo acionado quando o bot�o � clicado
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria��o de uma lista com usu�rios fict�cios para simular um banco de dados
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
            {
                new DadosUsuario()
                {
                    Usuario = "jose",
                    Senha = "123"
                },
                new DadosUsuario()
                {
                    Usuario = "maria",
                    Senha = "321"
                }
            };

            // Captura os dados digitados pelo usu�rio nos campos de entrada da interface
            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txt_usuario.Text, // Obt�m o texto do campo de usu�rio
                Senha = txt_senha.Text // Obt�m o texto do campo de senha
            };

            // Verifica se os dados digitados correspondem a algum usu�rio na lista
            if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("Usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protegida();

            } else
            {
                throw new Exception("Usu�rio ou senha incorretos.");

            }
        }
        catch (Exception ex)
        {
            // Exibe um alerta informando que os dados est�o incorretos
            await DisplayAlert("Erro.", ex.Message, "Fechar");

            // Limpa os campos de entrada ap�s o erro
            txt_usuario.Text = string.Empty;
            txt_senha.Text = string.Empty;
        }
    }
}