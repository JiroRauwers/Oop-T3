// See https://aka.ms/new-console-template for more information
namespace Oop3
{
  internal partial class Program
  {
    private static void Main(string[] args)
    {
      Console.CursorVisible = false;

      PetShop petShop = PetShop.GetInstance();

      while (true)
        switch (Menus.Main())
        {
          case 0:
            // New service 
            Menus.Servico();
            break;
          case 1:
            // history services / edit
            break;
          case 2:
            // New Client
            Cliente c = (Cliente)Menus.NovaPessoa(true);
            if (c == null) break;
            Animal a = Menus.AddPet();
            PetShop.GetInstance().AddPet(c, a);
            break;
          case 3:
            // Client List / edit
            Console.WriteLine('\n');
            petShop.GetClientes().ForEach((c) => Console.WriteLine(c.Nome));
            break;
          case 4:
            Menus.ListFuncionarios();
            break;
          case 5:
            // add worker
            break;
          case 6:
            // teste
            Menus.AddPet();
            break;

        }
    }
  }
}