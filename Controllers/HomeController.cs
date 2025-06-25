using Microsoft.AspNetCore.Mvc;
using Ukolnicek.Models;
using Ukolnicek.Data;
using System;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var ukoly = _context.vsechnyukoly
            .Where(u => !u.Smazano)
            .OrderBy(u => u.Datum)
            .ToList();

        return View(ukoly);
    }

   

    public IActionResult NovyUkol()
    {
        return View(new Ukol());
    }

    [HttpPost]
    public IActionResult NovyUkol(Ukol item)
    {
        if (ModelState.IsValid)
        {
            // Pøevod z lokálního èasu (z formuláøe) na UTC
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            ViewBag.Zkouska = item.Datum.ToShortTimeString();
            item.Datum = TimeZoneInfo.ConvertTimeToUtc(item.Datum, timeZone);

            _context.vsechnyukoly.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(item);
    }


    public IActionResult Dokoncit(int id)
    {
        var ukol = _context.vsechnyukoly.FirstOrDefault(u => u.Id == id);
        if (ukol != null)
        {
            ukol.Hotovo = true;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Smazat(int id)
    {
        var ukol = _context.vsechnyukoly.FirstOrDefault(u => u.Id == id);
        if (ukol != null)
        {
            ukol.Smazano = true;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    public IActionResult Smazane()
    {
        var ukoly = _context.vsechnyukoly.Where(s => s.Smazano == true).ToList();
        

        return View(ukoly);
    }

    public IActionResult PocetUkolu()
    {
        var pocet = _context.vsechnyukoly.Count();
        ViewData["PocetUkolu"] = pocet;
        return View();

    }



}
