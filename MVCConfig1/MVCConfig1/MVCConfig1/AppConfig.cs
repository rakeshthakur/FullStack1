using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCConfig1
{
    public class AppConfig
    {
        public AppConfig()
        {
            this.UserInfo = new UserInfo();
        }
        public string ConnectionString { get; set; }

        public string ServerUrl { get; set; }

        public int Port { get; set; }
        public UserInfo UserInfo { get; set; }
    }

    public class UserInfo
    {
        public string Designation { get; set; }
        public string Location { get; set; }
    }
}
