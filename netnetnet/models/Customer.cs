using Microsoft.Extensions.Hosting;

namespace netnetnet.models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
        public IList<Doctor> Doctors { get; } = new List<Doctor>();

    }
}
