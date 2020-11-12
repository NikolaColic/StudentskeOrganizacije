using FonData;
using FonData.Helpers;
using FonData.Interface;
using FonData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonService.Service
{
    public class LibraryStudent : ILibraryStudent
    {
        private readonly ApplicationDbContext _db;


        public LibraryStudent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Student> PrijaviKorisnika(string username, string password)
        {
            try
            {
                var student = await _db.Student.SingleOrDefaultAsync((stud) => stud.Username.Equals(username));
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

        public async Task<bool> AddStudent(StudentRegister student)
        {
            try
            {
                Student s = await CreateStudent(student);

                _db.Add(s);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<Student> CreateStudent(StudentRegister register)
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

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                var student = await VratiStudenta(id);
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

        public async Task<bool> UpdateStudent(StudentRegister student)
        {
            try
            {
                var studentUpdate = await VratiStudenta(student.StudentId);
                if (studentUpdate is null) return false;
                student.StudentId = student.StudentId;
                Student studentNov = await CreateStudent(student);
                _db.Entry(studentUpdate).CurrentValues.SetValues(studentNov);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<StudentskaOrganizacija>> VratiOrganizacijeClan(Student st)
        {
            try
            {

                var student = await VratiStudenta(st.StudentId);
                if (student is null) return null;
                var ogranizacije = await _db.ClanOrganizacije
                    .Where((clan) => clan.Student.StudentId == st.StudentId)
                    .Select((clan) => clan.StudentskaOrganizacija)
                    .ToListAsync();
                return ogranizacije;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<Student> VratiStudenta(int id)
        {
            try
            {
                var student = await _db.Student.SingleOrDefaultAsync(student2 => student2.StudentId == id);
                return student;
            }
            catch (Exception)
            {
                return null;
            }
        }
       
        public async Task<IEnumerable<Student>> VratiStudente()
        {
            try
            {
                var studenti =await _db.Student.ToListAsync();
                return studenti;
            }
            catch (Exception)
            {
                return null;
            }
              
        }
       
        public async Task<IEnumerable<StudentskaOrganizacija>> VratiSubscribeStudenta(int id)
        {
            try
            {

                var student = await VratiStudenta(id);
                if (student is null) return null;
                var subscribe = await _db.Subscribe
                    .Where((clan) => clan.Student.StudentId == id)
                    .Select((clan) => clan.StudentskaOrganizacija)
                    .Include((org) => org.Predsednik)
                    .ToListAsync(); 
                return subscribe;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<IEnumerable<Student>> PronadjiStudente(string kriterijumPretrage)
        {
            try
            {
                var studenti = await VratiStudente();
                studenti.Where((stud) => stud.Ime.Contains(kriterijumPretrage) || stud.Prezime.Contains(kriterijumPretrage)
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
