using EvidencijaUtrka.Models;
using EvidencijaUtrka.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaUtrka.DAL
{
    public class UtrkaRezultatRepository : IUtrkaRezultatRepository
    {
        private readonly EvidencijaUtrkaDBcontext _context;

        public UtrkaRezultatRepository(EvidencijaUtrkaDBcontext context)
        {
            _context = context;
        }
        public UtrkaRezultat Add(UtrkaRezultat utrkaRezultat)
        {
            _context.UtrkaRezultati.Add(utrkaRezultat);
            _context.SaveChanges();
            return utrkaRezultat;
        }

        public UtrkaRezultat Delete(int? id)
        {
            UtrkaRezultat rezultat = _context.UtrkaRezultati.Find(id);
            if (rezultat != null)
            {
                _context.UtrkaRezultati.Remove(rezultat);
                _context.SaveChanges();
            }
            return rezultat;
        }

        public IEnumerable<UtrkaRezultat> GetAllOfficialUtrkaRezultat(int? id)
        {
            return _context.UtrkaRezultati.Where(rez => rez.Sluzben == true && rez.UtrkaID == id);
        }

        public IEnumerable<UtrkaRezultat> GetAllUnofficialUtrkaRezultat(int? id)
        {
            return _context.UtrkaRezultati.Where(rez => rez.Sluzben == false && rez.UtrkaID == id);
        }

        public UtrkaRezultat GetUtrkaRezultat(int? id)
        {
            return _context.UtrkaRezultati.Find(id);
        }

        public UtrkaRezultat Update(UtrkaRezultat utrkaRezultatPromjene)
        {
            var utrkaRezultat = _context.UtrkaRezultati.Attach(utrkaRezultatPromjene);
            utrkaRezultat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return utrkaRezultatPromjene;
        }
    }
}
