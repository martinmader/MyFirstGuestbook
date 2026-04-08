using Microsoft.AspNetCore.Mvc;
using MyFirstGuestbook.Web.Services;

namespace MyFirstGuestbook.Web.Controllers;

public class GuestbookController(GuestbookService guestbookService) : Controller
{
    public IActionResult Index()
    {
        var entries = guestbookService.GetEntries();
        return View(entries);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(string name, string message, string color = "#ffffff")
    {
        if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(message))
            guestbookService.AddEntry(name.Trim(), message.Trim(), color);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        guestbookService.DeleteEntry(id);
        return RedirectToAction(nameof(Index));
    }
}
