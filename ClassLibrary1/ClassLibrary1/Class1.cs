namespace ClassLibrary1
{
    public class Class1
    {
        public class bankAccount
        { private int id;
            private double balance;
        }
        public int id
        {
            get { return id; }
            set { id = value; } 
        }
        public double balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public void Deposit(double amount)
        {
            balance += amount;
        }
        public void Withdraw(double amount)
        { 
        balance -= amount;
        }
        public override string ToString()
        {
            return ($"Account {this.id}, balance {this.balance}");
        }
    }
}