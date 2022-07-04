// See https://aka.ms/new-console-template for more information
public class Cliente : Pessoa
{
  List<Animal> pets = new List<Animal>();
  public Cliente(string nome, string cpf, Endereco endereco, string tel) : base(nome, cpf, endereco, tel) { }

  public void AddPet(Animal animal)
  {
    pets.Add(animal);
  }
  public void RemovePet(string Nome)
  {
    pets.ForEach((pet) =>
    {
      if (pet.Nome == Nome) pets.Remove(pet);
    }
    );
  }

}