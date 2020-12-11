using EvidencijaUtrka.Models;
using EvidencijaUtrka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.DAL
{
    public class UtrkaRepository : IUtrkaRepository
    {
        private readonly EvidencijaUtrkaDBcontext _context;

        public UtrkaRepository(EvidencijaUtrkaDBcontext context)
        {
            _context = context;
        }
        public Utrka Add(Utrka utrka)
        {
            _context.Utrke.Add(utrka);
            _context.SaveChanges();
            return utrka;
        }

        public IEnumerable<Utrka> GetAllUtrke()
        {
            return _context.Utrke;
        }

        public Utrka GetUtrka(int? id)
        {
            return _context.Utrke.Find(id);
        }
    }
}
