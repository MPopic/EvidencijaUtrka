using EvidencijaUtrka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.Repositories
{
    public interface IUtrkaRepository
    {
        IEnumerable<Utrka> GetAllUtrke();
        Utrka Add(Utrka utrka);
        Utrka GetUtrka(int? id);

    }
}
