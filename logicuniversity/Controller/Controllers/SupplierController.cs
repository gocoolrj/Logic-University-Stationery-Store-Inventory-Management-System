using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logicuniversity.Controllers
{
    public class SupplierController
    {
        SupplierFacade sf = new SupplierFacade();

        public List<Entity.supplier> GetSuppliers()
        {
            return sf.GetSuppliers();
        }
    }
}