using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService1.Entity4.Mappers
{
      public interface IMapper<Front, Back>
      {
          Back GetBack(Front front);
        //  Front GetFront(Back back);
      }
}
