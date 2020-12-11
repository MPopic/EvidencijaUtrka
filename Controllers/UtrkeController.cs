using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencijaUtrka.DAL;
using EvidencijaUtrka.Models;
using EvidencijaUtrka.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace EvidencijaUtrka.Controllers
{
    [Authorize]
    public class UtrkeController : Controller
    {
        private readonly IUtrkaRepository _utrkaContext;
        private readonly IUtrkaRezultatRepository _utrkaRezultatContext;

        public UtrkeController(IUtrkaRepository utrkaContext, IUtrkaRezultatRepository utrkaRezultatContext)
        {
            _utrkaContext = utrkaContext;
            _utrkaRezultatContext = utrkaRezultatContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_utrkaContext.GetAllUtrke().OrderByDescending(u => u.Datum));
        }

        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var utrka = _utrkaContext.GetUtrka(id);
            if (utrka == null)
            {
                return NotFound();
            }
            else
            {
                utrka.Rezultati = _utrkaRezultatContext.GetAllOfficialUtrkaRezultat(id).OrderBy(r => r.RezultatVrijeme).ToList();
            }

            return View(utrka);
        }

        public IActionResult Administracija()
        {
            return View(_utrkaContext.GetAllUtrke().OrderByDescending(u => u.Datum));
        }

        public IActionResult DetailsAdministracija(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var utrka = _utrkaContext.GetUtrka(id);
            if (utrka == null)
            {
                return NotFound();
            }
            else
            {
                utrka.Rezultati = _utrkaRezultatContext.GetAllUnofficialUtrkaRezultat(id).OrderBy(r => r.RezultatVrijeme).ToList();
            }

            return View(utrka);
        }
        
    }
}
