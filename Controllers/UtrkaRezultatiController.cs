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
    public class UtrkaRezultatiController : Controller
    {
        private readonly IUtrkaRezultatRepository _utrkaRezultatContext;

        public UtrkaRezultatiController(IUtrkaRezultatRepository utrkaRezultatContext)
        {
            _utrkaRezultatContext = utrkaRezultatContext;
        }        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utrkaRezultat = _utrkaRezultatContext.GetUtrkaRezultat(id);
            if (utrkaRezultat == null)
            {
                return NotFound();
            }

            return View(utrkaRezultat);
        }

        
        [AllowAnonymous]
        public IActionResult Create(int id)
        {
            ViewData["UtrkaId"] = id;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Create([Bind("UtrkaRezultatID,Ime,Prezime,RezultatVrijeme,Sluzben,UtrkaID")] UtrkaRezultat utrkaRezultat)
        {
            utrkaRezultat.Sluzben = false;
            if (ModelState.IsValid)
            {
                _utrkaRezultatContext.Add(utrkaRezultat);
                return RedirectToAction("Details", "Utrke", new {id = utrkaRezultat.UtrkaID});
            }
            ViewData["UtrkaID"] = utrkaRezultat.UtrkaID;
            return View(utrkaRezultat);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utrkaRezultat = _utrkaRezultatContext.GetUtrkaRezultat(id);
            if (utrkaRezultat == null)
            {
                return NotFound();
            }
            return PartialView("_EditRezultatPartial", utrkaRezultat);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UtrkaRezultatID,Ime,Prezime,RezultatVrijeme,Sluzben,UtrkaID")] UtrkaRezultat utrkaRezultat)
        {
            if (id != utrkaRezultat.UtrkaRezultatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _utrkaRezultatContext.Update(utrkaRezultat);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtrkaRezultatExists(utrkaRezultat.UtrkaRezultatID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("DetailsAdministracija", "Utrke", new {id = utrkaRezultat.UtrkaID});
            }            
            return PartialView("_EditRezultatPartial", utrkaRezultat);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utrkaRezultat = _utrkaRezultatContext.GetUtrkaRezultat(id);
            if (utrkaRezultat == null)
            {
                return NotFound();
            }

            return View(utrkaRezultat);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            int utrkaId = _utrkaRezultatContext.GetUtrkaRezultat(id).UtrkaID;
            bool sluzben = _utrkaRezultatContext.GetUtrkaRezultat(id).Sluzben;
            var utrkaRezultat = _utrkaRezultatContext.Delete(id);
            if (sluzben)
            {
                return RedirectToAction("Details", "Utrke", new { id = utrkaId });
            }
            else
            {
                return RedirectToAction("DetailsAdministracija", "Utrke", new { id = utrkaId });
            }
            
        }

        private bool UtrkaRezultatExists(int id)
        {
            return _utrkaRezultatContext.GetUtrkaRezultat(id) != null;
        }
    }
}
