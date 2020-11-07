using FonData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FonData.Interface
{
    public interface ILibraryDrustveneMreze
    {
        IEnumerable<DrustvenaMreza> VratiDrustveneMreze();
        DrustvenaMreza VratiMrezuId(int? id);
    }
}
