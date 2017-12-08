using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo1.Models;

namespace RazorPagesDemo1.Pages
{
    public class CustomerModel : PageModel
    {
        DatabaseContext _Context;
        public CustomerModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            var customer = Customer;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            customer.CustomerID = 0;
            var result = _Context.Add(customer);
            _Context.SaveChanges();
            return RedirectToPage("AllCustomer");
        }
    }
}