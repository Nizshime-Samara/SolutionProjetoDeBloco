using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplication.ViewModels;
using Aplication.AppServices;
// nota como possuimos uma view model especifica para esta tela
//, não precisamos do Bind gerado pelo scanfolding tanto no metodo de edit http quanto de create http, (deve retirar para não gerar bug quando execurtar a aplicação no navegador) 

namespace WebAppRede.Controllers
{
    public class JogoController : Controller
    {
        //private readonly JogoContext _context;

        private readonly IJogoAppService _jogoAppService;
        private readonly IJogadorAppService _jogadorAppService;

        public JogoController(IJogoAppService jogoAppService, IJogadorAppService jogadorAppService)
        {
            _jogoAppService = jogoAppService;
            _jogadorAppService = jogadorAppService;
        }

        // GET: Jogador
        public async Task<IActionResult> Index()
        {
            return View(await _jogoAppService.GetAllAsync(null));
        }

        // GET: Jogador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoVM = await _jogoAppService.GetByIdAsync(id.Value);
            if (jogoVM == null)
            {
                return NotFound();
            }

            return View(jogoVM);
        }

        private async Task PopulateSelectJogadores(int? jogadorId = null)
        {
            var jogadores = await _jogadorAppService.GetAllAsync(null);

            ViewBag.Jogadores = new SelectList(
                jogadores,
                nameof(JogadorVM.Id),
                nameof(JogadorVM.Nome),
                jogadorId); //TODO: Exibir Nome + sobrenome + id
        }

        // GET: Jogador/Create
        public async Task<IActionResult> Create()
        {
            await PopulateSelectJogadores();
            return View();
        }

        // POST: Jogador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JogoVM jogoVM)
        {
            if (ModelState.IsValid)
            {

                await _jogoAppService.AddAsync(jogoVM);
                return RedirectToAction(nameof(Index));
            }
            await PopulateSelectJogadores(jogoVM.JogadorId);
            return View(jogoVM);
        }

        // GET: Jogador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoVM = await _jogoAppService.GetByIdAsync(id.Value);
            if (jogoVM == null)
            {
                return NotFound();
            }
            return View(jogoVM);
        }

        // POST: Jogador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JogoVM jogoVM)
        {
            if (id != jogoVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _jogoAppService.EditAsync(jogoVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorVMExists(jogoVM.Id))
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
            return View(jogoVM);
        }

        // GET: Jogador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoVM = await _jogoAppService.GetByIdAsync(id.Value);

            if (jogoVM == null)
            {
                return NotFound();
            }

            return View(jogoVM);
        }

        // POST: Jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogovm = await _jogoAppService.GetByIdAsync(id);
            await _jogoAppService.RemoveAsync(jogovm);

            return RedirectToAction(nameof(Index));
        }

        private bool JogadorVMExists(int id)
        {
            return _jogoAppService.GetByIdAsync(id) != null;
        }
    }
}

