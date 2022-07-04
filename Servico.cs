// See https://aka.ms/new-console-template for more information

public enum CodigoServico
{
  BANHO,
  TOSA
}
public class Servico
{
  int id;
  CodigoServico cod; // codigo do servico
  Animal pet;
  float precoBase;
  Funcionario? funcionario;

  public Servico(int id, CodigoServico cod, Animal pet, float precoBase, Funcionario? funcionario)
  {
    this.id = id;
    this.cod = cod;
    this.pet = pet;
    this.precoBase = precoBase;
    this.funcionario = funcionario;
  }
}