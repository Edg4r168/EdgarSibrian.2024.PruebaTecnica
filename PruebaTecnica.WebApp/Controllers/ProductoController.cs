using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaTecnica.BL;
using PruebaTecnica.EN;

namespace PruebaTecnica.WebApp.Controllers;

public class ProductoController : Controller
{
    private readonly ProductoBL _productoBL;

    private readonly CategoriaBL _categoriaBL;

    public ProductoController(ProductoBL productoBL, CategoriaBL categoriaBL)
    {
        _productoBL = productoBL;
        _categoriaBL = categoriaBL;
    }

    // GET: ProductoController
    public async Task<ActionResult> Index()
    {
        return View(await _productoBL.GetAllAsync());
    }

    // GET: ProductoController/Create
    public async Task<ActionResult> Create()
    {
        var categories = await _categoriaBL.GetAllAsync();

        ViewBag.Categorias = new SelectList(categories, "Id", "Nombre");
        return View();
    }

    // POST: ProductoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Producto producto)
    {
        try
        {
            await _productoBL.CreateAsync(producto);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ProductoController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var categories = await _categoriaBL.GetAllAsync();

        ViewBag.Categorias = new SelectList(categories, "Id", "Nombre");

        return View(await _productoBL.GetAsync(id));
    }

    // POST: ProductoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Producto producto)
    {
        try
        {
            await _productoBL.UpdateAsync(producto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ProductoController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        return View(await _productoBL.GetAsync(id));
    }

    // POST: ProductoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Remove(int id)
    {
        try
        {
            await _productoBL.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
