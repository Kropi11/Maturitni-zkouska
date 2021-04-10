public async Task<IActionResult> UserEdit(string? id)
{
    if (id == null)
    {
        return NotFound();
    }
    var user = await _context.Users.FindAsync(id);
    if (user == null)
    {
        return NotFound();
    }
    PopulateClassesWithIdDropDownList(user.ClassId);
    return View(user);
}