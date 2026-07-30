namespace BlogApp.Entity;
public class User
{
    public int UserId { get; set; }
    public string? UserName { get; set; }

    //bir user birden fazla post oluşturabilir anlamına geliyor.
    public List<Post> Posts { get; set; } = new List<Post>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}