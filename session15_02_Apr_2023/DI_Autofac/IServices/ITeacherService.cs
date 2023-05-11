using DI_Autofac.Models;

namespace DI_Autofac.IServices
{
    public interface ITeacherService
    {
        Teacher saveteacher(Teacher teacher);   
        int DeleteTeacher(int id);
        List<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
    }
}
