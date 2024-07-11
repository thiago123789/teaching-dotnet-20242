using NGPD.Manager.Data.Contracts;
using NGPD.Manager.Entities;

namespace NGPD.Manager.Servicesç;

public class Class1
{
    private readonly IAlunoRepository _alunoRepository;

    public async Task ExampleAluno(Aluno a)
    {
        var alunos = await _alunoRepository
            .FindByAsync(al => al.Nome.StartsWith("T") && al.Email.EndsWith("@gmail.com"));
        
        
    }
}