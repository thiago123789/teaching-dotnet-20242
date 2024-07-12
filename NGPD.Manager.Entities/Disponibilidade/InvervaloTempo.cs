using NGPD.Manager.CrossCutting.Wrapper;

namespace NGPD.Manager.Entities.Disponibilidade;

public record IntervaloTempo
{
    public DiaSemana DiaSemana => diaSemana;
    public TimeSpan From => from;
    public TimeSpan To => to;
    
    private DiaSemana diaSemana;
    private TimeSpan from;
    private TimeSpan to;
    
    public IntervaloTempo(DiaSemana diaSemana, TimeSpan from, TimeSpan to)
    {
        ValidateTimeSlot(from, to);
        this.diaSemana = diaSemana;
        this.from = from;
        this.to = to;
    }

    protected IntervaloTempo()
    {
        
    }

    private void ValidateTimeSlot(TimeSpan from, TimeSpan to)
    {
        if (from > to)
        {
            throw new ManagerException("Initial time cannot be higher then final");
        }
    }
}