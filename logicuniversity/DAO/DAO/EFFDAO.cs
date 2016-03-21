using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace logicuniversity.DAO
{
    public class EFFacade
    {
        StationeryDBEntities ctx = new StationeryDBEntities();
        public void updateRequisitionDetial(WCF_UpdateRequisitionDetail urd)
        {


            int id = Convert.ToInt32(urd.req_id);

            var record = ctx.requisitions.FirstOrDefault(o => o.req_id == id);

            record.req_status = urd.status;
            record.req_reason = urd.reason;
            ctx.SaveChanges();
        }
        public ViewIssuedRequisiton[] getPendingList()
        {
            List<ViewIssuedRequisiton> list = new List<ViewIssuedRequisiton>();

            var query = from o in ctx.requisitions
                        where o.req_status == "Pending"
                        join p in ctx.employees on o.req_emp_id equals p.emp_id
                        select new { o.req_status, o.req_date, o.req_id, p.emp_name };

            foreach (var qu in query)
            {
                ViewIssuedRequisiton emp = new ViewIssuedRequisiton();
                emp.Status = qu.req_status.Trim();
                emp.Date = qu.req_date.ToString();
                emp.Emp_name = qu.emp_name;
                emp.Req_id = qu.req_id.ToString();
                list.Add(emp);
            }
            return list.ToArray();
        }
        public List<EmployeeRequisition> getPeddingRequisitionList()
        {
            List<EmployeeRequisition> list = new List<EmployeeRequisition>();
            var emp = from o in ctx.requisitions
                      where o.req_status == "Pending"
                      from p in ctx.employees
                      where o.req_emp_id == p.emp_id
                      select new { o.req_id, o.req_date, p.emp_name };

            foreach (var emp1 in emp)
            {
                EmployeeRequisition emp2 = new EmployeeRequisition();
                emp2.Req_id = emp1.req_id;
                emp2.Emp_name = emp1.emp_name;
                emp2.Req_date = (DateTime)emp1.req_date;
                list.Add(emp2);
            }
          
            return list;

        }
        public RequisitionItem[] getRequisitionItemByID(int id)
        {
            List<RequisitionItem> list = new List<RequisitionItem>();
            var item = from o in ctx.requisitionDetails
                       where o.req_id == id
                       join p in ctx.catalogues on o.item_code equals p.item_code
                       join q in ctx.categories on p.catg_id equals q.catg_id
                       select new { q.name, p.description, o.req_quantity, o.item_code };
            foreach (var i in item)
            {
                RequisitionItem req = new RequisitionItem();
                req.Item_code = i.item_code;
                req.Description = i.description;
                req.Catagory = i.name;
                req.Quantity = (int)i.req_quantity;
                list.Add(req);
            }
            return list.ToArray();
        }
        public void ApproveRequisition(int id,int emp_id,string reason)
        {
            var requisition = from o in ctx.requisitions
                              where o.req_id == id
                              select o;
            foreach (var r in requisition)
            {
                r.req_status = "Approved";
                r.approve_emp_id = emp_id;
                r.approve_date = DateTime.Now;
                if(reason!="")
                {
                    r.req_reason = reason;
                }
            }

            ctx.SaveChanges();

        }
        public void RejectRequisition(int id)
        {
            var requisition = from o in ctx.requisitions
                              where o.req_id == id
                              select o;
            foreach (var r in requisition)
            {
                r.req_status = "Rejected";
            }

            ctx.SaveChanges();
        }
        public List<Catalogue_CategoryName> getCatalogueList()
        {
            List<Catalogue_CategoryName> list = new List<Catalogue_CategoryName>();
            var ctl = from o in ctx.catalogues
                      from i in ctx.categories
                      where o.catg_id == i.catg_id
                      select new { o.item_code, i.name, o.description };

            foreach (var cat in ctl)
            {
                Catalogue_CategoryName c = new Catalogue_CategoryName();
                c.Item_code = cat.item_code;
                c.Name = cat.name;
                c.Description = cat.description;
                list.Add(c);
            }

            return list;
        }
        public List<CategoryDetail> getCategoriesListByType(string name)
        {
            List<CategoryDetail> list = new List<CategoryDetail>();
            var cat = from o in ctx.categories
                      where o.name == name
                      join p in ctx.catalogues on o.catg_id equals p.catg_id
                      select new { o.name, p.catg_id, p.description, p.item_code };
            foreach (var c in cat)
            {
                CategoryDetail cd = new CategoryDetail();
                cd.Item_code = c.item_code;
                cd.Catg_id = c.catg_id;
                cd.Description = c.description;
                cd.Name = c.name;
                list.Add(cd);
            }
            return list;
        }
        public List<CategoryType> getCategories()
        {
            List<CategoryType> list = new List<CategoryType>();
            var cate = from o in ctx.categories
                       select o;
            foreach (var c in cate)
            {
                CategoryType ca = new CategoryType();
                ca.Catg_id = c.catg_id;
                ca.Name = c.name;
                list.Add(ca);
            }

            return list;
        }
        public List<StockCard> getStockCard(string ic)
        {
            List<StockCard> list = new List<StockCard>();
            var query = from o in ctx.catalogues
                        where o.item_code == ic
                        join i in ctx.stockcards on o.item_code equals i.item_code
                        select new { o.item_code, i.date, d2 = i.description, i.quantity };
            foreach (var sc in query)
            {
                StockCard s = new StockCard();
                s.Item_code = sc.item_code;
                s.Date = (DateTime)sc.date;
                s.S_description = sc.d2;
                s.Quantity = sc.quantity;
                list.Add(s);
            }
            return list;
        }
        public StockCardDetail[] getStockCardDetail(String ic)
        {
            List<StockCardDetail> list = new List<StockCardDetail>();
            var query = from o in ctx.catalogues
                        from i in ctx.stockLevels
                        where ic == o.item_code && o.item_code == i.item_code
                        select new { o.item_code, o.description, o.unit, i.balance };
            foreach (var scd in query)
            {
                StockCardDetail s = new StockCardDetail();
                s.Item_code = scd.item_code;
                s.C_description = scd.description;
                s.Unit = scd.unit;
                s.Balance = (int)scd.balance;
                list.Add(s);
            }
            return list.ToArray();

        }
        public void updateStockCard(String ic, DateTime dt, String des, String qty)
        {

            stockcard addStockCard = new stockcard();
            addStockCard.item_code = ic;
            addStockCard.date = dt;
            addStockCard.description = des;
            addStockCard.quantity = qty;

            ctx.stockcards.Add(addStockCard);
            ctx.SaveChanges();


        }
        public void updateStocklevel(String ic, String qty)
        {
            var query = from o in ctx.stockLevels
                        where o.item_code == ic
                        select o;

            String str = qty;
            int i = 0;
            if (str.Length>3 && str.Substring(0, 3) == "ADJ")
            {
                i = Convert.ToInt32(str.Substring(3));
            }
            else { i = Convert.ToInt32(str); }

            foreach (var v in query)
            {
                v.balance = v.balance + i;
                Console.Write(v.balance);
            }

            ctx.SaveChanges();
        }
        public List<Stationery> getStationeryList(DateTime fromdate, DateTime todate)
        {
            List<Stationery> list = new List<Stationery>();
            var query = (from o in ctx.requisitions
                         where o.approve_date >= fromdate && o.approve_date <= todate && o.req_status == "Approved"
                         from s in ctx.departments
                         where o.dept_id == s.dept_id
                         select new
                         {
                             s.dept_name,
                             qd = from q in ctx.requisitionDetails
                                  where q.req_id == o.req_id
                                  from p in ctx.catalogues
                                  where q.item_code == p.item_code
                                  select new { p.description, q.req_quantity }
                         }).ToList();

            foreach (var stationery in query)
            {
                foreach (var qt in stationery.qd)
                {
                    Stationery s = new Stationery();
                    s.Dept_name = stationery.dept_name;
                    s.Quantity = (int)qt.req_quantity;
                    s.Description = qt.description;
                    list.Add(s);
                }
            }
            return list;
        }
        public string generateDOID(string str)
        {
            int i = Convert.ToInt32(str.Substring(2)) + 1;
            return (i.ToString("'DO'0000"));
        }
        public void createDeliverOrder(int dept_id, List<Disbursement> list)
        {

            deliverOrder dO = new deliverOrder();
            string str = null;
            var query = ctx.deliverOrders.OrderByDescending(i => i.do_id).FirstOrDefault();
            if (query != null)
            {
                str = generateDOID(query.do_id);
            }
           
            if(str == null)
            {
                str = "DO0001";
            }
            dO.do_id = str;
            dO.dept_id = dept_id;
            ctx.deliverOrders.Add(dO);

            foreach (var v in list)
            {
                deliverOrderDetail dOD = new deliverOrderDetail();
                dOD.do_id = str;
                dOD.item_code = v.Item_code;
                dOD.quantity = v.Actual_amount;
                ctx.deliverOrderDetails.Add(dOD);
            }


            ctx.SaveChanges();
        }
        public List<Stationery> getStationeryByItemCode(string code)
     
        {

            List<Stationery> list = new List<Stationery>();

            var query = (from o in ctx.requisitions
                         where o.req_status == "Approved"
                         join i in ctx.requisitionDetails on o.req_id equals i.req_id
                         where i.item_code == code
                         from c in ctx.departments
                         where o.dept_id == c.dept_id
                   
                         
                         select new
                         {
                             c.dept_name,

                             c.dept_id,
                             
                             
                             qd = from q in ctx.requisitionDetails
                                  where q.req_id == o.req_id
                                  from p in ctx.catalogues
                                  where q.item_code == p.item_code && q.item_code == code
                                  
                                  select new { p.description, q.req_quantity }
                                 
                                 }).ToList();

                   
            foreach (var sta in query)
            {
                foreach (var qt in sta.qd)
                {
                    Stationery s = new Stationery();
                  s.Dept_id = sta.dept_id;
                    s.Description = qt.description;
                    s.Dept_name = sta.dept_name;
                    s.Quantity = (int)qt.req_quantity;
                    
                    list.Add(s);
                }
            }
         
           return list;
            
        }
        public string getItemDescription(string code)
        {
            Catalogue c = new Catalogue();
            var query = from o in ctx.catalogues
                        where o.item_code == code
                        select o;
            foreach (var q in query)
            {
                c.Description = q.description;
            }
            return c.Description;
        }
        public int getNeededAmount(string code)
        {
            int amount = 0;
            List<Stationery1> list = getStationeryByItemName();
            foreach (var l in list)
            {
                if (l.Item_code == code) { amount = l.Req_quantity; break; }
            }
            return amount;
        }
        public void updateRequisitionByDepartment(string item_code, int dept_id, int qty,int needquantity)
        {
            var deprequisition = ctx.requisitionByDepts.FirstOrDefault(x=>x.dept_id==dept_id && x.status=="Pending");
            unfulfill ui = new unfulfill();
            if (deprequisition == null)
            {
                requisitionByDept reqd = new requisitionByDept();
                reqd.dept_id = dept_id;
                reqd.status = "Pending";
                ctx.requisitionByDepts.Add(reqd);
                ctx.SaveChanges();
            }
            var deprequisition1 = ctx.requisitionByDepts.FirstOrDefault(x=>x.dept_id==dept_id && x.status=="Pending");
            var item = ctx.requisitionByDeptDetails.FirstOrDefault(x => x.item_code == item_code && x.req_dept_id==deprequisition1.req_dept_id);
           
            if(item!=null)
            {
                item.req_quantity = qty;
                ctx.SaveChanges();
            }else
            {
                
                requisitionByDeptDetail reqdd = new requisitionByDeptDetail();
                reqdd.req_dept_id = deprequisition1.req_dept_id;
                reqdd.item_code = item_code;
                reqdd.req_quantity = qty;
                ctx.requisitionByDeptDetails.Add(reqdd);
                ctx.SaveChanges();
            }   
   
            if(qty<needquantity)
            {
                var reqs = from o in ctx.requisitions
                           where o.req_status == "Approved" && o.dept_id == dept_id
                           join p in ctx.requisitionDetails on o.req_id equals p.req_id
                           where p.item_code == item_code
                           orderby o.req_date ascending
                           select new { o.req_id, o.dept_id, p.req_quantity };



                foreach (var r in reqs.ToList())
                {
                    if (qty - r.req_quantity > 0)
                    {
                        qty = qty - (int)r.req_quantity;

                    }
                    else if (qty > 0)
                    {
                        ui.item_code = item_code;
                        ui.dept_id = r.dept_id;
                        ui.quantity = r.req_quantity - qty;
                        ui.unfufil_date = DateTime.Now;
                        ui.remark = "lack of storage";
                        string x = Convert.ToString(r.req_id);
                        ui.@ref = x;
                        ui.status = "unfulfilled";
                        ctx.unfulfills.Add(ui);
                        ctx.SaveChanges();
                        qty = 0;
                    }
                    else
                    {
                        ui.item_code = item_code;
                        ui.dept_id = r.dept_id;
                        ui.quantity = r.req_quantity;
                        ui.unfufil_date = DateTime.Now;
                        ui.remark = "lack of storage";
                        string x = Convert.ToString(r.req_id);
                        ui.@ref = x;
                        ui.status = "unfulfilled";
                        ctx.unfulfills.Add(ui);
                        ctx.SaveChanges();
                        qty = 0;
                    }
                }
               
            }
           
        }
        public Dictionary<int, int> dispatchItem(int actualAmount, string item_code)
        {
            Dictionary<int, int> di = new Dictionary<int, int>();
            di.Add(5, 0);
            di.Add(6, 0);
            di.Add(7, 0);
            di.Add(8, 0);
            
            var req = from o in ctx.requisitions
                      where o.req_status == "Approved"
                      join p in ctx.requisitionDetails on o.req_id equals p.req_id
                      where p.item_code == item_code
                      orderby o.req_date ascending
                      select new { o.req_id, o.dept_id, p.req_quantity };
            foreach (var r in req.ToList())
            {
                int quantity = (int)r.req_quantity;
                if (actualAmount - quantity > 0)
                {
                    actualAmount = actualAmount - quantity;
                }
                else if (actualAmount > 0)
                {    
                    di[(int)r.dept_id] = di[(int)r.dept_id] + (int)r.req_quantity - (int)actualAmount;
                    actualAmount = 0;
                }
                else
                {                  
                    actualAmount = 0;
                    di[(int)r.dept_id] = di[(int)r.dept_id] + (int)r.req_quantity;
                }
            }
            return di;
        }
        public List<Stationery1> getStationeryByItemName()
        {

            List<Stationery1> list = new List<Stationery1>();


            var query = (from p in ctx.requisitions
                         where p.req_status == "Approved"
                         from o in ctx.requisitionDetails.AsEnumerable()
                         where p.req_id == o.req_id
                         group o by o.item_code
                             into g
                             join i in ctx.catalogues on g.FirstOrDefault().item_code equals i.item_code
                            
                             select new
                             {
                                 desc = i.description,
                                 id = g.FirstOrDefault().item_code,
                                 amount = g.Where(y => y.item_code == g.FirstOrDefault().item_code).Sum(y => y.req_quantity)
                             }).Distinct();
            foreach (var i in query)
            {
                Stationery1 s = new Stationery1();
                s.Description = i.desc;
                s.Item_code = i.id;
                s.Req_quantity = (int)i.amount;
                list.Add(s);
            }
            return list;
        }
        public List<RejectItems> viewRejectItems()
        {
            List<RejectItems> list = new List<RejectItems>();
            var query = from o in ctx.unfulfills
                        from i in ctx.catalogues
                        from s in ctx.categories
                        from t in ctx.departments
                        where o.item_code == i.item_code && i.catg_id == s.catg_id && t.dept_id == o.dept_id
                        select new
                        {
                            o.unfufil_date,
                            s.name,
                            i.description,
                            o.quantity,
                            o.remark,
                            t.dept_name
                        };
            foreach (var items in query)
            {
                RejectItems r = new RejectItems();
                r.Date = (DateTime)items.unfufil_date;
                r.Category = items.name;
                r.Desc = items.description;
                r.Quantity = items.quantity.ToString();
                r.Remark = items.remark;
                r.Dept_name = items.dept_name;
                list.Add(r);
            }
            return list;

        }
        public List<Discrepancy> getDiscrepancy()
        {
            List<Discrepancy> list = new List<Discrepancy>();
            var query = from o in ctx.inventoryAdjs
                        join p in ctx.employees on o.emp_supervisor_id equals p.emp_id
                        select new { o.date_issue, o.voucher_id, o.status, p.emp_name };
            foreach (var dis in query)
            {
                Discrepancy d = new Discrepancy();
                d.Date = (DateTime)dis.date_issue;
                d.Voucher_id = dis.voucher_id;
                d.Status = dis.status;
                d.Emp_name = dis.emp_name;
                list.Add(d);
            }

            return list;
        }
        public List<Department> getDepartmentList()
        { var depts= new int[]{5,6,7,8};
            List<Department> list = new List<Department>();
            var query = from o in ctx.departments where depts.Contains(o.dept_id)
                        select new { o.dept_id, o.dept_name };
            foreach (var dept in query)
            {
                Department d = new Department();
                d.Dept_id = dept.dept_id;
                d.Dept_name = dept.dept_name;
                list.Add(d);
            }
            return list;
        }
        public void createDiscrepancy(string item_code, int dept_id, int quantity, string remark)
        {
            var q = ctx.unfulfills.OrderByDescending(i => i.id)
                .First();

            unfulfill u = new unfulfill();
            u.id = 1 + q.id;
            u.item_code = item_code;
            u.dept_id = dept_id;
            u.quantity = quantity;
            u.remark = remark;
            u.status = "Rejected";
            u.unfufil_date = DateTime.Now;

            ctx.unfulfills.Add(u);
            ctx.SaveChanges();
        }
        public bool ifitemshavebeenadded(string item_code)
        {
            var item = from o in ctx.requisitionByDepts
                       where o.status == "Pending"
                       join p in ctx.requisitionByDeptDetails on o.req_dept_id equals p.req_dept_id
                       where p.item_code == item_code
                       select new { o.req_dept_id, p.item_code };
            
            if(item.ToList().Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Dictionary<int, int> getalreadydispachedItem(string item_code)
        {
            Dictionary<int, int> di = new Dictionary<int, int>();
            var item = from o in ctx.requisitionByDepts
                       where o.status == "Pending"
                       join p in ctx.requisitionByDeptDetails on o.req_dept_id equals p.req_dept_id
                       where p.item_code == item_code
                       select new { o.req_dept_id, o.dept_id, p.req_quantity };
            foreach (var i in item.ToList())
            {
                int quantity = (int)i.req_quantity;
                int dep_id = (int)i.dept_id;
                di.Add(dep_id, quantity);
            }
            return di;
        }
        public List<Disbursement> getDisbursementListByDept(int dept_id)
        {
           
            List<Disbursement> list = new List<Disbursement>();

            var query = from o in ctx.requisitionByDepts
                        where o.dept_id == dept_id
                        join p in ctx.requisitionByDeptDetails on o.req_dept_id equals p.req_dept_id
                        join q in ctx.catalogues on p.item_code equals q.item_code
                        select new { p.item_code, q.description, p.req_quantity };
            foreach (var qu in query)
            {
                Disbursement d = new Disbursement();
                d.Item_code = qu.item_code;
                d.Description = qu.description;
                d.Actual_amount = (int)qu.req_quantity;
                list.Add(d);
            }
            return list;

        }
        public void RejectRequisition(int id, string reason)
        {
            var requisition = from o in ctx.requisitions
                              where o.req_id == id
                              select o;
            foreach (var r in requisition)
            {
                r.req_status = "Rejected";
                r.req_reason = reason;
            }

            ctx.SaveChanges();
        }

        public ViewIssuedRequisiton[] getIssuedRequisitionList()
        {
            List<ViewIssuedRequisiton> list = new List<ViewIssuedRequisiton>();

            var query = from o in ctx.requisitions
                        where o.req_status == "Approved" || o.req_status == "Rejected"
                        join p in ctx.employees on o.req_emp_id equals p.emp_id
                        select new { o.req_status, o.req_date, o.req_id, p.emp_name, o.req_reason };

            foreach (var qu in query)
            {
                ViewIssuedRequisiton emp = new ViewIssuedRequisiton();
                emp.Status = qu.req_status;
                emp.Date = String.Format("{0:MM/dd/yyyy}", qu.req_date);
                emp.Emp_name = qu.emp_name;
                emp.Req_id = qu.req_id.ToString();
                emp.Reason = qu.req_reason;
                list.Add(emp);
            }
            return list.ToArray();
        }

        public ViewIssuedRequisitonDetail[] getViewIssuedRequisitonDetail(string id)
        {
            int i = Convert.ToInt32(id);
            List<ViewIssuedRequisitonDetail> list = new List<ViewIssuedRequisitonDetail>();
            var query = from o in ctx.requisitionDetails
                        where o.req_id == i
                        join r in ctx.requisitions on o.req_id equals r.req_id
                        join p in ctx.catalogues on o.item_code equals p.item_code
                        join q in ctx.categories on p.catg_id equals q.catg_id
                        select new { q.name, p.description, o.req_quantity, r.req_reason };
            foreach (var qu in query)
            {
                ViewIssuedRequisitonDetail vird = new ViewIssuedRequisitonDetail();
                vird.Category = qu.name;
                vird.Description = qu.description;
                vird.Quantity = qu.req_quantity.ToString();
                vird.Reason = qu.req_reason;
                list.Add(vird);
            }

            return list.ToArray();
        }
        /********************** Begin : Gokul *************************/
        public void createDiscrepancy(List<DiscrepancyDetail> list)
        {
            //int total = 0;

            var q = ctx.inventoryAdjs.OrderByDescending(i => i.voucher_id)
                .First();
            string voucher_id = generateADJID(q.voucher_id);

            inventoryAdj ia = new inventoryAdj();
            ia.voucher_id = voucher_id;
            ia.emp_supervisor_id = 1002;
            ia.date_issue = DateTime.Now;
            ia.status = "Pending";


            foreach (DiscrepancyDetail qu in list)
            {
                inventoryAdjDetail iad = new inventoryAdjDetail();
                iad.voucher_id = voucher_id;
                iad.item_code = qu.Item_code;
                iad.quantity = Int32.Parse(qu.Quantity.ToString());
                iad.reason = qu.Reason;
                ctx.inventoryAdjDetails.Add(iad);
                ia.total = (decimal)getItemPrice(qu.Item_code) * iad.quantity;

            }
            ctx.inventoryAdjs.Add(ia);
            ctx.SaveChanges();

        }

        private decimal? getItemPrice(string item_code)
        {
            var price = from o in ctx.catalogues
                        where o.item_code == item_code
                        select o.item_price;
            decimal p = (decimal)price.FirstOrDefault();
            return p;
        }
        /********************** End : Gokul *************************/
        public string generateADJID(string str)
        {
            int i = Convert.ToInt32(str.Substring(3)) + 1;
            return (i.ToString("'Adj'0000"));
        }
        public List<DiscrepancyDetail> getDiscrepancyDetail(string id)
        {
            List<DiscrepancyDetail> list = new List<DiscrepancyDetail>();
            var query = from o in ctx.inventoryAdjDetails
                        where o.voucher_id == id
                        join p in ctx.catalogues on o.item_code equals p.item_code
                        select new { o.quantity, o.reason, p.description };
            foreach (var qu in query)
            {
                DiscrepancyDetail d = new DiscrepancyDetail();
                d.Description = qu.description;
                d.Quantity = (int)qu.quantity;
                d.Reason = qu.reason;
                list.Add(d);
            }
            return list;
        }

        public string getEmpName(int emp_id)
        {
            var empInfo = from o in ctx.employees
                          where o.emp_id == emp_id
                          select o.emp_name;
            return empInfo.FirstOrDefault();
        }
        public int? getEmpDept(int emp_id)
        {
            var empInfo = from o in ctx.employees
                          where o.emp_id == emp_id
                          select o.dept_id;
            int x = (int)empInfo.FirstOrDefault();
            return x;
        }
        

        public RequisitionItem[] getCurrentRequisition()
        {
            List<RequisitionItem> list = new List<RequisitionItem>();
            var item = from o in ctx.requisitionDetails
                       join p in ctx.catalogues on o.item_code equals p.item_code
                       join q in ctx.categories on p.catg_id equals q.catg_id

                       select new { q.name, p.description, o.req_quantity, o.item_code };

            foreach (var i in item)
            {
                RequisitionItem req = new RequisitionItem();
                req.Item_code = i.item_code;
                req.Description = i.description;
                req.Catagory = i.name;
                req.Quantity = (int)i.req_quantity;
                list.Add(req);
            }

            return list.ToArray();
        }
        public List<CategoryDetail> getCategoriesList()
        {
            List<CategoryDetail> list = new List<CategoryDetail>();
            var cat = from o in ctx.catalogues
                      join p in ctx.categories on o.catg_id equals p.catg_id
                      select new { o.catg_id, o.description, o.item_code, p.name };
            foreach (var c in cat)
            {
                CategoryDetail cd = new CategoryDetail();
                cd.Item_code = c.item_code;
                cd.Catg_id = c.catg_id;
                cd.Description = c.description;
                cd.Name = c.name;
                list.Add(cd);
            }
            return list;
        }
        public int updateRequisitionStatus(EmployeeRequisitionDetail reqdetail)
        {
            var req = from o in ctx.requisitions
                      where o.req_id == reqdetail.Req_id
                      select o;
            if (req != null)
            {
                foreach (var r in req)
                {
                    if (reqdetail.Received_clerk_id.ToString() != null)
                    {
                        r.received_emp_id = reqdetail.Received_clerk_id;
                        r.req_status = reqdetail.Status;
                    }
                    else
                    {
                        r.approve_emp_id = reqdetail.Approve_emp_id;
                        r.req_status = reqdetail.Status;
                    }
                }
                ctx.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void UpdateReqDetail(List<CategoryDetail> ca, int req_id)
        {
            if (ca.Count() != 0)
            {
                List<requisitionDetail> list = new List<requisitionDetail>();
                var q = from o in ctx.requisitionDetails
                        where o.req_id == req_id
                        select o;
                foreach (var p in q)
                {
                    requisitionDetail req = new requisitionDetail();
                    req.req_id = p.req_id;
                    req.item_code = p.item_code;
                    req.req_quantity = p.req_quantity;
                    list.Add(req);
                }
               
                try
                {
                    if (list.Count > 0)
                    {
                        foreach (requisitionDetail r in list)
                        {
                            var item = ctx.requisitionDetails.FirstOrDefault(x => x.req_id == r.req_id);
                            ctx.requisitionDetails.Remove(item);
                            ctx.SaveChanges();
                        }
                    }
                    List<requisitionDetail> lred = new List<requisitionDetail>();
                    foreach (CategoryDetail c in ca)
                    {
                        requisitionDetail req = new requisitionDetail();
                        req.req_id = req_id;
                        req.item_code = c.Item_code;
                        req.req_quantity = c.Quantity;
                        ctx.requisitionDetails.Add(req);
                        lred.Insert(0, req);
                    }
                    ctx.requisitionDetails.AddRange(lred);
                    ctx.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }
        public int CreateNewRequisition(EmployeeRequisitionDetail emp)
        {
            if (emp == null)
            {
                return 0;           
            }
            else
            {
                requisition req = new requisition();
                req.req_id = emp.Req_id;
                req.dept_id = emp.Dept_id;
                req.req_emp_id = emp.Requst_emp_id;
                req.req_status = emp.Status;
                ctx.requisitions.Add(req);
                ctx.SaveChanges();
                return 1;
            }
        }
        public requisition getDraftrequisition(int id)
        {
            var draft = ctx.requisitions.FirstOrDefault(x => x.req_emp_id == id && x.req_status == "Draft");
            return draft;
        }
        public void addSingleUnfulfilleditem(UnfulfilledItems ui)
        {
            var item = ctx.unfulfills.FirstOrDefault(x => x.id == ui.Id);
            item.status = "fufilled";
            ctx.SaveChanges();
        }
        public employee findEmployeeById(int req_id)
        {
            var req = ctx.requisitions.FirstOrDefault(x => x.req_id == req_id);
            var member = ctx.employees.FirstOrDefault(y => y.emp_id == req.req_emp_id);
            return member;
        }
        public void addAllUnfulfilledItem(List<requisitionDetail> li, int req_id)
        {
            foreach (requisitionDetail reqdetail in li)
            {
                reqdetail.req_id = req_id;
                ctx.requisitionDetails.Add(reqdetail);
                ctx.SaveChanges();
            }
        }
        public List<SelfRequisition> getSelfRequisitions(string id1)
        {
            int id = Convert.ToInt32(id1);
            List<SelfRequisition> list = new List<SelfRequisition>();
            var reqs = from o in ctx.requisitions
                       where o.req_emp_id == id
                       orderby o.req_date descending 
                       select o;
            foreach (var r in reqs)
            {
                SelfRequisition sr = new SelfRequisition();
                sr.Emp_id = (int)r.req_emp_id;
                sr.Req_id = r.req_id;
                sr.Dept_id = (int)r.dept_id;
                sr.Status = r.req_status;
                if (r.req_date != null)
                {
                    sr.Req_date = (DateTime)r.req_date;
                }
                list.Add(sr);
            }
            return list;
        }
        public List<CategoryDetail> addItemsToList(CategoryDetail ca, List<CategoryDetail> list)
        {
            CategoryDetail c = null;
            foreach (CategoryDetail c1 in list)
            {
                if (c1.Item_code == ca.Item_code)
                {
                    c = c1;
                }
            }
            if (c != null)
            {
                list.Remove(c);
                c.Quantity = c.Quantity + ca.Quantity;
                list.Insert(0, c);
            }
            else
            {
                list.Insert(0, ca);
            }
            return list;
        }
        public List<CategoryDetail> addListTolist(List<CategoryDetail> part, List<CategoryDetail> full)
        {
            foreach (CategoryDetail c in part)
            {
                addItemsToList(c, full);
            }
            return full;
        }

        public int insertDetailitem(requisitionDetail reqd)
        {
            ctx.requisitionDetails.Add(reqd);
            ctx.SaveChanges();
            return 1;
        }


        public int makenewrequisition(requisition req)
        {
            requisition req1 = ctx.requisitions.Add(req);
            ctx.SaveChanges();
            return req1.req_id;
        }


        public EmployeeRequisitionDetail getsepcificrequisiton(string req_id)
        {
            int id = Convert.ToInt32(req_id);
            requisition req = ctx.requisitions.FirstOrDefault(x => x.req_id == id);
            EmployeeRequisitionDetail empreq = new EmployeeRequisitionDetail();

            empreq.Req_id = req.req_id;
            empreq.Requesttime_text = ((DateTime)req.req_date).ToString("MM/dd/yyyy");
            if (req.approve_date != null)
            {
                employee emp = ctx.employees.FirstOrDefault(x => x.emp_id == req.approve_emp_id);
                empreq.Approve_emp_name = emp.emp_name;
                empreq.Approvetime_text = ((DateTime)req.approve_date).ToString("MM/dd/yyyy");
            }
            if (req.received_date != null)
            {
                employee emp = ctx.employees.FirstOrDefault(x => x.emp_id == req.received_emp_id);
                empreq.Received_emp_name = emp.emp_name;
                empreq.Receivetime_text = ((DateTime)req.received_date).ToString("MM/dd/yyyy");
            }
            var items = from o in ctx.unfulfills
                        where o.@ref == req_id
                        select o;
            if (items != null)
            {
                int q = 0;
                foreach (var i in items)
                {
                    q = q + 1;
                }
                empreq.Unfulfillquantity = q;
            }
            empreq.Status = req.req_status;
            return empreq;
        }

        public List<UnfulfilledItems> getUnfulfillitems(int req_id)
        {
            List<UnfulfilledItems> list1 = new List<UnfulfilledItems>();
            var unfulfill = from a in ctx.unfulfills
                            where a.@ref == req_id.ToString() && a.status == "unfulfilled"
                            join c in ctx.catalogues on a.item_code equals c.item_code
                            join d in ctx.categories on c.catg_id equals d.catg_id
                            select new { a.id, a.item_code, a.quantity, a.remark, c.description, d.name, a.@ref };

            foreach (var f in unfulfill)
            {
                UnfulfilledItems ui = new UnfulfilledItems();
                ui.Req_id = Convert.ToInt32(f.@ref);
                ui.Id = f.id;
                ui.Item_code = f.item_code;
                ui.Quantity = (int)f.quantity;
                ui.Reason = f.remark;
                ui.Description = f.description;
                ui.Name = f.name;
                list1.Add(ui);
            }
            return list1;
        }

       
        public string getDeptNameDisplay(int id)
        {
            int DeptId = id;
            var deptName = from a in ctx.departments
                           where a.dept_id == DeptId
                           select a;

            string s = deptName.ToList()[0].dept_name.ToString();
            return s;
        }

        public string getCollpointDisplay(int id)
        {
            int DeptId = id;
            var ColInfo = from o in ctx.collectionPoints
                          join i in ctx.departments on o.col_id equals i.col_id
                          where i.dept_id == DeptId
                          select o;

            string s = ColInfo.ToList()[0].col_location.ToString();

            return s;
        }

        public string getDeliveryByDisplay(int id)
        {
            int DeptId = id;
            var ColInfo = from o in ctx.collectionPoints
                          join i in ctx.departments on o.col_id equals i.col_id
                          where i.dept_id == DeptId
                          select o;

            int DeliverClerkId = Convert.ToInt16(ColInfo.ToList()[0].clerk_emp_id.ToString());

            var deliverInfo = from x in ctx.collectionPoints
                              join y in ctx.employees on x.clerk_emp_id equals y.emp_id
                              where x.clerk_emp_id == DeliverClerkId
                              select y;
            string s = deliverInfo.ToList()[0].emp_name.ToString();
            return s;
        }

        public List<ReceiveStationeriesListTable> getReceiveStationeriesList(int DepId)
        {
            int id = DepId;
          /*  var query = from tt in ctx.requisitions
                        where tt.dept_id == id
                        join xx in ctx.employees on tt.req_emp_id equals xx.emp_id into temp

                        from m in temp.DefaultIfEmpty()
                             join ff in ctx.requisitionByDepts on m.dept_id equals ff.dept_id into temp2
                             from p in temp2.DefaultIfEmpty()
                         where p.status == "Pending"
                        select new { m.emp_name, tt.req_date, tt.req_id };*/

            var query = from tt in ctx.requisitions
                        where tt.dept_id == id && tt.received_date == null && tt.req_status == "Approved"
                        join xx in ctx.employees on tt.req_emp_id equals xx.emp_id 
                        select new { xx.emp_name, tt.req_date, tt.req_id };

            List<ReceiveStationeriesListTable> list = new List<ReceiveStationeriesListTable>();
            foreach (var item in query)
            {
                ReceiveStationeriesListTable r = new ReceiveStationeriesListTable();
                r.Req_Dept_Id = item.req_id.ToString();
                r.Emp_name = item.emp_name;
                r.Date = (DateTime)item.req_date;
                list.Add(r);
            }
            return list;
        }
        public List<GVTable> getReceiveStationeriesDetail(int id)
        {
            int ReqDeptID = id;
            var gvTable = from u in ctx.requisitionByDeptDetails
                          where u.req_dept_id == ReqDeptID
                          join q in ctx.catalogues on u.item_code equals q.item_code
                          join w in ctx.categories on q.catg_id equals w.catg_id
                          select new { u.req_quantity, w.name, q.description, u.item_code };

            List<GVTable> listGTtable = new List<GVTable>();

            foreach (var element in gvTable)
            {
                GVTable gvModel = new GVTable();
                gvModel.Item_code = element.item_code;
                gvModel.Category = element.name;
                gvModel.Description = element.description;
                gvModel.Quantity = Convert.ToInt16(element.req_quantity);
                listGTtable.Add(gvModel);
            }

            return listGTtable;
        }

       

    }
}