using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Interface
{
    public interface ILibraryClan
    {
        IEnumerable<ClanOrganizacije> VratiClanove();
        bool DodajClana(SubscribeCreate subscribe);
        bool DeleteClan(int id);
    }
}
