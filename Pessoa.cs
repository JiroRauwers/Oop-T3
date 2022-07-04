// See https://aka.ms/new-console-template for more information
public enum NovaPessoaTipo
{
  CLIENTE,
  FUNCIONARIO
}

public struct Endereco
{
  string rua; string numero;
  public Endereco(string rua, string numero)
  {
    this.rua = rua; this.numero = numero;
  }
  public override string ToString()
  {
    return this.rua + ", " + this.numero;
  }
}

abstract public class Pessoa
{
  private string _nome;
  private string _cpf;
  private Endereco _endereco;
  private string _tel;

  public Pessoa(string nome, string cpf, Endereco endereco, string tel)
  {
    this._nome = nome; this._cpf = cpf;
    this.Endereco = endereco; this.Tel = tel;
  }

  public string Nome { get => _nome; }
  public string CPF { get => _cpf; }
  public Endereco Endereco { get => _endereco; set => _endereco = value; }
  public string Tel { get => _tel; set => _tel = value; }
}