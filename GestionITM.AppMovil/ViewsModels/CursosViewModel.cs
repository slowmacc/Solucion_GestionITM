using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Input;

namespace GestionITM.AppMovil.ViewModels
{
    public class CursosViewModel
    {
        private readonly HttpClient _httpClient;
        private readonly int _currentUserId = 1; // ID quemado para el prototipo (debería venir del login)

        // Colección observable para que la UI se actualice automáticamente
        public ObservableCollection<CursoDto> Cursos { get; set; } = new();
        
        // Comandos enlazados a la vista
        public ICommand CargarMasCursosCommand { get; }
        public ICommand MatricularCommand { get; }

        public CursosViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
            // Inicialización de comandos
            CargarMasCursosCommand = new Command(async () => await CargarCursosPaginadosAsync());
            MatricularCommand = new Command<int>(async (cursoId) => await MatricularAsync(cursoId));
        }

        private async Task CargarCursosPaginadosAsync()
        {
            // Aquí iría tu lógica de paginación GET api/curso/paginado
            // incrementando la variable de página y haciendo un .Add() a Cursos
        }

        public async Task MatricularAsync(int cursoId)
        {
            try
            {
                var payload = new { CursoId = cursoId, EstudianteId = _currentUserId };
                var response = await _httpClient.PostAsJsonAsync("api/matricula", payload);
                
                // Resiliencia UX: Evaluamos si el backend rechazó la petición
                if (!response.IsSuccessStatusCode)
                {
                    // Leemos el error JSON que mandó el controlador
                    var errorJson = await response.Content.ReadAsStringAsync();
                    using var errorDocument = JsonDocument.Parse(errorJson);
                    var mensajeBackend = errorDocument.RootElement.GetProperty("error").GetString();

                    // Mostramos el popup elegante sin cerrar la app de golpe
                    await App.Current.MainPage.DisplayAlert("Aviso", $"No se pudo matricular: {mensajeBackend}", "Entendido");
                    return;
                }

                await App.Current.MainPage.DisplayAlert("¡Éxito!", "Matrícula confirmada.", "Genial");
            }
            catch (Exception)
            {
                // Fallback por si se cae el servidor o no hay internet
                await App.Current.MainPage.DisplayAlert("Error de Conexión", "Revisa tu conexión a internet o el estado del servidor.", "OK");
            }
        }
    }
}