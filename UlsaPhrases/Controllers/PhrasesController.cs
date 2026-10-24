
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UlsaPhrases.Models;
using UlsaPhrases.Data;

public class PhrasesController : Controller
{
    private readonly ApplicationDbContext _context;

    public PhrasesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PHRASES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Phrase.ToListAsync());
    }

    // GET: PHRASES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phrase = await _context.Phrase
            .FirstOrDefaultAsync(m => m.Id == id);
        if (phrase == null)
        {
            return NotFound();
        }

        return View(phrase);
    }

    // GET: PHRASES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PHRASES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PhraseStatement,PhraseAuthor,PhraseDedication,PhraseDate,PhraseContext")] Phrase phrase)
    {
        if (ModelState.IsValid)
        {
            _context.Add(phrase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(phrase);
    }

    // GET: PHRASES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phrase = await _context.Phrase.FindAsync(id);
        if (phrase == null)
        {
            return NotFound();
        }
        return View(phrase);
    }

    // POST: PHRASES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,PhraseStatement,PhraseAuthor,PhraseDedication,PhraseDate,PhraseContext")] Phrase phrase)
    {
        if (id != phrase.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(phrase);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhraseExists(phrase.Id))
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
        return View(phrase);
    }

    // GET: PHRASES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phrase = await _context.Phrase
            .FirstOrDefaultAsync(m => m.Id == id);
        if (phrase == null)
        {
            return NotFound();
        }

        return View(phrase);
    }

    // POST: PHRASES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var phrase = await _context.Phrase.FindAsync(id);
        if (phrase != null)
        {
            _context.Phrase.Remove(phrase);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PhraseExists(int? id)
    {
        return _context.Phrase.Any(e => e.Id == id);
    }
}
