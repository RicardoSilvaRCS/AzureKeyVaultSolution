using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Cache {
    public class CacheInfo {

        public string Name { get; set; }
        public string Value { get; set; }
        public int TTL { get; set; }    
    }
}
