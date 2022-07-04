using rauwers.dev;
static class Menus
{

  public static void setup()
  {
    Console.Title = "PetShop Programm";
    try
    {
      Console.SetWindowSize(30, 55);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
  }
  static string Title = "\n" +
    "           ██████╗░███████╗████████╗░██████╗██╗░░██╗░█████╗░██████╗░\n" +
    "           ██╔══██╗██╔════╝╚══██╔══╝██╔════╝██║░░██║██╔══██╗██╔══██╗\n" +
    "           ██████╔╝█████╗░░░░░██║░░░╚█████╗░███████║██║░░██║██████╔╝\n" +
    "           ██╔═══╝░██╔══╝░░░░░██║░░░░╚═══██╗██╔══██║██║░░██║██╔═══╝░\n" +
    "           ██║░░░░░███████╗░░░██║░░░██████╔╝██║░░██║╚█████╔╝██║░░░░░\n" +
    "           ╚═╝░░░░░╚══════╝░░░╚═╝░░░╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░░░░\n\n";

  public static int Main()
  {
    setup();
    string[] Opts = { "Novo serviço", "Historico de serviços", "Novo cliente",
    "Lista de clientes", "Lista de funcionarios","TESTE ANIMAL" };
    string msg = Title + "\n\n";
    SimpleMenu menu = new SimpleMenu(msg, Opts);

    return menu.Run(() => { });
  }

  public static void Servico()
  {
    Cliente cliente;
    string msg = Title + "\t\t\tConfigurações de servico\n\n";
    string[] Opts = { "Cliente", "" };
    SimpleMenu menu = new SimpleMenu(msg, Opts);

    int i = menu.Run(() => { });
  }

  public static Pessoa NovaPessoa(bool isCliente)
  {

    NovaPessoaTipo tipo = 0;
    string nome = "";
    string cpf = "";
    string tel = "";
    string endereco = "";
    int lastselect = isCliente ? 2 : 0;
    while (true)
    {
      Console.CursorVisible = false;
      string msg = Title + "\t\t\tAdicionando Novo Cliente\n" +
      "\t\t\tSepare o endereco(rua, numero) por virgula(,)\n";
      string[] Opts = {
        "Tipo:    ",
        null,
        "Nome:      " ,
       "CPF:       ",
        "Tel:       " ,
        "Endereco:  ",
        null,
        "CANCEL     ",
        "COMPLETE   "};
      SimpleMenu menu = new SimpleMenu(msg, Opts);

      switch (menu.Run(() =>
      {
        Console.SetCursorPosition(20, 11);
        Console.Write(tipo);
        Console.SetCursorPosition(20, 13);
        Console.Write(nome);
        Console.SetCursorPosition(20, 14);
        Console.Write(cpf);
        Console.SetCursorPosition(20, 15);
        Console.Write(tel);
        Console.SetCursorPosition(20, 16);
        Console.Write(endereco);
      }, lastselect))
      {
        case 0:
          if (!isCliente)
          {
            SimpleMenu quick = new SimpleMenu(Title + "\t\t\t \t\t\t   \n",
             new string[] { "CLIENTE", "FUNCIONARIO" }
             );
            tipo = (NovaPessoaTipo)quick.Run(() => { });
          }
          break;
        case 2:
          nome = menu.ReadAtPoss(20, 13, true);
          lastselect = 2;
          break;
        case 3:
          cpf = menu.ReadAtPoss(20, 14, true);
          lastselect = 3;
          break;
        case 4:
          tel = menu.ReadAtPoss(20, 15, true);
          lastselect = 4;
          break;
        case 5:
          endereco = menu.ReadAtPoss(20, 16, true);
          lastselect = 5;
          break;
        case 7:
          return null;
        case 8:
          try
          {
            PetShop p = PetShop.GetInstance();
            string[] end = endereco.Split(',');
            Endereco e = new Endereco(end[0], end[1]);

            if (tipo == NovaPessoaTipo.CLIENTE)
            {
              Cliente c = new Cliente(nome, cpf, e, tel);
              p.NewClient(c);
              return c;
            }
            if (tipo == NovaPessoaTipo.FUNCIONARIO)
            {
              Funcionario f = new Funcionario(nome, cpf, e, tel);
              p.NewFuncionario(f);
              return f;
            }
            break;
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
            break;
          }
      }
    }
  }
  public static Animal AddPet()
  {
    while (true)
    {
      Console.CursorVisible = false;
      string msg = Title + "\t\t\tAdicionar Pet\n" +
      "\t\t\tSelecionar Animal\n";
      string[] Opts = {
        "Gato" ,
        "Cachorro",
        null,
        "CANCEL     ",
        };
      SimpleMenu menu = new SimpleMenu(msg, Opts);


      int i = menu.Run(() => { });
      if (i > 2) break;
      return AddPetTyped(i);
    }
    return null;
  }
  public static Animal AddPetTyped(int tipo)
  {
    string nome = "";
    string raca = "";
    Temperamento temperamento = (Temperamento)0;
    Sexo sexo = (Sexo)0; ;
    string idade = "";
    int lastselect = 0;

    while (true)
    {
      Console.CursorVisible = false;
      string msg = Title + "\t\t\tAdicionar Pet\n" +
      "\t\t\t   \n";
      string[] Opts = {
        "Nome:      " ,
       "Raca:      ",
        "Temperamento:" ,
        "Sexo(M,F):  ",
        "Idade:  ",
        null,
        "CANCEL     ",
        "COMPLETE   "};
      SimpleMenu menu = new SimpleMenu(msg, Opts);

      switch (menu.Run(() =>
      {
        Console.SetCursorPosition(20, 11);
        Console.Write(nome);
        Console.SetCursorPosition(20, 12);
        Console.Write(raca);
        Console.SetCursorPosition(20, 13);
        Console.Write(temperamento);
        Console.SetCursorPosition(20, 14);
        Console.Write(sexo);
        Console.SetCursorPosition(20, 15);
        Console.Write(idade);
      }, lastselect))
      {
        case 0:
          nome = menu.ReadAtPoss(20, 11, true);
          lastselect = 0;
          break;
        case 1:
          raca = SelectRaca(tipo).Nome;
          break;
        case 2:
          SimpleMenu quickTemp = new SimpleMenu(Title + "\t\t\tTemperamento Pet\n\t\t\t   \n",
           new string[] { "docil", "bravo" }
           );
          temperamento = (Temperamento)quickTemp.Run(() => { });
          lastselect = 2;
          break;
        case 3:
          SimpleMenu QuickSex = new SimpleMenu(Title + "\t\t\tSexo Pet\n\t\t\t   \n",
          new string[] { "Macho", "Femea" });
          sexo = (Sexo)QuickSex.Run(() => { });
          lastselect = 3;
          break;
        case 4:
          idade = menu.ReadAtPoss(20, 15, true);
          lastselect = 3;
          break;
        case 6:
          return null;
        case 7:
          Raca r = new Raca("NULL", 0, 0, 0);
          if (tipo == 0)
          {
            PetShop.GetInstance().RacasGato.ForEach((_raca) =>
          {
            if (_raca.Nome == raca.ToLower()) r = _raca;
          });
          }
          else
          {
            PetShop.GetInstance().RacasCachorro.ForEach((_raca) =>
            {
              if (_raca.Nome == raca.ToLower()) r = _raca;
            });
          }
          if (r.Nome == "NULL")
          {
            CreateRaca(tipo);
            break;
          }
          else
          {
            if (tipo == 0) return new Gato(nome, r, temperamento, sexo, Int32.Parse(idade));
            if (tipo == 1) return new Cachorro(nome, r, temperamento, sexo, Int32.Parse(idade));
            break;
          };
      }
    }
  }
  public static Raca SelectRaca(int tipo)
  {

    while (true)
    {
      Console.CursorVisible = false;
      string msg = Title + "\t\t\tSelecione uma raca de " + (tipo == 0 ? "Gato" : "Cachorro") + "\n" +
      "\t\t\t\n";
      List<string> Opts = new List<string>();
      if (tipo == 0)
      {
        PetShop.GetInstance().RacasGato.ForEach((_raca) => Opts.Add(_raca.Nome));
      }
      else
      {
        PetShop.GetInstance().RacasCachorro.ForEach((_raca) => Opts.Add(_raca.Nome));
      }
      Opts.Add("Adicionar Nova Raca");


      SimpleMenu menu = new SimpleMenu(msg, Opts.ToArray());
      int i = menu.Run(() => { });
      if (i == Opts.Count() - 1)
      {
        CreateRaca(tipo);
      }
      else
      {
        if (tipo == 0) return PetShop.GetInstance().RacasGato.ElementAt(i);
        return PetShop.GetInstance().RacasCachorro.ElementAt(i);
      }
    }
  }
  public static void CreateRaca(int tipo)
  {
    string nome = "";
    TamanhoPelo tamanhoPelo = 0;
    TipoPelo tipoPelo = 0;
    Porte porte = 0;
    int lastselect = 0;
    while (true)
    {
      Console.CursorVisible = false;
      string msg = Title + "\t\t\tAdicionando Novo Cliente\n" +
      "\t\t\tSepare o endereco(rua, numero) por virgula(,)\n";
      string[] Opts = {
        "Nome:      " ,
        "Tamanho do pelo:       " ,
       (tamanhoPelo== 0 ? null :"Tipo do pelo: "),
        "Porte:   ",
        null,
        "CANCEL     ",
        "COMPLETE   "};
      SimpleMenu menu = new SimpleMenu(msg, Opts);

      switch (menu.Run(() =>
      {
        Console.SetCursorPosition(25, 11);
        Console.Write(nome);
        Console.SetCursorPosition(25, 12);
        Console.Write(tamanhoPelo);
        Console.SetCursorPosition(25, 13);
        if (tamanhoPelo != 0) Console.Write(tipoPelo);
        Console.SetCursorPosition(25, 14);
        Console.Write(porte);
      }, lastselect))
      {
        case 0:
          nome = menu.ReadAtPoss(25, 11, true);
          lastselect = 0;
          break;
        case 1:
          SimpleMenu quickTamPelo = new SimpleMenu(Title + "\t\t\tTamanho do pelo\n\t\t\t   \n",
             Enum.GetNames(typeof(TamanhoPelo))
             );
          tamanhoPelo = (TamanhoPelo)quickTamPelo.Run(() => { });
          lastselect = 1;
          break;
        case 2:
          SimpleMenu quickTipoPelo = new SimpleMenu(Title + "\t\t\tTipo do pelo\n\t\t\t   \n",
             Enum.GetNames(typeof(TipoPelo))
             );
          tipoPelo = (TipoPelo)quickTipoPelo.Run(() => { });
          lastselect = 2;
          break;
        case 3:
          SimpleMenu quickPorte = new SimpleMenu(Title + "\t\t\tPorte\n\t\t\t   \n",
          Enum.GetNames(typeof(Porte))
          );
          porte = (Porte)quickPorte.Run(() => { });
          lastselect = 3;
          break;
        case 5:
          return;
        case 6:
          Raca r = new Raca(nome, tamanhoPelo, tipoPelo, porte);
          PetShop.GetInstance().AddRaca(r, tipo);
          return;
      }
    }
  }

  public static int ListFuncionarios()
  {
    while (true)
    {
      Console.CursorVisible = false;

      string msg = Title + "\t\t\tListar Funcionarios\n\t\t\t\n";
      List<string> Opts = new List<string>();
      Opts.Add("Adicionar Novo Funcionario");

      PetShop.GetInstance().Funcionarios.ForEach((func) => Opts.Add(func.Nome));
      Opts.Add(null);
      Opts.Add("Voltar");

      SimpleMenu menu = new SimpleMenu(msg, Opts.ToArray());

      int _voltar = Opts.Count() - 1;


      int i = menu.Run(() => { });

      if (i == _voltar) return 0;
      if (i == 0) return 0;
      EditFuncionarios(PetShop.GetInstance().Funcionarios.ElementAt(i));
    }
  }

  public static int EditFuncionarios(Funcionario funcionario)
  {

    string nome = funcionario.Nome;
    string cpf = funcionario.CPF;
    string tel = funcionario.Tel;
    string endereco = funcionario.Endereco.ToString();


    int lastselect = 0;
    while (true)
    {
      Console.CursorVisible = false;
      string msg = Title + "\t\t\tAdicionando Novo Cliente\n" +
      "\t\t\tSepare o endereco(rua, numero) por virgula(,)\n";
      string[] Opts = {
        "Nome:      " ,
       "CPF:       ",
        "Tel:       " ,
        "Endereco:  ",
        "Funcoes",
        null,
        "CANCEL     ",
        "COMPLETE   "};
      SimpleMenu menu = new SimpleMenu(msg, Opts);

      switch (menu.Run(() =>
      {
        Console.SetCursorPosition(20, 11);
        Console.Write(nome);
        Console.SetCursorPosition(20, 12);
        Console.Write(cpf);
        Console.SetCursorPosition(20, 13);
        Console.Write(tel);
        Console.SetCursorPosition(20, 14);
        Console.Write(endereco);
      }, lastselect))
      {
        case 0:
          nome = menu.ReadAtPoss(20, 11, true);
          lastselect = 0;
          break;
      }
    }
  }
}