using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Library;

namespace StaffManagement
{
    class Program
    {
        static void Main(string[] args)
        { 
            string dllpath = "C:/Users/admin/Source/Repos/staffmanagement/rckr/Data/bin/Debug/netcoreapp3.1/StaffManagement.DataLayer.dll";
            Assembly assembly = Assembly.LoadFile(dllpath);
            IData dataLayer = null;
            MenuOperations menu = new MenuOperations();
            string file = ConfigurationManager.AppSettings["file"];
            Type type = assembly.GetType(file);
            dataLayer = Activator.CreateInstance(type) as IData;
            Console.WriteLine("Staff Managment System");

            while (true)
            {
                //Main_Menu:
                switch (menu.ShowMainMenu())
                {
                    case 1:
                        Staff staffToCreate = menu.CreateStaff();
                        dataLayer.Create(staffToCreate);

                        break;

                    case 2:
                        Console.WriteLine("write option to view staff\t\tpress 1 for all staff\n2for one staff by staffid\n3staff by department ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice.Equals(1))
                        {
                            var allStaff = dataLayer.ReadAll();
                            menu.ViewStaff(allStaff);
                        }
                        else if (choice.Equals(2))
                        {
                            Console.WriteLine("write id to be searched ");
                            int staffIdToBeSearched = Convert.ToInt32(Console.ReadLine());
                            Staff staff = dataLayer.Read(staffIdToBeSearched);
                            menu.ViewStaff(staff);


                        }
                        else if (choice.Equals(3))
                        {
                            Console.WriteLine("write department to view ");
                            string dep = Console.ReadLine();
                            List<Staff> staffs = dataLayer.ReadByType(dep);
                            menu.ViewStaff(staffs);
                        }

                        break;

                    case 3:
                        Console.WriteLine("staff id to be updated");
                        int staffId = Convert.ToInt32(Console.ReadLine());
                        Staff staffWithId = dataLayer.Read(staffId);
                        if (staffWithId == null)
                        {
                            Console.WriteLine("staff id not found");
                        }
                        else
                        {
                            Console.WriteLine("Please enter staff name");
                            string new_name = Console.ReadLine();
                            Console.WriteLine("Please enter staff address");
                            string new_addr = Console.ReadLine();
                            Console.WriteLine("Please enter staff email");
                            string new_email = Console.ReadLine();
                            Console.WriteLine("Please enter staff phone N.O");
                            long new_ph = Convert.ToInt32(Console.ReadLine());
                            staffWithId.Update(new_name, new_addr, new_email, new_ph);
                            if (staffWithId is Teaching)
                            {
                                Console.WriteLine("enter unique attr value");
                                int new_exp = Convert.ToInt32(Console.ReadLine());
                                Teaching t = staffWithId as Teaching;
                                t.Experience = new_exp;

                            }
                            else if (staffWithId is Admin)
                            {
                                Console.WriteLine("enter unique attr value");
                                string new_priv = Console.ReadLine();
                                Admin t = staffWithId as Admin;
                                t.Privelage = new_priv;

                            }
                            else if (staffWithId is Support)
                            {
                                Console.WriteLine("enter unique attr value");
                                string new_pos = Console.ReadLine();
                                Support t = staffWithId as Support;
                                t.Position = new_pos;

                            }
                            dataLayer.Update(staffWithId);
                        }
                        break;

                    case 4:
                        Console.WriteLine("write id to be deletd ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Staff searchedStaff = dataLayer.Read(id);
                        if (searchedStaff == null)
                        {
                            Console.WriteLine("staff does not exist");
                        }
                        else
                        {
                            dataLayer.Delete(id);
                        }
                        break;

                    case 5:
                        Console.WriteLine("5 Press");
                        Console.Clear();
                        System.Environment.Exit(0);
                        break;

                }

            }
        }
    }
}

    



