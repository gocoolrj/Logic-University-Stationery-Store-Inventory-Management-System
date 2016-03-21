using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace logicuniversity
{
    
    [ServiceContract]
    public interface IService
    {
        
        [OperationContract]

        [WebInvoke(UriTemplate = "/CreateDiscrepancy", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        bool createDiscrepancy(List<DiscrepancyDetail> discrepancyDetail);

        [OperationContract]
        [WebGet(UriTemplate = "/CatalogueList", ResponseFormat = WebMessageFormat.Json)]
        Catalogue[] GetCatalogueList();

        [OperationContract]
        [WebGet(UriTemplate = "/CategoryList", ResponseFormat = WebMessageFormat.Json)]
        Category[] GetCategoryList();


        
        [OperationContract]
        [WebGet(UriTemplate = "/PoList", ResponseFormat = WebMessageFormat.Json)]
        PurchaseOrder[] GetPoList();

        [OperationContract]
        [WebGet(UriTemplate = "/PoPendingList", ResponseFormat = WebMessageFormat.Json)]
        PurchaseOrder[] GetPoPendingList();

        [OperationContract]
        [WebGet(UriTemplate = "/PoPendingList/{id}", ResponseFormat = WebMessageFormat.Json)]
        PurchaseOrder GetPoPending(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/PoList/{id}", ResponseFormat = WebMessageFormat.Json)]
        PurchaseOrder GetPO(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/PodList/{poid}", ResponseFormat = WebMessageFormat.Json)]
        PurchaseOrderDetails[] GetPODList(string poid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdatePO", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void updatePO(PurchaseOrder po);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddPO", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddPO(PurchaseOrder po);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddPOD", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddPODD(PurchaseOrderDetails pod);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddInvAdj", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddInvAdj(InventoryAdj ia);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddInvAdjD", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddInvAdjDetails(InventoryAdjDetails iad);

        [OperationContract]
        [WebGet(UriTemplate = "/InvAdjList", ResponseFormat = WebMessageFormat.Json)]
        InventoryAdj[] getInvAdjPendingList();

        [OperationContract]
        [WebGet(UriTemplate = "/InvAdjList/{vid}", ResponseFormat = WebMessageFormat.Json)]
        InventoryAdj getInvAdjPending(string vid);

        [OperationContract]
        [WebGet(UriTemplate = "/InvAdjDList/{vid}", ResponseFormat = WebMessageFormat.Json)]
        InventoryAdjDetails[] getInvAdjDList(string vid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateInvAdj", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void UpdateInvAdj(InventoryAdj ia);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddDelegate", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddDelegate(Delegation d);

        

        [OperationContract]
        [WebGet(UriTemplate = "/EmployeeList", ResponseFormat = WebMessageFormat.Json)]
        Employee[] GetEmployeeList();


        [OperationContract]
        [WebGet(UriTemplate = "/GetActiveSupplierList", ResponseFormat = WebMessageFormat.Json)]
        Supplier[] GetActiveSupplierList();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCatalogue/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        ViewCataloguePrice[] GetCataloguePrice(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDepartmentAll",
            ResponseFormat = WebMessageFormat.Json)]
        Department[] GetDepartmentAll();

        [OperationContract]
        [WebGet(UriTemplate = "/GetDepartment/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Department GetDepartment(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployee/{emp_email}",
        ResponseFormat = WebMessageFormat.Json)]
        Employee GetEmployee(string emp_email);

        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployeeByID/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Employee GetEmployeeByID(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetInventory/{item_code}",
        ResponseFormat = WebMessageFormat.Json)]
        InventoryView GetInventory(string item_code);

        [OperationContract]
        [WebGet(UriTemplate = "/GetInventoryAll",
        ResponseFormat = WebMessageFormat.Json)]
        InventoryView[] GetInventoryAll();

        [OperationContract]
        [WebInvoke(UriTemplate = "/CheckUserNamePassword?emp_email={email}&password={password}", Method = "GET",
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CheckUserNamePassword(string email, string password);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetUserRole?emp_email={email}", Method = "GET",
        ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string getUserRole(string email);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetRetrievement", Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        Retrieval[] GetRetrievement();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetStationeryOrder?fromDate={fromDate}&toDate={toDate}", Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        StationeryOrder[] GetStationeryOrder(DateTime fromDate, DateTime toDate);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetRequisitionByItemCode/{item_code}", Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        Retrieval[] GetRequisitionByItemCode(string item_code);


        [OperationContract]
        [WebInvoke(UriTemplate = "/GetRetrimentDetail?item_code={item_code}&fromDate={fromDate}&toDate={toDate}", Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        Retrieval[] GetRetrimentDetail(string item_code, DateTime fromDate, DateTime toDate);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetDeptReqList?dept_id={dept_id}&fromDate={fromDate}&toDate={toDate}", Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        Retrieval[] GetDeptReqList(string dept_id, DateTime fromDate, DateTime toDate);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetCollectionPoint/{dept_id}", Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        CollectionPoint GetCollectionPoint(string dept_id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateReqistionByDeptDetail", Method = "POST", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        bool UpdateReqistionByDeptDetail(RequisitionByDeptDetail rDD);

       
        [OperationContract]
        [WebGet(UriTemplate = "/ReceiveStationeriesList", ResponseFormat = WebMessageFormat.Json)]
        ReceiveStationeriesList[] GetReceiveStationeriesList();

        [OperationContract]
        [WebGet(UriTemplate = "/RepresentativeNameDisplayInfo", ResponseFormat = WebMessageFormat.Json)]
        RepresentativeNameDisplayInfo GetRepresentativeNameDisplayInfo();

        [OperationContract]
        [WebGet(UriTemplate = "/ViewReceiveStationeriesList", ResponseFormat = WebMessageFormat.Json)]
        ViewReceiveStationeriesList[] GetViewReceiveStationeriesListInfo();

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateUnfulfillItem", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateUnfulfillItem(WCF_UpdateUnfulfillItem uui);

       

        [OperationContract]
        [WebGet(UriTemplate = "/ApproveRequisition", ResponseFormat = WebMessageFormat.Json)]
        EmployeeRequisition[] GetPenddingRequisitionList();

        [OperationContract]
        [WebGet(UriTemplate = "/MakeRequisition", ResponseFormat = WebMessageFormat.Json)]
        RequisitionItem[] GetCurrentRequisition();

        [OperationContract]
        [WebGet(UriTemplate = "/ApproveRequisitionDetail/{req_id}", ResponseFormat = WebMessageFormat.Json)]
        RequisitionItem[] GetRequisitionItemByID(string req_id);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateRequisitionStatus", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        int UpdateRequisitionStatus(EmployeeRequisitionDetail reqdetail);

        [OperationContract]
        [WebInvoke(UriTemplate = "/SelfRequisitions", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        SelfRequisition[] FindSelfRequisition(int emp_id);

        [OperationContract]
        [WebGet(UriTemplate = "/CategoryType", ResponseFormat = WebMessageFormat.Json)]
        CategoryType[] getAllCategoryType();

        [OperationContract]
        [WebGet(UriTemplate = "/CategoryAllDetail", ResponseFormat = WebMessageFormat.Json)]
        CategoryDetail[] getAllCategoryDetails();

        [OperationContract]
        [WebGet(UriTemplate = "/CategoryDetailByType/{type}", ResponseFormat = WebMessageFormat.Json)]
        CategoryDetail[] getCategoryDetailsByType(string type);

        [OperationContract]
        [WebGet(UriTemplate = "/GetPersonalRequisition/{id}", ResponseFormat = WebMessageFormat.Json)]
        SelfRequisition[] getSelfRequisitions(string id);


        [WebGet(UriTemplate = "/GetSpecificRequisition/{req_id}", ResponseFormat = WebMessageFormat.Json)]
        EmployeeRequisitionDetail getSpecificRequisition(string req_id);

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateRequisition", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int CreateRequisition(EmployeeRequisitionDetail emp);

        [OperationContract]
        [WebInvoke(UriTemplate = "UploadRequisitionDetail", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int insertDetailItems(RequisitionDetailItems req);

        [OperationContract]
        [WebGet(UriTemplate = "GetUnfulfilledItems/{req_id}", ResponseFormat = WebMessageFormat.Json)]
        UnfulfilledItems[] getUnfulfillitems(string req_id);

        

        [OperationContract]
        [WebGet(UriTemplate = "/ViewRequisitionHistoryList", ResponseFormat = WebMessageFormat.Json)]
        ViewIssuedRequisiton[] GetViewRequisitionHistoryList();

        [OperationContract]
        [WebGet(UriTemplate = "/ViewPendingList", ResponseFormat = WebMessageFormat.Json)]
        ViewIssuedRequisiton[] GetViewPendingList();

        [OperationContract]
        [WebGet(UriTemplate = "/ViewIssuedRequisitionDetail/{id}", ResponseFormat = WebMessageFormat.Json)]
        ViewIssuedRequisitonDetail[] GetViewIssuedRequisitonDetail(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateRequisitionDetail", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateRequisitionDetail(WCF_UpdateRequisitionDetail urd);

        
    }


    
    [DataContract]
    public class Catalogue
    {
        string item_code;
        int catg_id;
        string description;
        int reorder_level;
        int reorder_quantity;
        string unit;

        public static Catalogue Make(string item_code, int catg_id, string description, string unit)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.item_code = item_code;
            catalogue.catg_id = catg_id;
            catalogue.description = description;
            catalogue.unit = unit;
            return catalogue;
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Reorder_level
        {
            get { return reorder_level; }
            set { reorder_level = value; }
        }

        [DataMember]
        public int Reorder_quantity
        {
            get { return reorder_quantity; }
            set { reorder_quantity = value; }
        }

        [DataMember]
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
    }

    [DataContract]
    public class Category
    {
        int catg_id;
        string name;

        public static Category Make(int cat, string na)
        {
            Category c = new Category();
            c.catg_id = cat;
            c.name = na;
            return c;
        }
        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }

        
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



    }

    [DataContract]
    public class PurchaseOrderDetails
    {
        string po_id, item_code, desc;
        int quantity;
        decimal price, amount;
        
        [DataMember]
        public decimal Price
        {
          get { return price; }
          set { price = value; }
        }
        [DataMember]
        public int Quantity
        {
          get { return quantity; }
          set { quantity = value; }
        }
        [DataMember]
        public string Item_code
        {
          get { return item_code; }
          set { item_code = value; }
        }
        [DataMember]
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        [DataMember]
        public string Po_id
        {
          get { return po_id; }
          set { po_id = value; }
        }
        [DataMember]
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        public static PurchaseOrderDetails Make(string po_id,string item_code,string desc,int quantity,decimal price,decimal amount)
        {
            PurchaseOrderDetails pod=new PurchaseOrderDetails();
            pod.po_id=po_id;
            pod.item_code=item_code;
            pod.desc = desc;
            pod.quantity=quantity;
            pod.price=price;
            pod.amount = amount;
            return pod;
        }
    }

    [DataContract]
    public class PurchaseOrder
    {
        string po_id;
        string sup_code;
        string remark;
        string po_date;
        string po_duedate;
        string po_approvedate;
        decimal net_amount;
        string status;

        public static PurchaseOrder Make(string po_id, string sup_code, string po_date, string po_duedate, string po_approvedate, decimal? net_amount, string status,string remark)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.po_id = po_id;
            po.sup_code = sup_code;
            po.po_date = po_date;
            po.po_duedate = po_duedate;
            po.po_approvedate = po_approvedate;
            po.net_amount = (decimal)net_amount;
            po.status = status;
            po.remark = remark;
            return po;
        }

        [DataMember]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        [DataMember]
        public string Po_id
        {
            get { return po_id; }
            set { po_id = value; }
        }

        [DataMember]
        public string Sup_code
        {
            get { return sup_code; }
            set { sup_code = value; }
        }

        [DataMember]
        public string Po_date
        {
            get { return po_date; }
            set { po_date = value; }
        }

        [DataMember]
        public string Po_duedate
        {
            get { return po_duedate; }
            set { po_duedate = value; }
        }

        [DataMember]
        public string Po_approvedate
        {
            get { return po_approvedate; }
            set { po_approvedate = value; }
        }

        [DataMember]
        public decimal Net_amount
        {
            get { return net_amount; }
            set { net_amount = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


       
    }

    [DataContract]
    public class Employee
    {
        int emp_id;
        string emp_name;
        int role_id;
        int dept_id;
        string emp_email;
        string emp_password;

        public static Employee Make( int emp_id, string emp_name, int? role_id, int? dept_id, string emp_email,string emp_password)
        {
              Employee emp = new Employee();
              emp.emp_id = emp_id;
            emp.emp_name = emp_name;
            emp.role_id = (int)role_id;
            emp.dept_id = (int)dept_id;
            emp.emp_email = emp_email;
            emp.emp_password = emp_password;
            return emp;
        }

        [DataMember]
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }
        
        [DataMember]
        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }
        
        [DataMember]
        public int Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }
        
        [DataMember]
        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        
        [DataMember]
        public string Emp_email
        {
            get { return emp_email; }
            set { emp_email = value; }
        }
        
        [DataMember]
        public string Emp_password
        {
            get { return emp_password; }
            set { emp_password = value; }
        }

       
    }

    [DataContract]
    public class InventoryAdj
    {
        string voucher_id, date_issue, sup_id, auth_id, status;
        
        public static InventoryAdj Make(string vid,string date_issue,string sup_id,string auth_id, string status)
        {
            InventoryAdj invadj = new InventoryAdj();
            invadj.voucher_id = vid;
            invadj.date_issue = date_issue;
            invadj.sup_id = sup_id;
            invadj.auth_id = auth_id;
            invadj.status = status;
            return invadj;
        }
        
        [DataMember]
        public string Voucher_id
        {
            get { return voucher_id; }
            set { voucher_id = value; }
        }
        [DataMember]
        public string Date_issue
        {
            get { return date_issue; }
            set { date_issue = value; }
        }
        [DataMember]
        public string Sup_id
        {
            get { return sup_id; }
            set { sup_id = value; }
        }
        [DataMember]
        public string Auth_id
        {
            get { return auth_id; }
            set { auth_id = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    [DataContract]
    public class InventoryAdjDetails
    {
        string voucher_id, item_code, description, reason;
        int qty;

        public static InventoryAdjDetails Make(string vid,string itemcode,string desc,int qty,string reason)
        {
            InventoryAdjDetails iad = new InventoryAdjDetails();
            iad.voucher_id = vid;
            iad.item_code = itemcode;
            iad.description = desc;
            iad.qty = qty;
            iad.reason = reason;
            return iad;
        }

        [DataMember]
        public string Voucher_id
        {
            get { return voucher_id; }
            set { voucher_id = value; }
        }
        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        [DataMember]
        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
    }
    [DataContract]
    public class Delegation
    {
        int emp_id, head_id;
        string start_date, end_date, reason, status;

        public Delegation Make(int emp_id, int head_id, string start_date, string end_date, string reason, string status)
        {
            Delegation d = new Delegation();
            d.emp_id = emp_id;
            d.head_id = head_id;
            d.start_date = start_date;
            d.end_date = end_date;
            d.reason = reason;
            d.status = status;
            return d;
        }
        [DataMember]
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }
        [DataMember]
        public int Head_id
        {
            get { return head_id; }
            set { head_id = value; }
        }
        [DataMember]
        public string Start_date
        {
            get { return start_date; }
            set { start_date = value; }
        }
        [DataMember]
        public string End_date
        {
            get { return end_date; }
            set { end_date = value; }
        }
        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
    
    [DataContract]
    public class RequisitionByDeptDetail
    {
        int req_dept_id;
        string item_code;
        int req_quantity;
        public static RequisitionByDeptDetail Make(int req_dept_id, string item_code, int req_quantity)
        {
            RequisitionByDeptDetail r = new RequisitionByDeptDetail();
            r.req_dept_id = req_dept_id;
            r.item_code = item_code;
            r.req_quantity = req_quantity;
            return r;

        }
        [DataMember]
        public int Req_dept_id
        {
            get { return req_dept_id; }
            set { req_dept_id = value; }
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Req_quantity
        {
            get { return req_quantity; }
            set { req_quantity = value; }
        }
    }

    [DataContract]
    public class InventoryView
    {
        string item_code;
        int reorder_level;
        string description;
        int reorder_quantity;
        string unit;
        string name;
        int balance;


        public static InventoryView Make(string item_code, string description, string unit, int? reorder_quantity, int? reorder_level, string name, int? balance)
        {
            InventoryView iv = new InventoryView();
            iv.item_code = item_code;
            iv.reorder_level = (int)reorder_level;
            iv.description = description;
            iv.reorder_quantity = (int)reorder_quantity;
            iv.unit = unit;
            iv.name = name;
            iv.balance = (int)balance;
            return iv;
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }



        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Reorder_level
        {
            get { return reorder_level; }
            set { reorder_level = value; }
        }

        [DataMember]
        public int Reorder_quantity
        {
            get { return reorder_quantity; }
            set { reorder_quantity = value; }
        }

        [DataMember]
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        [DataMember]
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }




    }

    [DataContract]
    public class Role
    {
        int role_id;
        string role1;

        public static Role Make(int role_id, string role1)
        {
            Role r = new Role();
            r.role_id = role_id;
            r.role1 = role1;
            return r;
        }
        [DataMember]
        public int Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }


        [DataMember]
        public string Role1
        {
            get { return role1; }
            set { role1 = value; }
        }
    }
    [DataContract]
    public class ViewCataloguePrice
    {
        string item_code;
        int catg_id;
        string description;
        int reorder_level;
        int reorder_quantity;
        string unit;
        decimal price;

        public static ViewCataloguePrice Make(string item_code, int catg_id, string description, int? reorder_level, int? reorder_quantity, string unit, decimal? price)
        {
            ViewCataloguePrice catalogue = new ViewCataloguePrice();
            catalogue.item_code = item_code;
            catalogue.catg_id = catg_id;
            catalogue.description = description;
            catalogue.reorder_level = (int)reorder_level;
            catalogue.reorder_quantity = (int)reorder_quantity;
            catalogue.unit = unit;
            catalogue.price = (decimal)price;
            return catalogue;
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Reorder_level
        {
            get { return reorder_level; }
            set { reorder_level = value; }
        }



        [DataMember]
        public int Reorder_quantity
        {
            get { return reorder_quantity; }
            set { reorder_quantity = value; }
        }

        [DataMember]
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        [DataMember]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        //internal static ViewCataloguePrice Make(string p1, int p2, string p3, int? nullable1, int? nullable2, string p4, decimal? nullable3)
        // {
        //    throw new NotImplementedException();
        // }
    }

    [DataContract]
    public class Supplier
    {
        string sup_code;
        string sup_name;
        string contact_name;
        string sup_phone;
        string sup_fax;
        string sup_address;
        string sup_gst;
        string sup_status;
        string sup_rank;
        public static Supplier Make(string sup_code, string sup_name, string contact_name, string sup_phone, string sup_fax, string sup_address, string sup_gst, string sup_status, string sup_rank)
        {
            Supplier s = new Supplier();
            s.sup_code = sup_code;
            s.sup_name = sup_name;
            s.contact_name = contact_name;
            s.sup_phone = sup_phone;
            s.sup_fax = sup_fax;
            s.sup_address = sup_address;
            s.sup_gst = sup_gst;
            s.sup_status = sup_status;
            s.sup_rank = sup_rank;
            return s;
        }



        [DataMember]
        public string Sup_code
        {
            get { return sup_code; }
            set { sup_code = value; }
        }

        [DataMember]
        public string Sup_name
        {
            get { return sup_name; }
            set { sup_name = value; }
        }

        [DataMember]
        public string Contact_name
        {
            get { return contact_name; }
            set { contact_name = value; }
        }

        [DataMember]
        public string Sup_phone
        {
            get { return sup_phone; }
            set { sup_phone = value; }
        }

        [DataMember]
        public string Sup_fax
        {
            get { return sup_fax; }
            set { sup_fax = value; }
        }

        [DataMember]
        public string Sup_address
        {
            get { return sup_address; }
            set { sup_address = value; }
        }

        [DataMember]
        public string Sup_gst
        {
            get { return sup_gst; }
            set { sup_gst = value; }
        }

        [DataMember]
        public string Sup_status
        {
            get { return sup_status; }
            set { sup_status = value; }
        }

        [DataMember]
        public string Sup_rank
        {
            get { return sup_rank; }
            set { sup_rank = value; }
        }
    }

    [DataContract]
    public class Retrieval
    {
        string description;
        string status;
        int req_dept_id;
        string item_code;
        int req_quantity;
        int catg_id;
        string name;
        int dept_id;
        string dept_name;
        string req_date;

        public static Retrieval Make(int req_dept_id, int? dept_id, string req_date, string status, string item_code, int? req_quantity, string description, string name, int catg_id, string dept_name)
        {
            Retrieval r = new Retrieval();
            r.req_dept_id = req_dept_id;
            r.dept_id = (int)dept_id;
            r.req_date = req_date;
            r.status = status;
            r.item_code = item_code;
            r.req_quantity = (int)req_quantity;
            r.description = description;
            r.name = name;
            r.catg_id = catg_id;
            r.dept_name = dept_name;
            return r;
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public int Req_dept_id
        {
            get { return req_dept_id; }
            set { req_dept_id = value; }
        }
        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Req_quantity
        {
            get { return req_quantity; }
            set { req_quantity = value; }
        }

        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }
        [DataMember]
        public string Dept_name
        {
            get { return dept_name; }
            set { dept_name = value; }
        }
        [DataMember]
        public string Req_date
        {
            get { return req_date; }
            set { req_date = value; }
        }
    }

    [DataContract]
    public class Department
    {
        int dept_id;
        string dept_code;
        string dept_name;
        string dept_phone;
        string dept_fax;
        int col_id;
        public static Department Make(int dept_id, string dept_code, string dept_name, string dept_phone, string dept_fax, int col_id)
        {
            Department d = new Department();
            d.dept_id = dept_id;
            d.dept_code = dept_code;
            d.dept_name = dept_name;
            d.dept_phone = dept_phone;
            d.dept_fax = dept_fax;
            d.col_id = col_id;
            return d;
        }

        [DataMember]
        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }

        [DataMember]
        public string Dept_code
        {
            get { return dept_code; }
            set { dept_code = value; }
        }

        [DataMember]
        public string Dept_name
        {
            get { return dept_name; }
            set { dept_name = value; }
        }

        [DataMember]
        public string Dept_phone
        {
            get { return dept_phone; }
            set { dept_phone = value; }
        }

        [DataMember]
        public string Dept_fax
        {
            get { return dept_fax; }
            set { dept_fax = value; }
        }

        [DataMember]
        public int Col_id
        {
            get { return col_id; }
            set { col_id = value; }
        }
    }

    [DataContract]
    public class CollectionPoint
    {
        int col_id;
        string col_date;
        string col_location;
        int clerk_emp_id;

        public static CollectionPoint Make( int col_id, string col_date,string col_location,int? clerk_emp_id)
        {
            CollectionPoint cp = new CollectionPoint();
            cp.col_id = col_id;
            cp.col_date = col_date;
            cp.col_location = col_location;
            cp.clerk_emp_id = (int)clerk_emp_id;
            return cp;
        }
        [DataMember]
        public int Col_id
        {
            get { return col_id; }
            set { col_id = value; }
        }

        
        [DataMember]
        public int Clerk_emp_id
        {
            get { return clerk_emp_id; }
            set { clerk_emp_id = value; }
        }

        
        [DataMember]
        public string Col_location
        {
            get { return col_location; }
            set { col_location = value; }
        }

        
        [DataMember]
        public string Col_date
        {
            get { return col_date; }
            set { col_date = value; }
        }


    }

    [DataContract]
    public class StationeryOrder
    {
        string po_id;
        string item_code;
         int catg_id;
        string description;
        string name;
        int quantity;
        decimal price;
        string po_date;
        string status;
        decimal total;
                                            // Make(c.po_id, c.item_code, c.catg_id, c.description, c.name, c.quantity, c.price, c.po_date, c.status, c.total));
        //internal static StationeryOrder Make(string p1, string p2, int p3, string p4, string p5, int? nullable1, decimal? nullable2, DateTime? nullable3, string p6, decimal? nullable4)
        //{
        //    throw new NotImplementedException();
        //}
        public static StationeryOrder Make(string po_id, string item_code, int catg_id, string description, string name, int? quantity, decimal? price, string po_date, string status, decimal? total)
        {
            StationeryOrder so = new StationeryOrder();
            so.po_id = po_id;
            so.item_code = item_code;
            so.catg_id = catg_id;
            so.description = description;
            so.name = name;
            so.quantity = (int)quantity;
            so.price = (decimal)price;
            so.po_date = po_date;
            so.status = status;
            so.total = (decimal)total;
            return so;

        }

        [DataMember]
        public string Po_id
        {
            get { return po_id; }
            set { po_id = value; }
        }
        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        [DataMember]
        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        [DataMember]
        public string Po_date
        {
            get { return po_date; }
            set { po_date = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember]
        public Decimal Total
        {
            get { return total; }
            set { total = value; }
        }





       
    }

    
    [DataContract]
    public class GVTable
    {
        string ItemCode;
        string CategoryID;
        string DescID;
        int QuantityID;

        public static GVTable Make(string item_code, string cate, string desc, int quantity)
        {
            GVTable g = new GVTable();
            g.ItemCode = item_code;
            g.CategoryID = cate;
            g.DescID = desc;
            g.QuantityID = quantity;
            return g;
        }

        [DataMember]
        public string Category
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }


        [DataMember]
        public string Description
        {
            get { return DescID; }
            set { DescID = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return QuantityID; }
            set { QuantityID = value; }
        }

        [DataMember]
        public string Item_code
        {
            get { return ItemCode; }
            set { ItemCode = value; }
        }

    }
    [DataContract]
    public class ReceiveStationeriesListTable
    {
        string Req_Dept_id;
        string Emp_Name;
        DateTime date;

        public static ReceiveStationeriesListTable Make(string req_dept_id, string emp_name, DateTime date)
        {
            ReceiveStationeriesListTable t = new ReceiveStationeriesListTable();
            t.Emp_Name = emp_name;
            t.date = date;
            t.Req_Dept_id = req_dept_id;
            return t;
        }

        [DataMember]
        public string Req_Dept_Id
        {
            get { return Req_Dept_id; }
            set { Req_Dept_id = value; }
        }

        [DataMember]
        public string Emp_name
        {
            get { return Emp_Name; }
            set { Emp_Name = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
    [DataContract]
    public class ReceiveStationeriesList
    {

        string Id;
        string Category;
        string Description;
        string Quantity;

        [DataMember]
        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        [DataMember]
        public string category
        {
            get { return Category; }
            set { Category = value; }
        }

        [DataMember]
        public string quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        [DataMember]
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
    }
    [DataContract]
    public class RepresentativeNameDisplayInfo
    {

        string deptName;
        string collPoint;
        string repName;
        string deliBy;

        [DataMember]
        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }


        [DataMember]
        public string CollPoint
        {
            get { return collPoint; }
            set { collPoint = value; }
        }


        [DataMember]
        public string RepName
        {
            get { return repName; }
            set { repName = value; }
        }



        [DataMember]
        public string DeliBy
        {
            get { return deliBy; }
            set { deliBy = value; }
        }
    }
    [DataContract]
    public class ViewReceiveStationeriesList
    {
        string req_id;
        string emp_name;
        string date;

        [DataMember]
        public string Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }

        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
    [DataContract]
    public class WCF_UpdateUnfulfillItem
    {
        [DataMember]
        public string desc;

        [DataMember]
        public string deptname;

        [DataMember]
        public string quantity;

        [DataMember]
        public string unfulfilldate;

        [DataMember]
        public string remarks;

        public WCF_UpdateUnfulfillItem(string desc, string deptname, string quantity, string unfulfilldate, string remarks)
        {
            this.desc = desc;
            this.deptname = deptname;
            this.quantity = quantity;
            this.unfulfilldate = unfulfilldate;
            this.remarks = remarks;
        }
    }


    [DataContract]
    public class CategoryType
    {
        int catg_id;
        string name;

        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    [DataContract]
    public class CategoryDetail
    {
        int catg_id;
        string item_code;
        string name;
        string description;
        int quantity;

        [DataMember]
        public int Catg_id
        {
            get { return catg_id; }
            set { catg_id = value; }
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    [DataContract]
    public class Catalogue_CategoryName
    {
        string item_code;
        string description;
        string name;

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    [DataContract]
    public class StockCard
    {
        string item_code;
        DateTime date;
        string s_description;
        string quantity;

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public string S_description
        {
            get { return s_description; }
            set { s_description = value; }
        }

        [DataMember]
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    [DataContract]
    public class StockCardDetail
    {
        string item_code;
        string c_description;
        string unit;
        int balance;
        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string C_description
        {
            get { return c_description; }
            set { c_description = value; }
        }

        [DataMember]
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        [DataMember]
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }

    [DataContract]
    public class Stationery
    {
        string item_code;
        int dept_id;
        string dept_name;
        string description;
        int quantity;

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }

        [DataMember]
        public string Dept_name
        {
            get { return dept_name; }
            set { dept_name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }

    [DataContract]
    public class RejectItems
    {
        string category;
        string desc;
        string quantity;
        string remark;
        string dept_name;
        DateTime date;

        [DataMember]
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        [DataMember]
        public string Desc
        {

            get { return desc; }
            set { desc = value; }
        }

        [DataMember]
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        [DataMember]
        public string Dept_name
        {
            get { return dept_name; }
            set { dept_name = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

    }

    [DataContract]
    public class Stationery1
    {
        string description;
        string item_code;
        int req_quantity;

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Req_quantity
        {
            get { return req_quantity; }
            set { req_quantity = value; }
        }

    }

    [DataContract]
    public class Discrepancy
    {
        DateTime date;
        string voucher_id;
        string emp_name;
        string status;

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public string Voucher_id
        {
            get { return voucher_id; }
            set { voucher_id = value; }
        }

        [DataMember]
        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }


    [DataContract]
    public class Disbursement
    {
        string item_code;
        string description;
        int req_amount;
        int actual_amount;

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Req_amount
        {
            get { return req_amount; }
            set { req_amount = value; }
        }

        [DataMember]
        public int Actual_amount
        {
            get { return actual_amount; }
            set { actual_amount = value; }
        }
    }

    [DataContract]
    public class ViewIssuedRequisiton
    {
        string date;
        string emp_name;
        string status;
        string req_id;
        string reason;

        [DataMember]
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public string Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

    }

    [DataContract]
    public class ViewIssuedRequisitonDetail
    {
        string cate;
        string desc;
        string quantity;
        string reason;

        [DataMember]
        public string Category
        {
            get { return cate; }
            set { cate = value; }
        }

        [DataMember]
        public string Description
        {
            get { return desc; }
            set { desc = value; }
        }

        [DataMember]
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }

    [DataContract]
    public class DiscrepancyDetail
    {
        string item_code;
        string description;
        int quantity;
        string reason;

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }

    

    public class UnfulfilledItems
    {
        int id;
        string item_code;
        string name;
        string description;
        int quantity;
        string reason;
        int req_id;

        [DataMember]
        public int Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
    [DataContract]
    public class SelfRequisition
    {
        int req_id;
        int emp_id;
        int dept_id;
        string status;
        DateTime req_date;
        string date_string;


        [DataMember]
        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }

        [DataMember]
        public int Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public int Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime Req_date
        {
            get { return req_date; }
            set { req_date = value; }
        }

        [DataMember]
        public string Date_string
        {
            get { return date_string; }
            set { date_string = value; }
        }
    }

    [DataContract]
    public class EmployeeRequisitionDetail
    {
        int req_id;
        int dept_id;
        int requst_emp_id;
        string requst_emp_name;
        int approve_emp_id;
        string approve_emp_name;
        int received_clerk_id;
        string received_clerk_name;
        DateTime req_date;
        DateTime approve_date;
        DateTime received_date;
        string status;
        int unfulfillquantity;
        string requesttime_text;
        string approvetime_text;
        string receivetime_text;

        [DataMember]
        public int Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public string Requesttime_text
        {
            get { return requesttime_text; }
            set { requesttime_text = value; }
        }
        [DataMember]
        public string Approvetime_text
        {
            get { return approvetime_text; }
            set { approvetime_text = value; }
        }
        [DataMember]
        public string Receivetime_text
        {
            get { return receivetime_text; }
            set { receivetime_text = value; }
        }

        [DataMember]
        public int Unfulfillquantity
        {
            get { return unfulfillquantity; }
            set { unfulfillquantity = value; }
        }

        [DataMember]
        public int Dept_id
        {
            get { return dept_id; }
            set { dept_id = value; }
        }

        [DataMember]
        public int Requst_emp_id
        {
            get { return requst_emp_id; }
            set { requst_emp_id = value; }
        }

        public string Requst_emp_name
        {
            get { return requst_emp_name; }
            set { requst_emp_name = value; }
        }

        [DataMember]
        public DateTime Req_date
        {
            get { return req_date; }
            set { req_date = value; }
        }

        [DataMember]
        public DateTime Approve_date
        {
            get { return approve_date; }
            set { approve_date = value; }
        }

        [DataMember]
        public int Approve_emp_id
        {
            get { return approve_emp_id; }
            set { approve_emp_id = value; }
        }

        [DataMember]
        public string Approve_emp_name
        {
            get { return approve_emp_name; }
            set { approve_emp_name = value; }
        }

        [DataMember]
        public int Received_clerk_id
        {
            get { return received_clerk_id; }
            set { received_clerk_id = value; }
        }

        [DataMember]
        public string Received_emp_name
        {
            get { return received_clerk_name; }
            set { received_clerk_name = value; }
        }


        [DataMember]
        public DateTime Received_date
        {
            get { return received_date; }
            set { received_date = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    [DataContract]
    public class EmployeeRequisition
    {
        int req_id;
        string emp_name;
        DateTime req_date;
        string status;

        [DataMember]
        public int Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }

        [DataMember]
        public DateTime Req_date
        {
            get { return req_date; }
            set { req_date = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

    [DataContract]
    public class RequisitionItem
    {
        string item_code;
        string catagory;
        string description;
        int quantity;

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public string Catagory
        {
            get { return catagory; }
            set { catagory = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }

    [DataContract]
    public class RequisitionDetailItems
    {
        int req_id;
        string item_code;
        int quantity;

        [DataMember]
        public int Req_id
        {
            get { return req_id; }
            set { req_id = value; }
        }

        [DataMember]
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    
    [DataContract]
    public class WCF_UpdateRequisitionDetail
    {
        [DataMember]
        public string req_id;

        [DataMember]
        public string status;

        [DataMember]
        public string reason;

        public WCF_UpdateRequisitionDetail(string req_id, string status, string reason)
        {
            this.req_id = req_id;
            this.status = status;
            this.reason = reason;
        }
    }

}
