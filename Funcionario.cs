// See https://aka.ms/new-console-template for more information

public enum Funcao
{
  BANHO, TOSA
}

public class Funcionario : Pessoa
{
  private List<Funcao> _funcoes;
  private List<double> _precoHora;

  public Funcionario(string nome, string cpf, Endereco endereco, string tel)
  : base(nome, cpf, endereco, tel)
  {
    this._funcoes = new List<Funcao>();
    this._precoHora = new List<double>();
  }

  public void addFuncao(Funcao funcao, double precoHora)
  {
    _funcoes.Add(funcao);
    _precoHora.Add(precoHora);
  }

  public void removFuncao(Funcao funcao)
  {
    int i = _funcoes.IndexOf(funcao);
    _funcoes.RemoveAt(i);
    _precoHora.RemoveAt(i);
  }
}