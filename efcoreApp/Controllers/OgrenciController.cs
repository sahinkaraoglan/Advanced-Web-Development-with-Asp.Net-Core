using System.Net.Http.Headers;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgrenciController: Controller
    {
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        //kayıt listeleme
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogrenciler.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        //Edit formunun çağrıldığı yer.

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound(); 
            }
            //findasync sadece is araması
            var ogr = await _context.Ogrenciler.FindAsync(id);
            //var ogr = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciId == id);
            if(ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //formu get metodu ile yükleyen kişi ile post metdu ile post eden kişinin aynı kişi olup olmadığını kontrol eder. 
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            if(id != model.OgrenciId)
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
                catch(DbUpdateConcurrencyException)
                {
                    //any burda herhangi anlamında kullanılır. böyle bir kayıt veritabanında varmı gibi.
                    if(!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))
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
    }
}