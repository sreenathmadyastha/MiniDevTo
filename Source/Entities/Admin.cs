using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace Dom;

[Collection("Admins")]
public class Admin : Entity
{
    public new string ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }
}