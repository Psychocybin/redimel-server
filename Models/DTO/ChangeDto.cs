using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class ChangeDto
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string PropertyName { get; set; }
        public string ActionType { get; set; }
        public string HeroClass { get; set; }
        public string HeroType { get; set; }
        public int OrderOfBattle { get; set; }
        public string PageId { get; set; }
        public Guid ChoiceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AdditionalInfo { get; set; }
        public Boolean TrueOrFalse { get; set; }
        public Boolean ActiveOrNot { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Damage { get; set; }
        public double Range { get; set; }
        public double Quantity { get; set; }
    }
}
