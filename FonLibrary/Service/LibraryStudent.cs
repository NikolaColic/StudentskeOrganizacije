using FonData;
using FonData.Helpers;
using FonData.Interface;
using FonData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FonService.Service
{
    public class LibraryStudent : ILibraryStudent
    {
        private readonly ApplicationDbContext _db;


        public LibraryStudent(ApplicationDbContext db)
        {
            _db = db;
        }

        public Student PrijaviKorisnika(string username, string password)
        {
            try
            {
                var student = _db.Student.SingleOrDefault((stud) => stud.Username.Equals(username));
                if (student is null) return null;
                string passBaza = Encoding.UTF8.GetString(student.PasswordHash);
                if (passBaza != password) return null;
                return student;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool AddStudent(StudentRegister student)
        {
            try
            {
                Student s = CreateStudent(student);

                _db.Add(s);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Student CreateStudent(StudentRegister register)
        {
            Student s = new Student()
            {
                Administrator = register.Administrator,
                Biografija = register.Biografija,
                Email = register.Email,
                GodinaStudija = register.GodinaStudija,
                ImageUrl = register.ImageUrl,
                Ime = register.Ime,
                InstagramUrl = register.InstagramUrl,
                PasswordHash = Encoding.UTF8.GetBytes(register.Password),
                Prezime = register.Prezime,
                Role = "User",
                Status = register.Status,
                StudentId = register.StudentId,
                Username = register.Username

            };
            return s;
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                var student = VratiStudenta(id);
                if (student is null) return false;
                _db.Entry(student).State = EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStudent(StudentRegister student)
        {
            try
            {
                var studentUpdate = VratiStudenta(student.StudentId);
                if (studentUpdate is null) return false;
                student.StudentId = student.StudentId;
                Student studentNov = CreateStudent(student);
                _db.Entry(studentUpdate).CurrentValues.SetValues(studentNov);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<StudentskaOrganizacija> VratiOrganizacijeClan(Student st)
        {
            try
            {

                var student = VratiStudenta(st.StudentId);
                if (student is null) return null;
                var ogranizacije = _db.ClanOrganizacije
                    .Where((clan) => clan.Student.StudentId == st.StudentId)
                    .Select((clan) => clan.StudentskaOrganizacija);

                return ogranizacije;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public Student VratiStudenta(int id)
        {
            try
            {
                var student = _db.Student.SingleOrDefault(student2 => student2.StudentId == id);
                return student;
            }
            catch (Exception)
            {
                return null;
            }
        }
       
        public IEnumerable<Student> VratiStudente()
        {
            try
            {
                var studenti = _db.Student;
                return studenti;
            }
            catch (Exception)
            {
                return null;
            }
              
        }
       
        public IEnumerable<StudentskaOrganizacija> VratiSubscribeStudenta(int id)
        {
            try
            {

                var student = VratiStudenta(id);
                if (student is null) return null;
                var subscribe = _db.Subscribe
                    .Where((clan) => clan.Student.StudentId == id)
                    .Select((clan) => clan.StudentskaOrganizacija)
                    .Include((org) => org.Predsednik);

                return subscribe;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public IEnumerable<Student> PronadjiStudente(string kriterijumPretrage)
        {
            try
            {
                var studenti = VratiStudente()
                        .Where((stud) => stud.Ime.Contains(kriterijumPretrage) || stud.Prezime.Contains(kriterijumPretrage)
                        || stud.Username.Contains(kriterijumPretrage));
                return studenti;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
