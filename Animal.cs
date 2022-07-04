// See https://aka.ms/new-console-template for more information

public enum Temperamento
{
  docil, bravo
}
public enum TamanhoPelo
{
  semPelos, curto, medio, longo
}
public enum TipoPelo
{
  liso, crespo
}
public enum Sexo
{
  macho, femea
}
public enum Porte
{
  pequeno, medio, grande
}
public struct Raca
{
  string nome;
  TamanhoPelo tamanhoPelo;
  TipoPelo tipoPelo;
  Porte porte;

  public Raca(string nome, TamanhoPelo tamanhoPelo, TipoPelo tipoPelo, Porte porte)
  {
    this.nome = nome.ToLower();
    this.tamanhoPelo = tamanhoPelo;
    this.tipoPelo = tipoPelo;
    this.porte = porte;
  }

  public string Nome { get => nome; }
  public TamanhoPelo TamanhoPelo { get => tamanhoPelo; }
  public TipoPelo TipoPelo { get => tipoPelo; }
  public Porte Porte { get => porte; }

}

abstract public class Animal
{
  // raca define
  // -> tamanho pelo
  // -> tipo pelo

  string _nome;
  string _raca;
  Temperamento _temperamento;
  TamanhoPelo _tamanhoPelo;
  Sexo _sexo;
  int _idade;

  public Animal(string nome, Raca raca, Temperamento temperamento, Sexo sexo, int idade)
  {
    this._nome = nome;
    this._raca = raca.Nome;
    this._tamanhoPelo = raca.TamanhoPelo;
    this._temperamento = temperamento;
    this._sexo = sexo;
    this._idade = idade;
  }

  public string Nome { get => _nome; }
  public string Raca { get => _raca; }
  public Temperamento Temperamento { get => _temperamento; set => _temperamento = value; }
  public TamanhoPelo TipoPelo { get => _tamanhoPelo; }
  public Sexo Sexo { get => _sexo; }
  public int Idade { get => _idade; }

  // Design patter Prototype

}