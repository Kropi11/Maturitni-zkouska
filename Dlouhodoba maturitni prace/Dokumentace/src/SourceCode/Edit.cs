[HttpPost, ActionName("UserEdit")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> UserEdit_Post(string? id)
{
    if (id == null)
    {
        return NotFound();
    }
    var userToUpdate = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
    if (await TryUpdateModelAsync<PPSPSUser>(
        userToUpdate,
        "",
        s => s.FirstName, s => s.LastName, s => s.Email,
        s => s.EmailConfirmed, c => c.ClassId))
    {
        try
        {
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UsersOverview));
        }
        catch (DbUpdateException /* ex */)
        {
            ModelState.AddModelError("", "Nebylo možné uložit změny. " +
                                         "Zkuste to znovu později a pokud " +
                                         "problém přetrvává, " +
                                         "obraťte se na správce systému.");
        }
    }
    PopulateClassesWithIdDropDownList(userToUpdate.ClassId);
    return View(userToUpdate);
}