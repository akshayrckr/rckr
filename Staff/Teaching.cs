using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    [DataContract()]
    public class Teaching : Staff
    {
        [DataMember()]
        public int Experience { get; set; }
        public Teaching() : base() { }

        public Teaching(int empolyee_ID, string name, string address, string email, long phone, int exp) : base(empolyee_ID, name, address, email, phone,"Teaching")
        {
            this.Experience = exp;
        }

        public override string Print()
        {
            return base.Print() + "Experience: " + Experience+"\n";
        }
        public void Tupdate(string inputname, string addr, string email, long phone, int exp)
        {
            // read input details

            Name = inputname;
            Address = addr;
            Email = email;
            Experience = exp;

        }

    }
}
