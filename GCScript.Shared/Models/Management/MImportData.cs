using System.Text.Json.Serialization;

namespace GCScript.Shared.Models.Management;

public class MImportData
{
    [JsonPropertyName("ArquivoDeCompra")]
    public string? ArquivoDeCompra { get; set; }

    [JsonPropertyName("Cnpj")]
    public string? CNPJ { get; set; }

    [JsonPropertyName("Uf")]
    public string? UF { get; set; }

    [JsonPropertyName("Operadora")]
    public string? Operadora { get; set; }

    [JsonPropertyName("Empresa")]
    public string? Empresa { get; set; }

    [JsonPropertyName("CUnid")]
    public string? Unidade { get; set; }

    [JsonPropertyName("CDepto")]
    public string? Departamento { get; set; }

    [JsonPropertyName("Escala")]
    public string? Escala { get; set; }

    [JsonPropertyName("Id")]
    public string? ID { get; set; }

    [JsonPropertyName("Mat")]
    public string? Matricula { get; set; }

    [JsonPropertyName("MatSite")]
    public string? MatriculaSite { get; set; }

    [JsonPropertyName("Nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("Cpf")]
    public string? CPF { get; set; }

    [JsonPropertyName("Rg")]
    public string? RG { get; set; }

    [JsonPropertyName("DataNasc")]
    public string? DataDeNascimento { get; set; }

    [JsonPropertyName("Desc")]
    public decimal DVT { get; set; }

    [JsonPropertyName("Qvt")]
    public int QVT { get; set; }

    [JsonPropertyName("Vvt")]
    public decimal VVT { get; set; }
        
    [JsonPropertyName("Obs")]
    public string? OBS { get; set; }
}
