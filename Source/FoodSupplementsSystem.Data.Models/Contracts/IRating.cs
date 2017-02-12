namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface IRating
    {
        User Author { get; set; }

        string AuthorId { get; set; }

        int Id { get; set; }

        Supplement Supplement { get; set; }

        int SupplementId { get; set; }

        int Value { get; set; }
    }
}