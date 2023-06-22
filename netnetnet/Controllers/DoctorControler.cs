using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netnetnet.models;
using System.Text.Json;

namespace netnetnet.Controllers
{
    [ApiController]
    [Route("/netnetnet/models/Doctor.cs")]

    public class DoctorControler : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MainDbContext db = new MainDbContext();
            List<Doctor> doctors = db.Doctors.ToList();
            string jsonDoctors = JsonSerializer.Serialize(doctors);
            return Ok(jsonDoctors);
        }
        [HttpPost]
        public ActionResult Add(Doctor doctor)
        {
            MainDbContext db = new MainDbContext();
            db.Doctors.Add(doctor);
            db.SaveChanges();
            Doctor addedUser = db.Doctors.FirstOrDefault(u => u.Name == doctor.Name);
            string jsonUser = JsonSerializer.Serialize(doctor);
            return Ok(jsonUser);
        }


        [HttpDelete]
        public ActionResult Delete(Doctor doctor)
        {

            using var context = new MainDbContext();
            var deletedUser = context.Doctors.OrderBy(e => e.ID).First();

            context.Remove(deletedUser);

            context.SaveChanges();
            return Ok(deletedUser);
        }
    }


}

