namespace Admin.Login;

public static class Data
{
    internal static Task<(string adminID, string passwordHash)> GetAdmin(string userName)
    {
        // return DB
        //     .Find<Dom.Admin, (string adminID, string passwordHash)>()
        //     .Match(a => a.UserName == userName)
        //     .Project(a => new(a.ID!, a.PasswordHash))
        //     .ExecuteSingleAsync();

        return Task.FromResult(("SuperAdminId", "$2a$11$HNSiCz3c9brbV1PRncYWTOjev7P.GJkrKbeK0cJPuivcMz1UwHsVO"));
    }
}
