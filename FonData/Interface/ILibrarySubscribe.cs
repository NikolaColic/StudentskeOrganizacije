using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Interface
{
    public interface ILibrarySubscribe
    {
        IEnumerable<Subscribe> GetSubscribe();
        bool AddSubscribe(SubscribeCreate subscribe);
        bool UpdateSubscribe(int id, SubscribeCreate subscribe);
        bool DeleteSubscribe(Subscribe s);
    }
}
