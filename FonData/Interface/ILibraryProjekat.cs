using FonData.Models.SlabeKlase;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Interface
{
    public interface ILibraryProjekat
    {
        IEnumerable<Projekat> VratiProjekte();
    }
}
