using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using logicuniversity.Models;
using Entity;

namespace logicuniversity.JSONClassTransfer
{
    public class JSONTransfer
    {

       
        public PurchaseOrder[] TransferFrompurchaseOrder(purchaseOrder[] ca)
        {
            List<PurchaseOrder> po = new List<PurchaseOrder>();
            foreach (purchaseOrder p in ca)
            {
                po.Add(PurchaseOrder.Make(p.po_id, p.sup_code, p.po_date.ToString(), p.po_duedate.ToString(), p.po_approvedate.ToString(), p.net_amount, p.status, p.remark));
               
            }
            return po.ToArray();

        }
        public PurchaseOrder TransferFromPO(purchaseOrder po)
        {
            PurchaseOrder p = new PurchaseOrder();

            p = PurchaseOrder.Make(po.po_id, po.sup_code, po.po_date.ToString(), po.po_duedate.ToString(), po.po_approvedate.ToString(), po.net_amount, po.status, p.Remark);

            return p;
        }
        public PurchaseOrderDetails[] TransferFromPOD(PurchaseOrderDetails[] pod)
        {
            List<PurchaseOrderDetails> podl = new List<PurchaseOrderDetails>();
            foreach (PurchaseOrderDetails pd in pod)
            {
                
                podl.Add(PurchaseOrderDetails.Make(pd.Po_id, pd.Item_code, pd.Desc, pd.Quantity, pd.Price, pd.Amount));
            }
            return podl.ToArray();
        }
        public InventoryAdj TransferFromInvAdj(inventoryAdj ia)
        {
            InventoryAdj iaobj=new InventoryAdj();
            iaobj=InventoryAdj.Make(ia.voucher_id,ia.date_issue.ToString(),ia.emp_supervisor_id.ToString(),ia.emp_auth_id.ToString(),ia.status);
            return iaobj;
        }
        public InventoryAdj[] TransferFromInvAdj(inventoryAdj[] ia)
        {
            List<InventoryAdj> invadjlist = new List<InventoryAdj>();
            foreach (inventoryAdj i in ia)
            {
                invadjlist.Add(InventoryAdj.Make(i.voucher_id, i.date_issue.ToString(), i.emp_supervisor_id.ToString(), i.emp_auth_id.ToString(), i.status));
            }
            return invadjlist.ToArray();
        }
        public InventoryAdjDetails[] TransferFromInvAdjDetails(InventoryAdjDetails[] iad)
        {
            List<InventoryAdjDetails> iadlist = new List<InventoryAdjDetails>();
            foreach(InventoryAdjDetails ia in iad)
            {
                iadlist.Add(InventoryAdjDetails.Make(ia.Voucher_id, ia.Item_code, ia.Description, ia.Qty, ia.Reason));
            }
            return iadlist.ToArray();
        }

       

        public Role[] TransferFromrole(role[] r)
        {
            List<Role> ro = new List<Role>();
            foreach (role role in r)
            {
                ro.Add(Role.Make(role.role_id, role.role1));
            }
            return ro.ToArray();
        }
        public Retrieval[] TransferFromStationaryTrendView(stationery_trend_report_view[] a)
        {
            List<Retrieval> b = new List<Retrieval>();
            foreach (stationery_trend_report_view c in a)
            {
                b.Add(Retrieval.Make(c.req_dept_id, c.dept_id, c.req_date.ToString(), c.status, c.item_code, c.req_quantity, c.description, c.name, c.catg_id, c.dept_name));
            }
            return b.ToArray();
        }
        public StationeryOrder[] TransferFromStationaryOrderView(stationery_po_report_view[] a)
        {
            List<StationeryOrder> b = new List<StationeryOrder>();
            foreach (stationery_po_report_view c in a)
            {
                b.Add(StationeryOrder.Make(c.po_id, c.item_code, c.catg_id, c.description, c.name, c.quantity, c.price, c.po_date.ToString(), c.status, c.total));
            }
            return b.ToArray();
        }
        public Retrieval[] TransferFromGetDeptReqList(stationery_trend_report_view[] a)
        {
            List<Retrieval> b = new List<Retrieval>();
            foreach (stationery_trend_report_view c in a)
            {
                b.Add(Retrieval.Make(c.req_dept_id, c.dept_id, c.req_date.ToString(), c.status, c.item_code, c.req_quantity, c.description, c.name, c.catg_id, c.dept_name));
            }
            return b.ToArray();
        }
        public Catalogue[] TransferFromcatalogue(catalogue[] ca)
        {
            List<Catalogue> cata = new List<Catalogue>();
            foreach (catalogue c in ca)
            {
                cata.Add(Catalogue.Make(c.item_code, c.catg_id, c.description, c.unit));
            }
            return cata.ToArray();
        }
        public Supplier[] TransferFromsupplier(supplier[] ca)
        {
            List<Supplier> cata = new List<Supplier>();
            foreach (supplier c in ca)
            {
                cata.Add(Supplier.Make(c.sup_code, c.sup_name, c.contact_name, c.sup_phone, c.sup_fax, c.sup_address, c.sup_gst, c.sup_status, c.sup_rank));
            }
            return cata.ToArray();
        }
        public Category[] TransferFromcategory(category[] ca)
        {
            List<Category> cate = new List<Category>();
            foreach (category c in ca)
            {
                cate.Add(Category.Make(c.catg_id, c.name));
            }
            return cate.ToArray();

        }
        public Employee[] TransferFromemployee(employee[] emp)
        {
            List<Employee> em = new List<Employee>();
            foreach (employee e in emp)
            {
                em.Add(Employee.Make(e.emp_id, e.emp_name, e.role_id, e.dept_id, e.emp_email, e.emp_password));
            }
            return em.ToArray();
        }
        public Employee TransferFromEmployeeObject(employee e)
        {
            Employee em = new Employee();

            em = Employee.Make(e.emp_id, e.emp_name, e.role_id, e.dept_id, e.emp_email, e.emp_password);

            return em;
        }
        public InventoryView TransferFromInventoryObject(stationery_inventory_view v)
        {
            InventoryView iv = new InventoryView();

            iv = InventoryView.Make(v.item_code, v.description, v.unit, v.reorder_quantity, v.reorder_level, v.name, v.balance);
            return iv;
        }
        public InventoryView[] TransferFromInventoryView(stationery_inventory_view[] s)
        {
            List<InventoryView> iv = new List<InventoryView>();
            foreach (stationery_inventory_view v in s)
            {
                iv.Add(InventoryView.Make(v.item_code, v.description, v.unit, v.reorder_quantity, v.reorder_level, v.name, v.balance));

            }
            return iv.ToArray();
        }
        public Department TransferFromViewDepartmentObject(department d)
        {
            Department dept = new Department();

            dept = Department.Make(d.dept_id, d.dept_code, d.dept_name, d.dept_phone, d.dept_fax, d.col_id);

            return dept;

        }

        
        public CollectionPoint TransferFromCollectionPoint(collectionPoint p)
        {
            CollectionPoint cp = new CollectionPoint();

            cp = CollectionPoint.Make(p.col_id, p.col_date.ToString(), p.col_location, p.clerk_emp_id);
            return cp;
        }

