using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BankApplication
    {
        public static Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
        public static List<string> inputHistory = new List<string>(); // Store user input history
        public static Dictionary<int, BankAccountType> bankAccounts = new Dictionary<int, BankAccountType>();
        public static List<CustomerAccount> mappings = new List<CustomerAccount>();
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Customer> customerData = new List<Customer>();
        public static int transactionIdCounter = 1;


        public static decimal GetTotalDepositAmount()
        {
            decimal totalDeposit = transactions
                .Where(t => t.TransactionType == "Deposit")
                .Sum(t => t.Amount);
            return totalDeposit;
        }

        public static decimal GetTotalWithdrawalAmount()
        {
            decimal totalWithdrawal = transactions
                .Where(t => t.TransactionType == "Withdrawal")
                .Sum(t => t.Amount);
            return totalWithdrawal;
        }


    }
}
