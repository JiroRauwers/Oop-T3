// See https://aka.ms/new-console-template for more information
public class Cachorro : Animal
{
  Porte porte;

  public Cachorro(
    string nome, Raca raca, Temperamento temperamento, Sexo sexo, int idade)
    : base(nome, raca, temperamento, sexo, idade) { }

}