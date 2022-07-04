// See https://aka.ms/new-console-template for more information
public class Pedido
{
  List<Servico> servicos;
  string desc;
  DateTime data;

  public Pedido(List<Servico> servicos, string desc, DateTime data)
  {
    this.servicos = servicos;
    this.desc = desc;
    this.data = data;
  }

  public double CalcValorTotal() => 1.2;
}