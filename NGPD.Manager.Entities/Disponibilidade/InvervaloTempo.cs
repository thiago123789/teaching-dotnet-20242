using NGPD.Manager.CrossCutting.Wrapper;

namespace NGPD.Manager.Entities.Disponibilidade;

public record IntervaloTempo
{
    public DiaSemana WeekDay => id;
    public TimeSpan From => from;
    public TimeSpan To => to;
    
    private DiaSemana id;
    private TimeSpan from;
    private TimeSpan to;
    
    public IntervaloTempo(DiaSemana id, TimeSpan from, TimeSpan to)
    {
        ValidateTimeSlot(from, to);
        this.id = id;
        this.from = from;
        this.to = to;
    }

    private void ValidateTimeSlot(TimeSpan from, TimeSpan to)
    {
        if (from > to)
        {
            throw new ManagerException("Initial time cannot be higher then final");
        }
    }
}