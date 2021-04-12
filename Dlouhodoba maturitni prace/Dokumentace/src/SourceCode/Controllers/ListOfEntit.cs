public async Task<IActionResult> UsersOverview()
{
    var users = _context.Users
        .OrderBy(u => u.LastName)
        .AsNoTracking();

    return View(await users.ToListAsync());
}