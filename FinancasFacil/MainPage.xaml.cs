using Dominio.Entidades;
using Integracao;
using Newtonsoft.Json;
namespace FinancasFacil
{
    public partial class MainPage : ContentPage
    {
        
        private readonly BaseClient _client = new BaseClient();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CliqueMandas(object sender, EventArgs e)
        {
            string simboloAcao = campoSimbolo.Text;
            telaCot shareDetails = new telaCot(simboloAcao);
            telaCot newPage = new telaCot(simboloAcao);
            await Navigation.PushAsync(newPage);
            SemanticScreenReader.Announce(simboloAcao);
            
        }
    }

}
