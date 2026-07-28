using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efcoreApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kurslar = await _context.Kurslar.ToListAsync();
            return View(kurslar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kurs model)
        {
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound(); 
            }
            //findasync sadece is araması
            var kurs = await _context
            .Kurslar
            .Include(k=> k.KursKayitlari)
            .ThenInclude(k=> k.Ogrenci)
            .FirstOrDefaultAsync(k => k.KursId == id);
            
            //var kurs = await _context.Kurslar.FirstOrDefaultAsync(o => o.KursId == id);
            if(kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //formu get metodu ile yükleyen kişi ile post metdu ile post eden kişinin aynı kişi olup olmadığını kontrol eder. 
        public async Task<IActionResult> Edit(int id, Kurs model)
        {
            if(id != model.KursId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                    //any burda herhangi anlamında kullanılır. böyle bir kayıt veritabanında varmı gibi.
                    if(!_context.Kurslar.Any(o => o.KursId == model.KursId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Kurslar.FindAsync(id);

            if(kurs == null)
            {
                return NotFound();
            }

            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var kurs = await _context.Kurslar.FindAsync(id);
            if(kurs == null)
            {
                return NotFound(); 
            }
            _context.Kurslar.Remove(kurs);
            //işlemin veritabanına kayıt olması için
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}