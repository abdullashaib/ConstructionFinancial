using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.Testing
{
    public class AccountGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        
    }
}
