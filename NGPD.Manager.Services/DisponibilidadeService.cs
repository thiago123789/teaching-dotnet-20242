using NGPD.Manager.CrossCutting.Wrapper;
using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Data.Contracts.Base;
using NGPD.Manager.Entities.Disponibilidade;
using NGPD.Manager.Entities.DTO;

namespace NGPD.Manager.Servicesç;

public class DisponibilidadeService : IDisponibilidadeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDisponibilidadeRepository _disponibilidadeRepository;

    public DisponibilidadeService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
        this._disponibilidadeRepository = unitOfWork.DisponibilidadeRepository;
    }

    public async Task<IList<Disponibilidade>> GetAllDisponibilidade()
    {
        return (IList<Disponibilidade>) await _disponibilidadeRepository.FindAllAsync();
    }

    public async Task<Disponibilidade> GetDisponibilidadeById(Guid guid)
    {
        return await _disponibilidadeRepository.FindByIdAsync(guid);
    }

    public async Task<Disponibilidade> CreateDisponibilidade(DisponibilidadeInputDto disponibilidadeInputDto)
    {
        var diaSemana = Enumeration.GetAll<DiaSemana>().Where(e => e.Id == disponibilidadeInputDto.DiaDaSemana).SingleOrDefault();
        var intTmp = new IntervaloTempo(diaSemana, disponibilidadeInputDto.inicio, disponibilidadeInputDto.fim); 
        
        var disponibilidade = new Disponibilidade()
        {
            IntervaloTempo = intTmp
        };

        await _disponibilidadeRepository.SaveAsync(disponibilidade);
        await _unitOfWork.SaveChangesAsync();

        return disponibilidade;
    }

    public async Task CadastrarDisponibilidades()
    {
        
    }
}