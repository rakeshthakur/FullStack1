using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSession
{
    public class SessionStore
    {
        public string Name { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
