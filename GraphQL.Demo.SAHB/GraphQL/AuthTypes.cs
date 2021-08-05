using SAHB.GraphQLClient.FieldBuilder.Attributes;


public class UserType {
    public string username { get; set; }
    public RoleType role { get; set; }
}

public class UsersType {
    public UserType[] users { get; set; }
}

public class RoleType {
    public string name { get; set; }
    public string description { get; set; }
}

public class LoginType {
    public UserType user { get; set; }
    public string jwt { get; set; }
}

public class QueryUser {
    [GraphQLArgumentsAttribute("id", "ID", "id")]
    public UserType user { get; set; }
}

public class LoginInput {

    public string identifier { get; set; }
    public string password { get; set; }

    LoginInput() { }


    public LoginInput(string username, string password) {
        this.identifier = username;
        this.password = password;
    }
}

public class GLogin {
    [GraphQLArgumentsAttribute("input", "UsersPermissionsLoginInput!", "input")]
    public LoginType login { get; set; }
}
