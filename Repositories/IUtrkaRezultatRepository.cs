using EvidencijaUtrka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.Repositories
{
    public interface IUtrkaRezultatRepository
    {
        IEnumerable<UtrkaRezultat> GetAllOfficialUtrkaRezultat(int? id);
        IEnumerable<UtrkaRezultat> GetAllUnofficialUtrkaRezultat(int? id);
        UtrkaRezultat Add(UtrkaRezultat utrkaRezultat);
        UtrkaRezultat Delete(int? id);
        UtrkaRezultat GetUtrkaRezultat(int? id);
        UtrkaRezultat Update(UtrkaRezultat utrkaRezultat);
    }
}
