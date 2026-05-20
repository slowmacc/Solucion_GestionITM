[ApiController]
[Route("api/[controller]")]
public class MatriculaController : ControllerBase
{
    private readonly IMatriculaService _matriculaService;

    public MatriculaController(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    [HttpPost]
    [Authorize(Roles = "Estudiante")] // Seguridad JWT estricta
    public async Task<IActionResult> CrearMatricula([FromBody] MatriculaRequestDto request)
    {
        try
        {
            var resultado = await _matriculaService.MatricularEstudianteAsync(request);
            return Ok(resultado);
        }
        catch (InvalidOperationException ex)
        {
            // Observabilidad: Serilog captura el error (Configurado en Program.cs)
            Log.Error(ex, "Error al matricular: {Mensaje}", ex.Message);
            return BadRequest(new { error = ex.Message });
        }
    }
}