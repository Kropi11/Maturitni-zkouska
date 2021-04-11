[HttpPost, ActionName("UserDelete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> UserDelete_Post(string? id)
{
    var user = await _context.Users.FindAsync(id);
    if (user == null)
    {
        return RedirectToAction(nameof(UsersOverview));
    }
    try
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(UsersOverview));
    }
    catch (DbUpdateException ex)
    {
        return RedirectToAction(nameof(UserDelete), new { id = id,
        saveChangesError = true });
    }
}