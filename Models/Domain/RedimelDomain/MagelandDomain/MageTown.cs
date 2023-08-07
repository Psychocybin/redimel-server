using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageTown
    {
        public Guid Id { get; set; }
        public Guid MagelandId { get; set; }
        [ForeignKey("MageTownTheCentralSquare")]
        public Guid MageTownTheCentralSquareId { get; set; }
        [ForeignKey("MageTownInnTheOldMagician")]
        public Guid MageTownInnTheOldMagicianId { get; set; }
        [ForeignKey("MageTownTheLibrary")]
        public Guid MageTownTheLibraryId { get; set; }
        [ForeignKey("MageTownGuardHill")]
        public Guid MageTownGuardHillId { get; set; }
        public virtual MageTownTheCentralSquare MageTownTheCentralSquare { get; set; }
        public virtual MageTownInnTheOldMagician MageTownInnTheOldMagician { get; set; }
        public virtual MageTownTheLibrary MageTownTheLibrary { get; set; }
        public virtual MageTownGuardHill MageTownGuardHill { get; set; }
        public virtual ICollection<WorldInfoVariable> MageTownVariables { get; set; }
    }
}
