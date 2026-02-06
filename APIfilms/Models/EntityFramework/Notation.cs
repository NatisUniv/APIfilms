using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIfilms.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public class Notation
    {
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("flm_id")]
        public int FilmId { get; set; }

        [Required]
        [Range(0, 5)]
        [Column("not_note")]
        public int Note { get; set; }

        public virtual Utilisateur UtilisateurNotant { get; set; } = null!;
        public virtual Film FilmNote { get; set; } = null!;
    }
}
