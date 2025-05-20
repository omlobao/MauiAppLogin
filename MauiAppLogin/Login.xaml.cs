namespace MauiAppLogin;

// Declaração da classe Login, que representa uma página de conteúdo na aplicação MAUI
public partial class Login : ContentPage
{
    // Construtor da classe Login
    public Login()
    {
        InitializeComponent(); // Inicializa os componentes da interface gráfica da página
    }

    // Método acionado quando o botão é clicado
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Criação de uma lista com usuários fictícios para simular um banco de dados
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

            // Captura os dados digitados pelo usuário nos campos de entrada da interface
            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txt_usuario.Text, // Obtém o texto do campo de usuário
                Senha = txt_senha.Text // Obtém o texto do campo de senha
            };

            // Verifica se os dados digitados correspondem a algum usuário na lista
            if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("Usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protegida();

            } else
            {
                throw new Exception("Usuário ou senha incorretos.");

            }
        }
        catch (Exception ex)
        {
            // Exibe um alerta informando que os dados estão incorretos
            await DisplayAlert("Erro.", ex.Message, "Fechar");

            // Limpa os campos de entrada após o erro
            txt_usuario.Text = string.Empty;
            txt_senha.Text = string.Empty;
        }
    }
}