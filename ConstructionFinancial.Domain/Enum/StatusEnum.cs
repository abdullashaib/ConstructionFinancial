using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Enum
{
    public enum StatusEnum
    {
        New,
        InSpecification, 
        Specified, 
        Confirmed, 
        Scheduled, 
        InProgress,
        InDevelopment, 
        Developed, 
        InTesting, 
        Tested, 
        TestFailed, 
        Closed, 
        OnHold, 
        Rejected
    }
}
