using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TarefaCRUD.Models;

namespace TarefaCRUD.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaDBContext _context;

        public TarefaController(TarefaDBContext context)
        {
            _context = context;
        }

        // GET: Tarefa
        public async Task<IActionResult> Index()
        {
            var tarefaDBContext = _context.Tarefas.Include(t => t.IdPessoaNavigation);
            return View(await tarefaDBContext.ToListAsync());
        }

        // GET: Tarefa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .Include(t => t.IdPessoaNavigation)
                .FirstOrDefaultAsync(m => m.IdTarefa == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefa/Create
        public IActionResult Create()
        {
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "NomePessoa");
            ViewData["Prioridade"] = new SelectList(Enum.GetValues(typeof(PrioridadeEnum)), "Value", "ToString");
            return View();
        }

        // POST: Tarefa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarefa,Descricao,DataInicio,Prazo,IdPessoa,Prioridade")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "IdPessoa", tarefa.IdPessoa);
            ViewData["Prioridade"] = new SelectList(Enum.GetValues(typeof(PrioridadeEnum)), "Value", "ToString", tarefa.Prioridade);
            return View(tarefa);
        }

        // GET: Tarefa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "NomePessoa", tarefa.IdPessoa);
            ViewData["Prioridade"] = new SelectList(Enum.GetValues(typeof(PrioridadeEnum)), "Value", "ToString", tarefa.Prioridade);
            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarefa,Descricao,DataInicio,Prazo,IdPessoa,Prioridade")] Tarefa tarefa)
        {
            if (id != tarefa.IdTarefa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.IdTarefa))
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
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "NomePessoa", tarefa.IdPessoa);
            ViewData["Prioridade"] = new SelectList(Enum.GetValues(typeof(PrioridadeEnum)), "Value", "ToString", tarefa.Prioridade);
            return View(tarefa);
        }

        // GET: Tarefa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
    .Include(t => t.IdPessoaNavigation)
    .FirstOrDefaultAsync(m => m.IdTarefa == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarefas == null)
            {
                return Problem("Entity set 'TarefaDBContext.Tarefas'  is null.");
            }
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaExists(int id)
        {
            return (_context.Tarefas?.Any(e => e.IdTarefa == id)).GetValueOrDefault();
        }
    }
}
