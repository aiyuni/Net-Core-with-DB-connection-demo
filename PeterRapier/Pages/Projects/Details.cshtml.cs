﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeterRapier.Models;

namespace PeterRapier.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly PeterRapier.Models.ApplicationDbContext _context;

        public DetailsModel(PeterRapier.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectID == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
