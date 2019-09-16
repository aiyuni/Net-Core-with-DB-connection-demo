using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeterRapier.Models;

namespace PeterRapier.Pages
{
    public class LucaModel : PageModel
    {
        public string Text { get; set; }
        public string databaseText { get; set; }
        
        public string EmployeeList { get; set; }

        private readonly PeterRapier.Models.ApplicationDbContext _context;

        public void OnGet()
        {
            Text = "hello peter";

            string connString = "Server=DESKTOP-KBC6VID;Initial Catalog=Test;Integrated Security=True";
            //string connString = "Server=LAPTOP-J62LRQIM;Initial Catalog=RenRapier;Integrated Security=True";

            //EmployeeList = _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID);

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = "select * from rengod";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
               

                while (dataReader.Read())
                {
                    databaseText = databaseText + dataReader.GetValue(0) + ", " + dataReader.GetValue(1) + "/n";
                }

                Text = databaseText;
            }
            catch (Exception ex)
            {
                Text = ex.ToString();
            }

            // Data Source = LAPTOP - J62LRQIM; Initial Catalog = RenRapier; Integrated Security = True
            /*using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = “select sdfasdf”
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

            } */
        }
    }
}