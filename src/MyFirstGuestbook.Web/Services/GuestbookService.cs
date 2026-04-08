using MyFirstGuestbook.Web.Models;

namespace MyFirstGuestbook.Web.Services;

public class GuestbookService
{
    private readonly List<GuestbookEntry> _entries = [];
    private int _nextId = 1;

    public IReadOnlyList<GuestbookEntry> GetEntries() =>
        _entries.OrderByDescending(e => e.CreatedAt).ToList();

    public void AddEntry(string name, string message)
    {
        _entries.Add(new GuestbookEntry
        {
            Id = _nextId++,
            Name = name,
            Message = message,
            CreatedAt = DateTime.UtcNow
        });
    }
}
