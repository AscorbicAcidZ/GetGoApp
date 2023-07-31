using System;
using System.Collections.Generic;
using System.Text;

namespace GetGoApp.Class
{
    public class AppData
    {
        private static AppData _instance;
        public string Details { get; set; }
        public string Link { get; set; }
        public string SignupDetails { get; set; }

        private AppData() { }

        public static AppData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppData();
                return _instance;
            }
        }
    }
}
