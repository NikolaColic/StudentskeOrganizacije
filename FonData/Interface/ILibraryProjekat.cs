using FonData.Models.SlabeKlase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FonData.Interface
{
    public interface ILibraryProjekat
    {
        Task<IEnumerable<Projekat>> VratiProjekte();
    }
}
