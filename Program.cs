using System;
using System.Collections.Generic;

namespace Banking
{
    public class Account{
        public double balance{get;set;}
        public string name { get; set; }// commet added by vahab maner prn 003
        public Account(double amount)
        {
            this.balance=amount;
        }
        public void Deposit(double amount)
        {
            this.balance+=amount;
        }
        public void Withdrow(double amount)
        {
            this.balance-=amount;
        }
    }
    public class program
    {
        public static void main(string []args)
        {
            Console.WriteLine("HELLO From Vyankatesh Nakate");
        }
    }
}