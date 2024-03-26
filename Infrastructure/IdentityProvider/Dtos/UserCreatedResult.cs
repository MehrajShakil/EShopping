namespace IdentityProvider.Dtos;

public class IdentityResult
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
}

public class UserCreatedResult : IdentityResult
{
}

public class UserLoginResult : IdentityResult
{
}
