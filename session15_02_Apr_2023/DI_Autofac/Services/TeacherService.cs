using DI_Autofac.IServices;
using DI_Autofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Autofac.Services
{
    public class TeacherService : ITeacherService
    {
        public int DeleteTeacher(int id)
        {
            Console.WriteLine("Teacher Deleted Successfully!\n");
            return 0;
        }

        public List<Teacher> GetAllTeachers()
        {
            Console.WriteLine("All Teachers are!\n");
            return new List<Teacher>();
        }

        public Teacher GetTeacherById(int id)
        {
            Console.WriteLine("Teacher found!\n");
            return null;
        }

        public Teacher saveteacher(Teacher teacher)
        {
            Console.WriteLine("Teacher Saved Successfully!\n");
            return null;
        }
    }
}
