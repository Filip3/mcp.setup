using HelloYallNerds;

namespace HelloYallNerds.Tests;

public class GreetingTests
{
    private readonly GreetingService _greetingService;

    public GreetingTests()
    {
        _greetingService = new GreetingService();
    }

    [Fact]
    public void GeneratePersonalizedGreeting_WithValidName_ReturnsPersonalizedMessage()
    {
        // Arrange
        var name = "John";
        var expected = "Hello John, welcome to the Y'all Nerds club!";

        // Act
        var result = _greetingService.GeneratePersonalizedGreeting(name);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GeneratePersonalizedGreeting_WithNameHavingWhitespace_TrimsNameCorrectly()
    {
        // Arrange
        var name = "  Alice  ";
        var expected = "Hello Alice, welcome to the Y'all Nerds club!";

        // Act
        var result = _greetingService.GeneratePersonalizedGreeting(name);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void GeneratePersonalizedGreeting_WithEmptyOrWhitespaceInput_ReturnsDefaultGreeting(string name)
    {
        // Arrange
        var expected = "Hello Y'all Nerds!";

        // Act
        var result = _greetingService.GeneratePersonalizedGreeting(name);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsValidName_WithValidName_ReturnsTrue()
    {
        // Arrange
        var name = "John";

        // Act
        var result = _greetingService.IsValidName(name);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidName_WithValidNameHavingWhitespace_ReturnsTrue()
    {
        // Arrange
        var name = "  Alice  ";

        // Act
        var result = _greetingService.IsValidName(name);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void IsValidName_WithEmptyOrWhitespaceInput_ReturnsFalse(string name)
    {
        // Act
        var result = _greetingService.IsValidName(name);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetWelcomeMessage_ReturnsCorrectMessage()
    {
        // Arrange
        var expected = "Welcome to the Copilot Agent POC!";

        // Act
        var result = _greetingService.GetWelcomeMessage();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GeneratePersonalizedGreeting_WithSpecialCharacters_HandlesCorrectly()
    {
        // Arrange
        var name = "José-María";
        var expected = "Hello José-María, welcome to the Y'all Nerds club!";

        // Act
        var result = _greetingService.GeneratePersonalizedGreeting(name);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GeneratePersonalizedGreeting_WithNumbers_HandlesCorrectly()
    {
        // Arrange
        var name = "User123";
        var expected = "Hello User123, welcome to the Y'all Nerds club!";

        // Act
        var result = _greetingService.GeneratePersonalizedGreeting(name);

        // Assert
        Assert.Equal(expected, result);
    }
}