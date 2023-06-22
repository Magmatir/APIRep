using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netnetnet.models;
using System.Text.Json;

namespace netnetnet.Controllers
{
        [ApiController]
        [Route("/netnetnet/models/Customer.cs")]

    public class CustomerController : ControllerBase 
    {
       [HttpGet]


        public ActionResult Get()
        {
            MainDbContext db = new MainDbContext();
            List<Customer> customers = db.Customers.ToList();
            string jsonCustomers = JsonSerializer.Serialize(customers);
            return Ok(jsonCustomers);
        }
        [HttpPost]
        public ActionResult Add(Customer customer) 
        {
            MainDbContext db = new MainDbContext();
            db.Customers.Add(customer);
            db.SaveChanges();
            Customer addedUser = db.Customers.FirstOrDefault(u => u.Name == customer.Name);
            string jsonUser = JsonSerializer.Serialize(customer);
            return Ok(jsonUser);
        }


        [HttpDelete]
        public ActionResult Delete(Customer customer)
        {
            //MainDbContext db = new MainDbContext();
            
            
            using var context = new MainDbContext();
            var deletedUser = context.Customers.OrderBy(e => e.ID).Include(e => e.Doctors).First();

            context.Remove(deletedUser);

            context.SaveChanges();
            return Ok(deletedUser);
        }
    }


}
