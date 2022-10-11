using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    [DataContract()]
    public class Support : Staff
    {
        [DataMember()]
        public string Position { get; set; }
        public Support() : base() { }
        public override string Print()
        {
            return base.Print() + "Position:" + Position + "\n";
        }
        public Support(int empolyee_ID, string name, string address, string email, long phone, string position) : base(empolyee_ID, name, address, email, phone,"Support") { this.Position = position; }
    }


}
