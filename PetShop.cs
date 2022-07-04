// See https://aka.ms/new-console-template for more information
public sealed class PetShop
{
  private static PetShop? _instance;

  List<Pedido> pedidos;
  List<Funcionario> funcionarios;
  List<Cliente> clientes;

  List<Raca> racasGato;
  List<Raca> racasCachorro;


  public List<Raca> RacasGato { get => racasGato; }
  public List<Raca> RacasCachorro { get => racasCachorro; }
  public List<Cliente> Clientes { get => clientes; }
  public List<Pedido> Pedidos { get => pedidos; }
  public List<Funcionario> Funcionarios { get => funcionarios; }

  private PetShop()
  {
    pedidos = new List<Pedido>();
    funcionarios = new List<Funcionario>();
    clientes = new List<Cliente>();
    racasGato = new List<Raca>();
    racasCachorro = new List<Raca>();
  }

  // Singleton
  // -> verifica se ja tem uma instancia da classe,
  // se não tem ele cria uma
  // se tem ele retorna a mesma
  public static PetShop GetInstance()
  {
    if (_instance == null)
    {
      _instance = new PetShop();
    }
    return _instance;
  }


  // +++++ CLIENTES
  public void NewClient(Cliente cliente)
  {
    Clientes.Add(cliente);
  }
  public void AddPet(Cliente cliente, Animal animal)
  {
    cliente.AddPet(animal);
  }
  public List<Cliente> GetClientes() => Clientes;
  public void AddRaca(Raca raca, int tipo)
  {
    if (tipo == 0) racasGato.Add(raca);
    else racasCachorro.Add(raca);
  }


  // ++++ FUNCIONARIOS
  public void NewFuncionario(Funcionario funcionario)
  {
    Funcionarios.Add(funcionario);
  }




  // Modificar Clientes
  // Adicionar Funcionarios
  // Modificar Funcionarios
  // Adicionar serviçõs
  // Modificar Precos -> servicos, funcionarios
  // Ver/Alterar status serviçõs -> SERVICOS CUIDA

  // Criar Pedidos
  // Alterar Status Pedido (Pago, nao pago)




}