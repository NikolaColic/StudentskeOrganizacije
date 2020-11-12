using FonData.Models.AsocijativneKlase;
using FonData.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FonData.Interface
{
    public interface ILibrarySubscribe
    {
        Task<IEnumerable<Subscribe>> GetSubscribe();
        Task<bool> AddSubscribe(SubscribeCreate subscribe);
        Task<bool> UpdateSubscribe(int id, SubscribeCreate subscribe);
        Task<bool> DeleteSubscribe(Subscribe s);
    }
}
