using System;
using System.Collections.Generic;
using System.Text;

namespace staffmanagement
{
    interface IData 
    {
        public void Create(Staff staffToCreate);
        public void Update(Staff staffToUpdate);
        public void Delete(int staffIdToDelete);

        public List<Staff> ReadAll();
        public Staff Read(int staffIdToRead);
        public List<Staff> ReadByType(string staffTypeToRead);
        
    }
}
