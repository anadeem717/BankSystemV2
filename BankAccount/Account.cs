using System.Text;

public class BankAccount {

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public double Balance { get; private set; }
    public long AccountNum { get; private set; }

    public static long TotalAccountNums { get; private set; } = 18946759;  

    // default constructor
    public BankAccount() {
        FirstName = "NoName";
        LastName = "NoName";
        Username = "No Username";
        Password = "No Password";
        Balance = 0; 
        AccountNum = TotalAccountNums++; 
    }

    // parameterized constructor
    public BankAccount(string firstName, string lastName, string username, string password, double balance) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Username = username;
        this.Password = password;
        this.Balance = balance;  
        AccountNum = TotalAccountNums++; 
    }

    public void Deposit (double amount) { Balance += amount; }

    public void Withdraw (double amount) { 
        if ((Balance - amount) >= 0) { Balance -= amount; }

        // if user wants to withdraw more than they have as Balance
        else { Console.WriteLine("\n*****Insufficient Funds.*****\n"); } 
    }

    // displays account info for the user's account
    public void ViewAccountInfo() {
        var sb = new StringBuilder();
        sb.AppendLine($"\nACCOUNT INFO FOR {FirstName} {LastName}:");
        sb.AppendLine($"----------------------------");
        sb.AppendLine($"Account Number: {AccountNum}");
        sb.AppendLine($"Username: {Username}");
        sb.AppendLine($"Balance: ${Balance}\n");

        Console.WriteLine(sb.ToString());
    }

}
