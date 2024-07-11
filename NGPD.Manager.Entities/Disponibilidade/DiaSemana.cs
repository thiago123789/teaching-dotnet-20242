using NGPD.Manager.CrossCutting.Wrapper;

namespace NGPD.Manager.Entities.Disponibilidade;

public class DiaSemana : Enumeration
{
    public static DiaSemana Segunda = new DiaSemana(1, "Segunda-feira");
    public static DiaSemana Terça = new DiaSemana(2, "Terça-feira");
    public static DiaSemana Quarta = new DiaSemana(3, "Quarta-feira");
    public static DiaSemana Quinta = new DiaSemana(4, "Quinta-feira");
    public static DiaSemana Sexta = new DiaSemana(5, "Sexta-feira");
    public static DiaSemana Sabado = new DiaSemana(6, "Sábado");
    
    private DiaSemana(int id, string name) : base(id, name)
    {
    }
}