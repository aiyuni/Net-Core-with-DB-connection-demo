using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeterRapier.Models;

namespace PeterRapier.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly PeterRapier.Models.ApplicationDbContext _context;

        public IndexModel(PeterRapier.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
