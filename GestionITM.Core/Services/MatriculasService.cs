// MatriculaService.cs
public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepo;
    private readonly ICursoRepository _cursoRepo;
    private readonly IMapper _mapper;

    public MatriculaService(IMatriculaRepository matriculaRepo, ICursoRepository cursoRepo, IMapper mapper)
    {
        _matriculaRepo = matriculaRepo;
        _cursoRepo = cursoRepo;
        _mapper = mapper;
    }

    public async Task<MatriculaResponseDto> MatricularEstudianteAsync(MatriculaRequestDto request)
    {
        var curso = await _cursoRepo.GetByIdAsync(request.CursoId);
        
        // Regla de Negocio (El Chef)
        if (curso == null || curso.CuposDisponibles <= 0)
        {
            throw new InvalidOperationException("El curso seleccionado no tiene cupos disponibles.");
        }

        var matricula = new Matricula 
        { 
            CursoId = request.CursoId, 
            EstudianteId = request.EstudianteId,
            Fecha = DateTime.UtcNow
        };

        curso.CuposDisponibles--; 
        await _cursoRepo.UpdateAsync(curso);
        await _matriculaRepo.AddAsync(matricula);

        return _mapper.Map<MatriculaResponseDto>(matricula);
    }
}