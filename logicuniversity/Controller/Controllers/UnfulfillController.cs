using logicuniversity.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;


namespace logicuniversity.Controllers
{
    public class UnfulfillController
    {
        UnfulfillFacade uf = new UnfulfillFacade();

        public bool AddUnfulfill(List<SelectedDODList> s)
        {
            bool flag = false;
            for (int i = 0; i < s.Count;i++)
            {
                unfulfill u = new unfulfill();
                u.item_code = s[i].Item_code;
                u.quantity = s[i].Qty;
                u.@ref = s[i].Po_id;
                u.unfufil_date = System.DateTime.Now.Date;
                if (!uf.GetUnfulfill(u.item_code, u.@ref))
                {
                    uf.AddUnfulfill(u);
                    flag = true;
                }   
            }
            return flag;
        }

        public void DeleteUnfulfill(List<unfulfill> u)
        {
            for(int i=0;i<u.Count;i++)
            {
                uf.DeleteUnfulfill(u[i]);
            }
        }
    }
}