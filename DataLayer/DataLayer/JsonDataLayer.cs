using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using staffmanagement;
using Newtonsoft.Json;

namespace staffmanagement.DataLayer
{
    class JsonDataLayer : IData
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filepath = Path.Combine(path, "employee.json");
       
        public void Create(Staff staffToCreate)
        {
           List<Staff> allStaff = JsonConvert.DeserializeObject<List<Staff>>(File.ReadAllText(filepath), new JsonSerializerSettings
           {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });
            allStaff.Add(staffToCreate);

            JsonSerializer serializer = new JsonSerializer();
          
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, allStaff, typeof(List<Staff>));
            }
        }



        public void Delete(int staffIdToDelete)
        {
            List<Staff> allStaff = JsonConvert.DeserializeObject<List<Staff>>(File.ReadAllText(filepath));
            allStaff.RemoveAll(e => e.Staff_ID == staffIdToDelete);
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(filepath))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, allStaff, typeof(List<Staff>));
            }
        }

        public Staff Read(int staffIdToRead)
        {
            List<Staff> allStaff = JsonConvert.DeserializeObject<List<Staff>>(File.ReadAllText(filepath), new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            }); 
            var staff = allStaff.Find(x => x.Staff_ID == staffIdToRead);
            return staff;
        }

        public List<Staff> ReadAll()
        {
            List<Staff> allStaff = JsonConvert.DeserializeObject<List<Staff>>(File.ReadAllText(filepath), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return allStaff;

        }

        public List<Staff> ReadByType(string staffTypeToRead)
        {
            List<Staff> allStaff = JsonConvert.DeserializeObject<List<Staff>>(File.ReadAllText(filepath), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var getStaffs = allStaff.FindAll(x => x.Type == staffTypeToRead);

            return getStaffs;


        }

        public void Update( Staff staffToUpdate )
        {
            List<Staff> allStaff = JsonConvert.DeserializeObject<List<Staff>>(File.ReadAllText(filepath), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var getStaff = allStaff.Find(x => x.Staff_ID == staffToUpdate.Staff_ID);

            if(getStaff != null)
            { 
                allStaff.Remove(getStaff);
                allStaff.Add(staffToUpdate);
            }
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(filepath))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, allStaff, typeof(List<Staff>));
            }
           
        }
    }
}
