using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using Library;

namespace Data.Impl
{
    class XmlDataLayer : IData
    {
        string Filepath ; 
        public XmlDataLayer()
        {
            Filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "staff.xml");
        }
        public void WriteAll(List<Staff> allstaffs)
        {
            if (File.Exists(Filepath));
            using (FileStream fs = new FileStream(Filepath, FileMode.Create))
            {
                // For Formatting
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    CloseOutput = true
                };
                using (XmlWriter writer = XmlWriter.Create(fs, settings))
                {

                    DataContractSerializer ser = new DataContractSerializer(typeof(List<Staff>));

                    ser.WriteObject(writer, allstaffs);
                    writer.Close();
                    fs.Close();
                }
            }
        }
        public List<Staff> ReadFromFile()
        {
            List<Staff> staffs = new List<Staff>();

            if (File.Exists(Filepath))
            {
                using (FileStream fs = new FileStream(Filepath, FileMode.Open))
                {

                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                    {

                        DataContractSerializer serializer = new DataContractSerializer(typeof(List<Staff>));

                        staffs = (List<Staff>)serializer.ReadObject(reader, true);

                        fs.Close();
                        reader.Close();
                    }
                }
            }
       
            return staffs;
            


        }


        public void Create(Staff staffToCreate)
        {
            
           List<Staff> allStaffs = ReadFromFile();
            allStaffs.Add(staffToCreate);
            WriteAll(allStaffs);
        }

        public void Update(Staff staffToUpdate)
        {
            List<Staff> allStaffs = ReadFromFile();
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
            List<Staff> allStaffs = ReadFromFile();
            allStaffs.RemoveAll(e => e.Staff_ID == staffIdToDelete);
            WriteAll(allStaffs);
        }

        public List<Staff> ReadAll()
        {
            List<Staff> allStaffs = ReadFromFile();
            return allStaffs;
        }

        public Staff Read(int staffIdToRead)
        {
            List<Staff> allStaffs = ReadFromFile();
            var staff = allStaffs.Find(x => x.Staff_ID == staffIdToRead);
            return staff;
            
        }

        public List<Staff> ReadByType(string staffTypeToRead)
        {
            List<Staff> allStaffs = ReadFromFile();
            var getStaffs = allStaffs.FindAll(x => x.Type == staffTypeToRead);
            return getStaffs;
          
        }
    }
        }
    

