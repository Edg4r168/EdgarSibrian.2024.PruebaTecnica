using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.BL;
using PruebaTecnica.EN;

namespace PruebaTecnica.WebApp.Controllers;

public class CategoriaController : Controller
{
    private readonly CategoriaBL _categoriaBL;

    public CategoriaController(CategoriaBL categoriaBL)
    {
        _categoriaBL = categoriaBL;
    }

    // GET: CategoriaController
    public async Task<ActionResult> Index()
    {
        return View(await _categoriaBL.GetAllAsync());
    }

    // GET: CategoriaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CategoriaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Categoria categoria)
    {
        try
        {
            await _categoriaBL.CreateAsync(categoria);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CategoriaController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        return View(await _categoriaBL.GetAsync(id));
    }

    // POST: CategoriaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Categoria categoria)
    {
        try
        {
            await _categoriaBL.UpdateAsync(categoria);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CategoriaController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        return View(await _categoriaBL.GetAsync(id));
    }

    // POST: CategoriaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Remove(int id)
    {
        try
        {
            await _categoriaBL.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
