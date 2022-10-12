using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    [DataContract()]
    public class Admin : Staff
    {
        [DataMember()]
        public string Privelage { get; set; }
        public Admin() : base() { }
        public Admin(int empolyee_ID, string name, string address, string email, long phone, string priv) : base(empolyee_ID, name, address, email, phone, "admin")
        {
            this.Privelage = priv;
        }

        public void update(int staffid, string inputname, string addr, string email, long phone, string prv)
        {
            // read input details
            Staff_ID = staffid;
            Name = inputname;
            Address = addr;
            Email = email;
            Phone = phone;
            Privelage = prv;

        }
        public override string Print()
        {
            return base.Print() + "Privelage: " + Privelage + "\n";
        }

    }
}
