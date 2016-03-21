using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
namespace logicuniversity.DAO
{
    public class UnfulfillFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();

        public void AddUnfulfill(unfulfill u)
        {
            ctx.unfulfills.Add(u);
            ctx.SaveChanges();
        }

        public void DeleteUnfulfill(unfulfill u)
        {
            var qry = (from uf in ctx.unfulfills where uf.item_code == u.item_code && uf.@ref == u.@ref select uf).SingleOrDefault();

            ctx.unfulfills.Remove(qry);
            ctx.SaveChanges();
        }

        public bool GetUnfulfill(string itemcode,string poid)
        {
            var qry = (from uf in ctx.unfulfills where uf.item_code == itemcode && uf.@ref == poid select uf).SingleOrDefault();
            if (qry != null)
                return true;
            else
                return false;
        }
    }
}