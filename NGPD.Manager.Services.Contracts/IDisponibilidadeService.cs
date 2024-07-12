using NGPD.Manager.Entities.Disponibilidade;
using NGPD.Manager.Entities.DTO;

namespace NGPD.Manager.Data.Contracts;

public interface IDisponibilidadeService
{
    Task<IList<Disponibilidade>> GetAllDisponibilidade();
    Task<Disponibilidade> GetDisponibilidadeById(Guid guid);
    Task<Disponibilidade> CreateDisponibilidade(DisponibilidadeInputDto disponibilidadeInputDto);
}