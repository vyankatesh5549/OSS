using System;
using System.Collections.Generic;

namespace Banking
{

    public delegate void AccountOperation();
    
    public class Account{
        public double balance{get;set;}
        public string name { get; set; }// commet added by vahab maner prn 003
        public event AccountOperation underBalance;
        public event AccountOperation overBalance;
        public Account(double amount)
        {
            this.balance=amount;
            if(this.balance<=5000)
            {
                underBalance();
            }
            else if(this.balance>=250000)
            {

            overBalance();

            }
        }
        public void Deposit(double amount)
        {
            this.balance+=amount;
            if(this.balance<=5000)
            {
                underBalance();
            }
            else if(this.balance>=250000)
            {

            overBalance();

            }
        }
        public void Withdrow(double amount)
        {
            this.balance-=amount;
            if(this.balance<=5000)
            {
                underBalance();
            }
            else if(this.balance>=250000)
            {

            overBalance();

            }
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