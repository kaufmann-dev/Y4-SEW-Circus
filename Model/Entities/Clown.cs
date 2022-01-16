using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("CLOWNS")]
public class Clown {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CLOWN_ID")]
    public int Id { get; set; }

    [Column("NAME"), StringLength(100), Required]
    public string Name { get; set; }

    [Column("CIRCUS_ID")]
    public int? CircusId { get; set; } // nullable
    public Circus Circus { get; set; }

}