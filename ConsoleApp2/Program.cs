

namespace ConsoleApp2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Banking Application Menu:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Add Bank Account");
                Console.WriteLine("3. Edit Customer");
                Console.WriteLine("4. Edit Bank Account");
                Console.WriteLine("5. Make a Transaction");
                Console.WriteLine("6. Display Account Balance");
                Console.WriteLine("7. Account Statement");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        AddBankAccount();
                        break;
                    case 3:
                        EditCustomer();
                        break;
                    case 4:
                        EditBankAccount();
                        break;
                    case 5:
                        MakeTransaction();
                        break;
                    case 6:
                        DisplayBalance();
                        break;
                    case 7:
                        DisplayAccountStatement();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    case 9: // view total deposit and withdrawal
                        decimal totalDeposit = BankApplication.GetTotalDepositAmount();
                        decimal totalWithdrawal = BankApplication.GetTotalWithdrawalAmount();
                        Console.WriteLine($"Total Deposits: {totalDeposit:C}");
                        Console.WriteLine($"Total Withdrawals: {totalWithdrawal:C}");
                        break;

                    case 10: // View Customer Data
                        Console.WriteLine("Customer Data:");
                        foreach (var customer in BankApplication.customerData)
                        {
                            Console.WriteLine($"Customer ID: {customer.CustomerId}");
                            Console.WriteLine($"Name: {customer.Name}");
                            Console.WriteLine($"Mobile Number: {customer.MobileNumber}");
                            Console.WriteLine($"Email: {customer.Email}");
                            Console.WriteLine($"Address: {customer.Address}");
                            Console.WriteLine();
                        }
                        break;

                    case 11: // View Bank Account Data
                        Console.WriteLine("Bank Account Data:");
                        foreach (var account in BankApplication.bankAccounts.Values)
                        {
                            Console.WriteLine($"Account ID: {account.AccountTypeId}");
                            Console.WriteLine($"Bank Name: {account.BankName}");
                            Console.WriteLine($"Account Type: {account.AccountType}");
                            Console.WriteLine($"Account Number: {account.AccountNumber}");
                            Console.WriteLine($"Balance: {account.Balance:C}");
                            Console.WriteLine();
                        }
                        break;

                    case 12: // View Customer Data
                        ViewCustomerData();
                        break;



                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        static void ViewCustomerData()
        {
            Console.WriteLine("Customer Data:");
            foreach (var customer in BankApplication.customers.Values)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Mobile Number: {customer.MobileNumber}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine();
            }
        }

        static void AddCustomer()
        {
            Console.WriteLine("Enter customer details:");
            Customer customer = new Customer();

            Console.Write("Customer ID: ");
            customer.CustomerId = int.Parse(Console.ReadLine());
            AddToInputHistory("Customer ID: " + customer.CustomerId);

            Console.Write("Name: ");
            customer.Name = Console.ReadLine();
            AddToInputHistory("Name: " + customer.Name);

            Console.Write("Mobile Number: ");
            customer.MobileNumber = Console.ReadLine();
            AddToInputHistory("Mobile Number: " + customer.MobileNumber);

            Console.Write("Email: ");
            customer.Email = Console.ReadLine();
            AddToInputHistory("Email: " + customer.Email);

            Console.Write("Address: ");
            customer.Address = Console.ReadLine();
            AddToInputHistory("Address: " + customer.Address);

            // Store the customer data in the dictionary
            BankApplication.customers[customer.CustomerId] = customer;

            Console.WriteLine("Customer added successfully.");
        }

        // Helper method to add input to history
        static void AddToInputHistory(string input)
        {
            BankApplication.inputHistory.Add(input);
        }
    

    static void AddBankAccount()
    {
        Console.WriteLine("Enter bank account details:");
        BankAccountType account = new BankAccountType();

        Console.Write("Account ID:");
        account.AccountTypeId = int.Parse(Console.ReadLine());

        Console.Write("Bank Name:");
        account.BankName = Console.ReadLine();

        Console.Write("Account Type:");
        account.AccountType = Console.ReadLine();

        Console.Write("Account Number: ");
        account.AccountNumber = Console.ReadLine();

        account.Balance = 0; // Set initial balance to 0

        // Save bank account data to the dictionary
           BankApplication.bankAccounts[account.AccountTypeId] = account;

        Console.WriteLine("Bank account added successfully.");

        // Map the customer to the bank account
        Console.Write("Enter the Customer ID to associate with this account: ");
        int customerId = int.Parse(Console.ReadLine());

        if (BankApplication.customers.ContainsKey(customerId))
        {
                // Create a mapping between customer and account
                BankApplication.mappings.Add(new CustomerAccount
            {
                CustomerAccountId = account.AccountTypeId,
                CustomerId = customerId,
                AccountTypeId = account.AccountTypeId
            });

            Console.WriteLine("Customer associated with the bank account.");
        }
        else
        {
            Console.WriteLine("Customer not found. The bank account was added, but it's not associated with any customer.");
        }
    }
        static void EditCustomer()
        {
            Console.Write("Enter customer ID to edit: ");
            int customerId = int.Parse(Console.ReadLine());

            if (BankApplication.customers.ContainsKey(customerId))
            {
                Customer customer = BankApplication.customers[customerId];
                Console.WriteLine("Enter updated customer details:");

                Console.Write("Name: ");//print the existing customer infor
                customer.Name = Console.ReadLine();

                Console.Write("Mobile Number: ");
                customer.MobileNumber = Console.ReadLine();

                Console.Write("Email: ");
                customer.Email = Console.ReadLine();

                Console.Write("Address: ");
                customer.Address = Console.ReadLine();

                Console.WriteLine("Customer details updated successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        static void EditBankAccount()
        {
            Console.Write("Enter account ID to edit: ");
            int accountId = int.Parse(Console.ReadLine());

            if (BankApplication.bankAccounts.ContainsKey(accountId))
            {
                BankAccountType account = BankApplication.bankAccounts[accountId];
                Console.WriteLine("Enter updated bank account details:");

                Console.Write("Bank Name: ");
                account.BankName = Console.ReadLine();

                Console.Write("Account Type: ");
                account.AccountType = Console.ReadLine();

                Console.Write("Account Number: ");
                account.AccountNumber = Console.ReadLine();

                Console.WriteLine("Bank account details updated successfully.");
            }
            else
            {
                Console.WriteLine("Bank account not found.");
            }
        }

        static void MakeTransaction()
        {
            Console.Write("Enter customer account ID for the transaction: ");
            int customerAccountId = int.Parse(Console.ReadLine());

            if (BankApplication.bankAccounts.ContainsKey(customerAccountId))
            {
                BankAccountType account = BankApplication.bankAccounts[customerAccountId];

                Console.WriteLine("Select transaction type:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                int transactionChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter transaction amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                if (transactionChoice == 1)
                {
                    // Deposit
                    account.Balance += amount;

                    Console.WriteLine("Deposit successful.");

                    // Record transaction
                    BankApplication.transactions.Add(new Transaction
                    {
                        TransactionId = BankApplication.transactionIdCounter++,
                        CustomerAccountId = customerAccountId,
                        TransactionType = "Deposit",
                        Amount = amount,
                        Date = DateTime.Now
                    });
                }
                else if (transactionChoice == 2)
                {
                    // Withdrawal
                    decimal minimumBalance = 10000;

                    if (account.Balance - amount >= minimumBalance)
                    {
                        account.Balance -= amount;
                        Console.WriteLine("Withdrawal successful.");

                        // Record the transaction
                        BankApplication.transactions.Add(new Transaction
                        {
                            TransactionId = BankApplication.transactionIdCounter++,
                            CustomerAccountId = customerAccountId,
                            TransactionType = "Withdrawal",
                            Amount = amount,
                            Date = DateTime.Now
                        });
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance for withdrawal. Minimum balance requirement not met.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid transaction type.");
                }
            }
            else
            {
                Console.WriteLine("Customer account not found.");
            }
        }

        static void DisplayBalance()
        {
            Console.Write("Enter account ID to check balance: ");
            int accountId = int.Parse(Console.ReadLine());

            if (BankApplication.bankAccounts.ContainsKey(accountId))
            {
                BankAccountType account = BankApplication.bankAccounts[accountId];
                Console.WriteLine($"Account Balance for Account ID {account.AccountTypeId}: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Bank account not found.");
            }
        }

        static void DisplayAccountStatement()
        {
            Console.Write("Enter account ID to display the account statement: ");
            int accountId = int.Parse(Console.ReadLine());

            if (BankApplication.bankAccounts.ContainsKey(accountId))
            {
                BankAccountType account = BankApplication.bankAccounts[accountId];

                Console.WriteLine($"Account Statement for Account ID {account.AccountTypeId}:");
                Console.WriteLine("Transaction ID | Transaction Type | Amount | Date");

                var accountTransactions = BankApplication.transactions
                    .Where(t => t.CustomerAccountId == accountId)
                    .OrderBy(t => t.Date);

                foreach (var transaction in accountTransactions)
                {
                    Console.WriteLine($"{transaction.TransactionId} | {transaction.TransactionType} | {transaction.Amount:C} | {transaction.Date}");
                }
            }
            else
            {
                Console.WriteLine("Bank account not found.");
            }
        }
    }
}

