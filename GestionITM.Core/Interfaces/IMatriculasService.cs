// IMatriculaService.cs
public interface IMatriculaService 
{
    Task<MatriculaResponseDto> MatricularEstudianteAsync(MatriculaRequestDto request);
}