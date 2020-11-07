using FonData.Helpers;
using FonData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Interface
{
    public interface ILibraryStudent
    {
        IEnumerable<Student> VratiStudente();
        Student VratiStudenta(int id);
        IEnumerable<StudentskaOrganizacija> VratiSubscribeStudenta(int id);
        IEnumerable<StudentskaOrganizacija> VratiOrganizacijeClan(Student st);
        bool AddStudent(StudentRegister student);
        bool UpdateStudent(StudentRegister student);
        bool DeleteStudent(int id);
        Student PrijaviKorisnika(string username, string password);

    }
}
