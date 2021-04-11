public async Task<IActionResult> UsersOverview()
{
    var users = _context.Users
        .Include(c => c.Class)
        .OrderBy(u => u.LastName)
        .AsNoTracking();

    return View(await users.ToListAsync());
}