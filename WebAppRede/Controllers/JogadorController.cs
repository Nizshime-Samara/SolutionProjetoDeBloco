using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplication.ViewModels;

using Aplication.AppServices;
using Domain.Model.Interfaces.Services;

namespace WebAppRede.Controllers
{
    public class JogadorController : Controller
    {
        //private readonly JogoContext _context;
        private readonly IJogadorAppService _jogadorAppService;
        private readonly IBlobService _blobService;

        public JogadorController(IJogadorAppService jogadorAppService, IBlobService blobService)
        {
            _jogadorAppService = jogadorAppService;
            _blobService = blobService;
        }

        // GET: Jogador
        public async Task<IActionResult> Index()
        {
            return View(await _jogadorAppService.GetAllAsync(null));
        }

        // GET: Jogador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogadorVM = await _jogadorAppService.GetByIdAsync(id.Value);
            if (jogadorVM == null)
            {
                return NotFound();
            }

            return View(jogadorVM);
        }

        // GET: Jogador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JogadorVM jogadorVM)
        {
            if (ModelState.IsValid)
            {
                
                await _jogadorAppService.AddAsync(jogadorVM);
                return RedirectToAction(nameof(Index));
            }
            return View(jogadorVM);
        }

        // GET: Jogador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogadorVM = await _jogadorAppService.GetByIdAsync(id.Value);
            if (jogadorVM == null)
            {
                return NotFound();
            }
            return View(jogadorVM);
        }

        // POST: Jogador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JogadorVM jogadorVM)
        {
            if (id != jogadorVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _jogadorAppService.EditAsync(jogadorVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorVMExists(jogadorVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogadorVM);
        }

        // GET: Jogador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogadorVM = await _jogadorAppService.GetByIdAsync(id.Value);
              
            if (jogadorVM == null)
            {
                return NotFound();
            }

            return View(jogadorVM);
        }

        // POST: Jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogadorvm = await _jogadorAppService.GetByIdAsync(id);
            await _jogadorAppService.RemoveAsync(jogadorvm);
            
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorVMExists(int id)
        {
            return _jogadorAppService.GetByIdAsync(id) != null;
        }
    }
}
