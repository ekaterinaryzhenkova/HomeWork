using System.Collections.Generic;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<PhoneNumberDTO> Numbers { get; set; } //string
    }
}
