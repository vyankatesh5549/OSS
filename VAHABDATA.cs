using System;
using System.Collections.Generic;

namespace Vahab
{


    public class Account
    {
        public double balance { get; set; }
        public string name { get; set; }// commet added by vahab maner prn 003
        public event AccountOperation underBalance;
        public event AccountOperation overBalance;
        public Account(double amount)
            }
}