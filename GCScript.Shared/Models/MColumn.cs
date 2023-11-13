namespace GCScript.Shared.Models;

public class MColumn
{
    public string Cnpj { get; set; } = "";
    public string Empresa { get; set; } = "";
    public string Uf { get; set; } = "";
    public string Operadora { get; set; } = "";
    public string Unidade { get; set; } = "";
    public string Departamento { get; set; } = "";
    public string Matricula { get; set; } = "";
    public string MatriculaSite { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Cpf { get; set; } = "";
    public string RG { get; set; } = "";
    public DateTime DataDeNascimento { get; set; } = DateTime.MinValue;
    public decimal Dvt { get; set; }
    public decimal Qvt { get; set; }
    public decimal Vvt { get; set; }
    public decimal Tvt { get; set; }
    public decimal Total { get; set; }
    public decimal RecargaPendente { get; set; }
    public decimal Saldo { get; set; }
    public decimal SaldoTotal { get; set; }
    public decimal ValorDias { get; set; }
    public decimal Desconto { get; set; }
    public decimal Compra { get; set; }
    public decimal Parcela1 { get; set; }
    public decimal Parcela2 { get; set; }
    public decimal Parcela3 { get; set; }
    public decimal Parcela4 { get; set; }
    public decimal Parcela5 { get; set; }
    public string NumeroDoCartao { get; set; } = "";
    public string Obs { get; set; } = "";
    public string Temp1 { get; set; } = "";
    public string Temp2 { get; set; } = "";
    public string Temp3 { get; set; } = "";
    public string Temp4 { get; set; } = "";
    public string Temp5 { get; set; } = "";
}
