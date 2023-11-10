namespace GCScript.Shared.Models;

public class MRiocardBalance
{
    public string Cnpj { get; set; }
    public string Empresa { get; set; }
    public string Buscador { get; set; }
    public string NumeroDoCartao { get; set; }
    public string Matricula { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Status { get; set; }
    public decimal Saldo { get; set; }
    public DateTime AttSaldo { get; set; }
    public decimal RecargaPendente { get; set; }
    public DateTime DataPagamentoRecargaPendente { get; set; }
}
