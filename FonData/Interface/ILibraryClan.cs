using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FonData.Interface
{
    public interface ILibraryClan
    {
        Task<IEnumerable<ClanOrganizacije>> VratiClanove();
        bool DodajClana(SubscribeCreate subscribe);
        Task<bool> DeleteClan(int id);
    }
}
