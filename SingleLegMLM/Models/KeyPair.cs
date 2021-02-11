using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLegMLM.Models
{
    public class KeyPair
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class KeyPairOpen
    {
        public KeyPairOpen(string val, string text,string roomno)
        {
            Value = val;
            Text = text;
            RoomNo = roomno;
        }
        public string Value { get; set; }
        public string Text { get; set; }
        public string RoomNo { get; set; }
    }
    public class Companies
    {
        public Companies(string account, string name,string country)
        {
            Account = account;
            Name = name;
            Country = country;
        }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
