namespace AzureAd.Pages.BankAccounts
{
    public class CustomerNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void PopulateDepartmentsDropDownList(ApplicationDbContext _context,
            object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Customers
                                   orderby d.Name // Sort by name.
                                   select d;

            DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(),
                        "DepartmentID", "Name", selectedDepartment);
        }
    }
}