using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Runtime.Serialization;

namespace staffmanagement.DataLayer

{
    class XmlDataLayer : IData
    {

        //C:\Users\admin\Source\Repos\staffmanagement
        public string Filepath { get; } = "C:\\Users\\admin\\Source\\Repos\\staffmanagement\\staff.xml";

        public void WriteAll(List<Staff> allstaffs)
        {
            if (File.Exists(Filepath)) File.Delete(Filepath);
            FileStream fs = new FileStream(Filepath, FileMode.Create);

            // For Formatting
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.CloseOutput = true;

            XmlWriter writer = XmlWriter.Create(fs, settings);

            DataContractSerializer ser = new DataContractSerializer(typeof(List<Staff>));

            ser.WriteObject(writer, allstaffs);
            writer.Close();
            fs.Close();

        }
        public List<Staff> Read()
        {
            List<Staff> staffs = new List<Staff>();

            if (File.Exists(Filepath))
            {
                FileStream fs = new FileStream(Filepath, FileMode.Open);

                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Staff>));

                staffs = (List<Staff>)serializer.ReadObject(reader, true);

                fs.Close();
                reader.Close();
            }
       
            return staffs;
            


        }


        public void Create(Staff staffToCreate)
        {
            //List<Staff> allStaffs = new List<Staff>();
           List<Staff> allStaffs = Read();
            allStaffs.Add(staffToCreate);
            WriteAll(allStaffs);
        }

        public void Update(Staff staffToUpdate)
        {
            List<Staff> allStaffs = Read();
            var getStaff = allStaffs.Find(x => x.Staff_ID == staffToUpdate.Staff_ID);

            if (getStaff != null)
            {
                allStaffs.Remove(getStaff);
                allStaffs.Add(staffToUpdate);
            }
            WriteAll(allStaffs);
        }

        public void Delete(int staffIdToDelete)
        {
            List<Staff> allStaffs = Read();
            allStaffs.RemoveAll(e => e.Staff_ID == staffIdToDelete);
            WriteAll(allStaffs);
        }

        public List<Staff> ReadAll()
        {
            List<Staff> allStaffs = Read();
            return allStaffs;
        }

        public Staff Read(int staffIdToRead)
        {
            List<Staff> allStaffs = Read();
            var staff = allStaffs.Find(x => x.Staff_ID == staffIdToRead);
            return staff;
            
        }

        public List<Staff> ReadByType(string staffTypeToRead)
        {
            List<Staff> allStaffs = Read();
            var getStaffs = allStaffs.FindAll(x => x.Type == staffTypeToRead);
            return getStaffs;
            throw new NotImplementedException();
        }
    }
        }
    

