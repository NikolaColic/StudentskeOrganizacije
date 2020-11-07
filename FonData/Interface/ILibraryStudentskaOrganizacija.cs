using FonData.Models;
using FonData.Models.AsocijativneKlase;
using FonData.Models.SlabeKlase;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Interface
{
    public interface ILibraryStudentskaOrganizacija
    {
        IEnumerable<StudentskaOrganizacija> GetOrganizacije();
        StudentskaOrganizacija VratiOrganizacijuId(int? id);
        bool AddStudentskuOrganizaciju(StudentskaOrganizacija organizacija);
        bool UpdateStudentskuOrganizaciju(int id, StudentskaOrganizacija organizacija);
        bool DeleteStudentskuOrganizaciju(int id);

        //  Prva asocijativna klasa
        IEnumerable<DrustveneOrganizacija> VratiUrlMreza(int id);

        // Druga asocijativna klasa 
        IEnumerable<Student> VratiClanoveOrganizacije(int id);

        //Treca asocijativna klasa 
        IEnumerable<Student> VratiSubscribeOrganizacije(int id);

        //Obavestenja 
        IEnumerable<Obavestenje> VratiObavestenja(int id);
        bool DodajObavestenje(Obavestenje obavestenje);
        bool UpdateObavestenje(int id, Obavestenje obavestenje);
        bool ObrisiObavestenje(Obavestenje o);

        //Post 

        IEnumerable<Post> VratiPostove(int id);
        bool DodajPost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(int organizacijaId, int postId);

        //Projekat

        IEnumerable<Projekat> VratiProjekte(int id);
        bool AddProjekat(int id, Projekat projekat);
        bool UpdateProjekat(int id, Projekat projekat);
        bool DeleteProjekat(int organizacijaId, int projekatId);

        //Slika 

        IEnumerable<Slika> VratiSlike(int id);

        //Organizacija info 

        OrganizacijaInfo VratiOrganizacijaInfo(int id);








    }
}
