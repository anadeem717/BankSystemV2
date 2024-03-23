
namespace BankAccountTests;
public class BankAccountTests
{
    [Theory]
    [InlineData("HelloWorld123!", true)]
    [InlineData("helloworldH$09", true)]
    [InlineData("aaaAaaaaa123455678?", true)]
    [InlineData("helloworld123!", false)]
    [InlineData("helloworldH09", false)]
    [InlineData("a!Hshj", false)]
    [InlineData("", false)]
    public void Check_Password_Returns_Correct_Strength(string password, bool expectedValue)
    {
        Assert.Equal(Program.CheckPassword(password), expectedValue);
    }


    [Fact]
    public void Account_BuildingAccount_CorrectInfoInAccount()
    {
        BankAccount account = new BankAccount("John", "Doe", "jdoe", "HelloWorld123!", 100);

        Assert.Equal("John", account.FirstName);
        Assert.Equal("Doe", account.LastName);
        Assert.Equal("jdoe", account.Username);
        Assert.Equal("HelloWorld123!", account.Password);
        Assert.Equal(100, account.Balance);

    }

    [Fact]
    public void Deposit_IncreasesBalance()
    {
        BankAccount account = new BankAccount("John", "Doe", "jdoe", "HelloWorld123!", 100);

        account.Deposit(100.10);
        Assert.Equal(200.10, account.Balance);
    }

    [Fact]
    public void Withdraw_DecreasesBalance()
    {
        BankAccount account = new BankAccount("John", "Doe", "jdoe", "HelloWorld123!", 100);

        account.Withdraw(50.50);
        Assert.Equal(49.50, account.Balance);
    }

    [Fact]
    public void Withdraw_InsufficientBalance_DoesNotChangeBalance()
    {
        BankAccount account = new BankAccount("John", "Doe", "jdoe", "HelloWorld123!", 100);

        account.Withdraw(110);
        Assert.Equal(100, account.Balance);
    }
}