using Dominio.Entidades;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Newtonsoft.Json;

namespace FinancasFacil;

public partial class telaCot : ContentPage
{
    private string _shareSymbol;
    private readonly BaseClient _client = new BaseClient();
    public telaCot(String shareSymbol)
	{
        InitializeComponent();
        _shareSymbol = shareSymbol;
        Mostra(_shareSymbol);


    }
    private async Task Mostra(String shareSymbol)
    {
        
            HttpResponseMessage respostaAPI = await _client.GetShare(shareSymbol);
            string conteudo = await respostaAPI.Content.ReadAsStringAsync();
            Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);

           
            Logotipo.Source = acao.Logourl;
            Name.Text = $"{acao.ShortName}";
            Price.Text = $"Valor: {acao.RegularMarketPrice}";
           
        
        }


    }

