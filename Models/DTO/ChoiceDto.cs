using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class ChoiceDto
    {
        public Guid Id { get; set; }
        public Boolean AdditionalCheck { get; set; }
        public Boolean IsUniqueChoice { get; set; }
        public string Description { get; set; }
        public string NextPage { get; set; }
        public string PageId { get; set; }
    }
}
