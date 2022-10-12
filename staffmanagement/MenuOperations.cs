using System;
using System.Collections.Generic;
using Library;

namespace StaffManagement
{
    class MenuOperations
    {

        public int ShowMainMenu()
        {
            Console.WriteLine("Please enter your choice");
            Console.WriteLine("1)Add a Staff ");
            Console.WriteLine("2)View Details of all or one specifc staff");
            Console.WriteLine("3)Update Details of a Staff ");
            Console.WriteLine("4)Delete a staff");
            Console.WriteLine("5)to exit");
            int input1 = Convert.ToInt32(Console.ReadLine());
            return input1;
        }
        public Staff CreateStaff()
        {
            Console.WriteLine("Which staff do you want to add \nPress 1 for support staff\n2 for teaching\n3 for admin staff ");
            int input2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter staff_id");
            int Staff_ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter staff name");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter staff address");
            string addr = Console.ReadLine();
            Console.WriteLine("Please enter staff email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter staff phone N.O");
            long ph = Convert.ToInt32(Console.ReadLine());

            Staff sf = null;


            if (input2.Equals(1))
            {
                Console.WriteLine("Please enter staff position");
                string position = Console.ReadLine();
                sf = new Support(Staff_ID, name, addr, email, ph, position);
                

            }
            else if (input2.Equals(2))
            {
                Console.WriteLine("Please enter experience");
                int exp = Convert.ToInt32(Console.ReadLine());
                sf = new Teaching(Staff_ID, name, addr, email, ph, exp);
                
            }
            else if (input2.Equals(3))
            {
                Console.WriteLine("Please enter privelage level");
                string priv = Console.ReadLine();
                sf = new Admin(Staff_ID, name, addr, email, ph, priv);
               
            }
            else if (input2.Equals(5))
            {
                Console.WriteLine("xxxxxxxx  returning to main menu  xxxxxxxx");
                //goto Main Menu;
            }




            else
            {
                Console.WriteLine("wrong choice");
                return null;
            }
            return sf;
        }

        public void ViewStaff(List<Staff> employee)
        {
           
            foreach(Staff e in employee)
            {
                ViewStaff(e);
            }

        }

        public void ViewStaffByType(string type,List<Staff> staffs)
        {
            foreach(Staff e in staffs)
            {
                if (e.Type == type)
                {
                    ViewStaff(e);
                }
            }
        }
            
        public void ViewStaff(Staff staff)
        {
            Console.WriteLine(staff.Print());
        } 

        public void UpdateStaff(List<Staff> employee)
        {
            Console.WriteLine("enter staff id to be updated");
            int staffid = Convert.ToInt32(Console.ReadLine());
            Staff s = null;

            foreach (Staff e in employee)
            {
                if (e.Staff_ID == staffid)
                {
                    s = e;
                }
            }

            Console.WriteLine("Please enter staff name");
            string new_name = Console.ReadLine();
            Console.WriteLine("Please enter staff address");
            string new_addr = Console.ReadLine();
            Console.WriteLine("Please enter staff email");
            string new_email = Console.ReadLine();
            Console.WriteLine("Please enter staff phone N.O");
            long new_ph = Convert.ToInt32(Console.ReadLine());
            s.Update(new_name, new_addr, new_email, new_ph);
            if (s is Teaching)
            {
                Console.WriteLine("enter unique attr value");
                int new_exp = Convert.ToInt32(Console.ReadLine());
                Teaching t = s as Teaching;
                t.Experience = new_exp;
                s = t;
            }
            else if (s is Admin)
            {
                Console.WriteLine("enter unique attr value");
                string new_priv = Console.ReadLine();
                Admin t = s as Admin;
                t.Privelage = new_priv;
                s = t;
            }
            else if (s is Support)
            {
                Console.WriteLine("enter unique attr value");
                string new_pos = Console.ReadLine();
                Support t = s as Support;
                t.Position = new_pos;
                s = t;
            }
            else
                Console.WriteLine("wrong choice");
        }
        public void DeleteStaff(List<Staff> employee)
        {
            Console.WriteLine("Enter emp id to delete");
            int emp_id = Convert.ToInt32(Console.ReadLine());
            employee.RemoveAll(e => e.Staff_ID == emp_id);
        }
       
        
    }
}


