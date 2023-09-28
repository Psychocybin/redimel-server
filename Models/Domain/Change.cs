using redimel_server.Models.Enums;

namespace redimel_server.Models.Domain
{
    public class Change
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string PropertyName { get; set; } // enum Important info .......
        public ActionType ActionType { get; set; }
        public HeroClass HeroClass { get; set; }
        public HeroType HeroType { get; set; }
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
