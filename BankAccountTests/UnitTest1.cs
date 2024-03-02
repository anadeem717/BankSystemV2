
namespace BankAccountTests;
public class UnitTest1
{
    [Theory]
    [InlineData("HelloWorld123!")]
    [InlineData("helloworldH$09")]
    [InlineData("aaaAaaaaa123455678?")]
    public void PasswordStrengthCheck(string password)
    {
        Assert.True(Program.CreatePassword(ref password));
    }

    [Theory]
    [InlineData("helloworld123!")]
    [InlineData("helloworldH09")]
    [InlineData("a!Hshj")]
    public void PasswordStrengthCheck2(string password)
    {
        Assert.False(Program.CreatePassword(ref password));
    }


    [Fact]
    public void AccountCheck()
    {
        BankAccount account = new BankAccount("John", "Doe", "jdoe", "HelloWorld123!", 100);

        Assert.Equal("John", account.fName);
        Assert.Equal("Doe", account.lName);
        Assert.Equal("jdoe", account.username);
        Assert.Equal("HelloWorld123!", account.password);
        Assert.Equal(100, account.balance);

    }


    [Fact]
    public void BalanceCheck()
    {
        BankAccount account = new BankAccount("John", "Doe", "jdoe", "HelloWorld123!", 100);

        account.Deposit(100.10);
        Assert.Equal(200.10, account.balance);

        account.Withdraw(50.50);
        Assert.Equal(149.6, account.balance);

        account.Deposit(100);
        Assert.Equal(249.6, account.balance);

        account.Withdraw(100);
        Assert.Equal(149.6, account.balance);

    }
}