namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface ILike
    {
        User Author { get; set; }

        string AuthorId { get; set; }

        Comment Comment { get; set; }

        int CommentId { get; set; }

        int Id { get; set; }

        bool Value { get; set; }
    }
}