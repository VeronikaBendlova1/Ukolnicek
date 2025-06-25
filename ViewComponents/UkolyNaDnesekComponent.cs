using Microsoft.AspNetCore.Mvc;
using Ukolnicek.Data;

namespace Ukolnicek.ViewComponents
{
    [ViewComponent(Name = "UkolyNaDnesek")]
    public class UkolyNaDnesekViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public UkolyNaDnesekViewComponent(ApplicationDbContext context) 
        {
            _context = context;

        }

        public IViewComponentResult Invoke()
        {
            var dnes = DateTime.UtcNow.Date; // dnešní den v UTC čase
            var zitra = dnes.AddDays(1);

            var ukolyNaDnesek = _context.vsechnyukoly
                .Where(x => x.Datum >= dnes && x.Datum < zitra);

            int pocet = ukolyNaDnesek.Count();

            return View(pocet);
        }



    }
}
