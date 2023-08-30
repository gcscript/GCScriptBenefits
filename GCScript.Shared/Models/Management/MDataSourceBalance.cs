
using System.Text.Json.Serialization;

namespace GCScript.Shared.Models.Management;

public class MDataSourceBalance
{
    [JsonPropertyName("uf")]
    public string? UF { get; set; }

    [JsonPropertyName("operadora")]
    public string? Operadora { get; set; }

    [JsonPropertyName("empresa")]
    public string? Empresa { get; set; }

    [JsonPropertyName("unidade")]
    public string? Unidade { get; set; }

    [JsonPropertyName("matricula")]
    public string? Matricula { get; set; }

    [JsonPropertyName("nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("cpf")]
    public string? CPF { get; set; }

    [JsonPropertyName("nr_cartao")]
    public string? NumeroDoCartao { get; set; }

    [JsonPropertyName("saldo")]
    public decimal Saldo { get; set; }

    [JsonPropertyName("data_saldo")]
    public DateTime? DataSaldo { get; set; }

    [JsonPropertyName("recarga_pendente")]
    public decimal RecargaPendente { get; set; }

    [JsonPropertyName("data_recarga_pendente")]
    public DateTime? DataRecargaPendente { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("status_bu")]
    public string? StatusBU { get; set; }

    [JsonPropertyName("compra_pir")]
    public string? CompraPIR { get; set; }
}
