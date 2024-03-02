
public class BankAccount {

    public string fName { get; private set; }
    public string lName { get; private set; }
    public string username { get; private set; }
    public string password { get; private set; }
    public double balance { get; private set; }
    public long accountNum { get; private set; }

    public static long TotalAccountNums { get; private set; } = 18946759;  

    // default constructor
    public BankAccount() {
        fName = "NoName";
        lName = "NoName";
        username = "No username";
        password = "No password";
        balance = 0; 
        accountNum = TotalAccountNums++; 
    }

    // parameterized constructor
    public BankAccount(string fName, string lName, string username, string password, double balance) {
        this.fName = fName;
        this.lName = lName;
        this.username = username;
        this.password = password;
        this.balance = balance;  
        accountNum = TotalAccountNums++; 
    }

    public void Deposit (double amount) { balance += amount; }

    public void Withdraw (double amount) { 
        if ((balance - amount) >= 0) { balance -= amount; }

        // if user wants to withdraw more than they have as balance
        else { Console.WriteLine("\n*****Insufficient Funds.*****\n"); } 
    }

    // displays account info for the user's account
   public void ViewAccountInfo() {
    Console.WriteLine($"\nACCOUNT INFO FOR {this.fName} {this.lName}:");
    Console.WriteLine($"----------------------------");
    Console.WriteLine($"Account Number: {this.accountNum}");
    Console.WriteLine($"Username: {this.username}");
    Console.WriteLine($"Balance: ${this.balance}\n");
    }

}
