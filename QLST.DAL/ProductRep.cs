using QLST.Common.DAL;
using QLST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QLST.DAL
{
    public class ProductRep:GenericRep<dbblContext,Hanghoa>
    {
        public ProductRep()
        {

        }
        public override Hanghoa Read(int id)
        {
            var res = All.FirstOrDefault(p => p.IdHh == id);
            return res;
        }
    }
}
