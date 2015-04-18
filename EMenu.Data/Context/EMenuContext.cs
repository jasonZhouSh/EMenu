using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMenu.Data.Context
{
    public class EMenuContext: DbContext
    {
        public EMenuContext(String conn): base(conn) //"Mvc4DDD"
        {
            
        }
    }
}
