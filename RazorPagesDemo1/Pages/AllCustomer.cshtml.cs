using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo1.Models;

namespace RazorPagesDemo1.Pages
{
    public class AllCustomerModel : PageModel
    {
        DatabaseContext _Context;
        public AllCustomerModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }

        public List<Customer> CustomerList { get; set; }

        public void OnGet()
        {
            var data = (from customerlist in _Context.CustomerTB
                        select customerlist).ToList();

            CustomerList = data;
        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _Context.CustomerTB
                            where customer.CustomerID == id
                            select customer).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("AllCustomer");
        }
    }
}