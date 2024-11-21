using System.Security.Principal;

namespace MultiShop.Comment.Entites
{
    public class UserComment
    {
        public int UserCommentId { get; set; }
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Raiting { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ProductId { get; set; }

    }
}
