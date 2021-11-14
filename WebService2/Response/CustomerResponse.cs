using System.Collections.Generic;

namespace WebService2.Response
{
    public class CustomerResponse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Numbers { get; set; }
    }
}
