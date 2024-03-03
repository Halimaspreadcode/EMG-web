using Postgrest.Models;
using Postgrest.Attributes;
namespace EMG_website.Models
{
    [Table("Voiture")]

    public class Voiture : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("CodeVIN")]
        public string? CodeVIN { get; set; }

        [Column("Marque")]
        public string? Marque { get; set; }

        [Column("Modele")]
        public string? Modele { get; set; }

        [Column("Année")]
        public int Annee { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("EstVendue")]
        public bool EstVendue { get; set; }

        //Finition
        [Column("Finition")]
        public string? Finition { get; set; }

        //Date_achat
        [Column("Date_achat")]
        public DateTime? DateAchat { get; set; }

        //Prix_achat
        [Column("Prix_achat")]
        public string? PrixAchat { get; set; }

        //Reparation
        [Column("Reparation")]
        public string? Reparation { get; set; }

        //Prix_reparation
        [Column("Prix_reparation")]
        public string? PrixReparation { get; set; }

        // Ajoutez d'autres propriétés nécessaires correspondant à votre table Supabase
    }
}
