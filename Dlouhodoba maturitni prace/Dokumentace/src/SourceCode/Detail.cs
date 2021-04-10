public async Task<IActionResult> UserOverview(string? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var user = await _context.Users
        .Include(c => c.Class)
        .AsNoTracking()
        .FirstOrDefaultAsync(u => u.Id == id);
    if (user == null)
    {
        return NotFound();
    }

    return View(user);
}