using FonData.Helpers;
using FonData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FonData.Interface
{
    public interface ILibraryStudent
    {
        Task<IEnumerable<Student>> VratiStudente();
        Task<Student> VratiStudenta(int id);
        Task<IEnumerable<StudentskaOrganizacija>> VratiSubscribeStudenta(int id);
        Task<IEnumerable<StudentskaOrganizacija>> VratiOrganizacijeClan(Student st);
        Task<bool> AddStudent(StudentRegister student);
        Task<bool> UpdateStudent(StudentRegister student);
        Task<bool> DeleteStudent(int id);
        Task<Student> PrijaviKorisnika(string username, string password);

    }
}
