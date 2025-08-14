namespace HelloYallNerds;

public class GreetingService
{
    public string GeneratePersonalizedGreeting(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Hello Y'all Nerds!";
        }

        var trimmedName = name.Trim();
        return $"Hello {trimmedName}, welcome to the Y'all Nerds club!";
    }

    public bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Trim().Length > 0;
    }

    public string GetWelcomeMessage()
    {
        return "Welcome to the Copilot Agent POC!";
    }
}