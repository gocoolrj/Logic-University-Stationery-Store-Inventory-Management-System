using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Entity;

namespace logicuniversity.WebService
{
    public class RepresentativeNameDisplayInfoBroker
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public RepresentativeNameDisplayInfo getDisolay()
        {

            RepresentativeNameDisplayInfo r = new RepresentativeNameDisplayInfo();
            r.DeptName = "English";
            r.CollPoint = "Science School";
            r.RepName = "Jack";
            r.DeliBy = "Tim";
            return r;
        }
    }
}