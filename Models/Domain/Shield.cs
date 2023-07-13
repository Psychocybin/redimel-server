using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class Shield
    {
        public Guid Id { get; set; }
        public string ShieldType { get; set; }
        public Boolean IsExist { get; set; }
        public int Defence { get; set; }
        //[ForeignKey("Equipment")]
        public Guid EquipmentId { get; set; }
        //public Equipment Equipment { get; set; }
    }
}
