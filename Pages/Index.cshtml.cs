using Microsoft.AspNetCore.Mvc.RazorPages; // Importa la funcionalidad para Razor Pages
using Microsoft.EntityFrameworkCore; // Importa funcionalidades de Entity Framework Core (para consultas async, LINQ, etc.)
using prograweb_chatapp_backend_net9.Data; // Importa el DbContext definido por ti
using prograweb_chatapp_backend_net9.Models; // Importa el modelo que representa la tabla en la base de datos

// Define el modelo de p�gina asociado a la Razor Page Index.cshtml
public class IndexModel : PageModel
{
    // Inyecci�n de dependencia del DbContext para acceder a la base de datos
    private readonly ApplicationDbContext _context;

    // Constructor que recibe el contexto y lo guarda para uso interno
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lista p�blica que estar� disponible para la vista (Index.cshtml)
    // Se llena al ejecutar el m�todo OnGetAsync()
    public List<UsuariosConectados> Usuarios { get; set; } = [];

    // M�todo que se ejecuta autom�ticamente en GET requests
    // Se usa para cargar los datos al renderizar la p�gina
    public async Task OnGetAsync()
    {
        // Recupera todos los usuarios conectados desde la base de datos
        // y los ordena de m�s reciente a m�s antiguo por la fecha de conexi�n
        Usuarios = await _context.UsuariosConectados
            .OrderByDescending(u => u.FechaConexion)
            .ToListAsync();
    }
}
