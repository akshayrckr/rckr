using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace staffmanagement
{   [Serializable]
    [DataContract()]
    [KnownType (typeof(Admin))]
    [KnownType(typeof(Teaching))]
    [KnownType(typeof(Support))]
    public abstract class Staff
    {
        [DataMember()]
        public int Staff_ID { get; set; }
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public string Address { get; set; }
        [DataMember()]
        public string Email { get; set; }
        [DataMember()]
        public long Phone { get; set; }
        [DataMember()]
        public string Type { get; set; }
        public virtual string Print()
        {
           return "\n\t" + Staff_ID + "\t" + Name + "\t" + Email + "\t" + Phone + "\t" + Address + "\t";

        }
        
       
        public Staff() { }

        public Staff(int Staff_ID, string name, string address, string email, long phone,string type)
        {
            this.Staff_ID = Staff_ID;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            this.Type = type;
        }

        public void Update(string inputname, string addr, string email, long phone)
        {
            // read input details

            Name = inputname;
            Address = addr;
            Email = email;
            Phone = phone;


        }
       
        
        






    }
}
