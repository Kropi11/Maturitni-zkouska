public async Task<IActionResult> UserDelete(string? id,
bool? saveChangesError = false)
{
    if (id == null)
    {
        return NotFound();
    }
    var user = await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);
    if (user == null)
    {
        return NotFound();
    }
    if (saveChangesError.GetValueOrDefault())
    {
        ViewData["ErrorMessage"] =
            "Smazání se nezdařilo. Zkuste to znovu později "
            + "a pokud problém přetrvává, " +
            "obraťte se na správce systému.";
    }
    return View(user);
}