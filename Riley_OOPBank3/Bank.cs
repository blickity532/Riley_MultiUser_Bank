public class Bank
{
    private const decimal InitialBankBalance = 10000;
    private decimal _bankBalance;
    private Dictionary<string, (string Password, decimal Balance)> _users;

    public Bank()
    {
        _bankBalance = InitialBankBalance;
        _users = new Dictionary<string, (string Password, decimal Balance)>
        {
            { "jlennon", ("johnny", 1250) },
            { "pmccartney", ("pauly", 2500) },
            { "gharrison", ("georgy", 3000) },
            { "rstarr", ("ringoy", 1001) }
        };
    }

    public decimal BankBalance => _bankBalance;

    public bool Login(string username, string password)
    {
        if (_users.TryGetValue(username, out var user) && user.Password == password)
        {
            return true;
        }

        return false;
    }

    public decimal GetBalance(string username)
    {
        if (_users.TryGetValue(username, out var user))
        {
            return user.Balance;
        }

        throw new Exception("User not found.");
    }

    public void Deposit(string username, decimal amount)
    {
        if (_users.TryGetValue(username, out var user))
        {
            user.Balance += amount;
            _users[username] = user;
            _bankBalance += amount;
        }
        else
        {
            throw new Exception("User not found.");
        }
    }

    public void Withdraw(string username, decimal amount)
    {
        if (_users.TryGetValue(username, out var user))
        {
            amount = Math.Min(amount, user.Balance);
            amount = Math.Min(amount, 500);
            user.Balance -= amount;
            _users[username] = user;
            _bankBalance -= amount;
        }
        else
        {
            throw new Exception("User not found.");
        }
    }
}