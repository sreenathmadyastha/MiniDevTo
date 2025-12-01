using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dom;

public class Article : Entity
{
    public string AuthorID { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsApproved { get; set; }
    [BsonIgnoreIfDefault]
    public string? RejectionReason { get; set; }
    [BsonIgnoreIfDefault] public Comment[] Comments { get; set; } = Array.Empty<Comment>();

    public class Comment
    {
        [BsonId]
        public string CommentID { get; set; }
        public string NickName { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
    }
}