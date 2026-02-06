using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIfilms.Models.EntityFramework;

namespace APIfilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly FilmRatingsDBContext _context;

        // Le constructeur utilise l'injection de dépendances pour récupérer le contexte
        public UtilisateursController(FilmRatingsDBContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        // Récupère la liste de tous les utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        // GET: api/Utilisateurs/5
        // Récupère un utilisateur spécifique par son ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // POST: api/Utilisateurs
        // Crée un nouvel utilisateur
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            // Retourne un code 201 (Created) avec l'URL pour consulter le nouvel utilisateur
            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // PUT: api/Utilisateurs/5
        // Modifie un utilisateur existant
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }

            _context.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Utilisateurs.Any(e => e.UtilisateurId == id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}