        public Department[] TransferFromDepartment(department[] de)
        {
            List<Department> dept = new List<Department>();
            foreach (department d in de)
            {
                dept.Add(Department.Make(d.dept_id, d.dept_code, d.dept_name, d.dept_phone, d.dept_fax, d.col_id));
            }
            return dept.ToArray();
        }
        public ViewCataloguePrice[] TransferFromViewCataloguePrice(view_cataloguePrice[] ca)
        {
            List<ViewCataloguePrice> cata = new List<ViewCataloguePrice>();
            foreach (view_cataloguePrice c in ca)
            {
                cata.Add(ViewCataloguePrice.Make(c.item_code, c.catg_id, c.description, c.reorder_level, c.reorder_quantity, c.unit, c.price));
            }
            return cata.ToArray();
        }

        
        public ReceiveStationeriesList[] TransferFromReceiveStationeriesList(ReceiveStationeriesList[] rsl)
        {
            List<ReceiveStationeriesList> list = new List<ReceiveStationeriesList>();
            foreach (ReceiveStationeriesList c in rsl)
            {
                ReceiveStationeriesList Model = new ReceiveStationeriesList();
                Model.id = c.id;
                Model.category = c.category;
                Model.description = c.description;
                Model.quantity = c.quantity;
                list.Add(Model);
            }
            return list.ToArray();
        }

        public RepresentativeNameDisplayInfo TransferFromRepresentativeNameDisplayInfo(RepresentativeNameDisplayInfo rbdi)
        {
            RepresentativeNameDisplayInfo r = new RepresentativeNameDisplayInfo();
            r = rbdi;
            return r;
        }

        public ViewReceiveStationeriesList[] TransferFromViewReceiveStationeriesList(ViewReceiveStationeriesList[] rsl)
        {
            List<ViewReceiveStationeriesList> list = new List<ViewReceiveStationeriesList>();

            foreach (ViewReceiveStationeriesList c in rsl)
            {
                ViewReceiveStationeriesList Model = new ViewReceiveStationeriesList();
                Model.Req_id = c.Req_id;
                Model.Emp_name = c.Emp_name;
                Model.Date = c.Date;
                list.Add(Model);
            }
            return list.ToArray();
        }

        public ViewIssuedRequisiton[] TransferFromTest(ViewIssuedRequisiton[] vr)
        {
            List<ViewIssuedRequisiton> list = new List<ViewIssuedRequisiton>();

            foreach (ViewIssuedRequisiton element in vr)
            {
                ViewIssuedRequisiton model = new ViewIssuedRequisiton();
                model.Date = element.Date;
                model.Req_id = element.Req_id;
                model.Emp_name = element.Emp_name;
                model.Status = element.Status;
                model.Reason = element.Reason;
                list.Add(model);
            }

            return list.ToArray();
        }

      


        public ViewIssuedRequisitonDetail[] TransferFromViewIssuedRequisitonDetail(ViewIssuedRequisitonDetail[] vrd)
        {
            List<ViewIssuedRequisitonDetail> list = new List<ViewIssuedRequisitonDetail>();
            foreach (ViewIssuedRequisitonDetail element in vrd)
            {
                ViewIssuedRequisitonDetail model = new ViewIssuedRequisitonDetail();
                model.Category = element.Category;
                model.Description = element.Description;
                model.Quantity = element.Quantity;
                model.Reason = element.Reason;
                list.Add(model);
            }
            return list.ToArray();
        }
    }
       
    }
