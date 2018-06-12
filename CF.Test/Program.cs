using ConstructionFinancial.DataEntity;
using ConstructionFinancial.Domain.GeneralLedger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Test
{
    class Program
    {
        

        
        static void Main(string[] args)
        {
            TrialBalanceRepository balance = new TrialBalanceRepository();

            balance.Insert(new TrialBalance() { });
        }
    }
}
