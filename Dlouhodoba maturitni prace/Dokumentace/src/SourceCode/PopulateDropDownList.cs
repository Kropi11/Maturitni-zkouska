private void PopulateClassesWithIdDropDownList(object selectedClass = null)
{
    var classesQuery = from c in _context.Classes
        orderby c.ClassName
        select c;
    ViewBag.ClassId =
        new SelectList(classesQuery.AsNoTracking(), "Id",
        "ClassName", selectedClass);
}