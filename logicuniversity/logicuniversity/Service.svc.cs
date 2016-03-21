using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using logicuniversity.WebService;
using logicuniversity.JSONClassTransfer;
using logicuniversity.Controllers;
using logicuniversity.DAO;
using logicuniversity;
using Entity;


namespace logicuniversity
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        CatalogueBroker catabroker = new CatalogueBroker();
        CategoryBroker catebroker = new CategoryBroker();
        PurchaseOrderBroker purchasebroker = new PurchaseOrderBroker();
        EmployeeBroker empbroker = new EmployeeBroker();
        POController poc = new POController();
        PODetailController podc = new PODetailController();
        InvAdjController iac = new InvAdjController();
        SupplierBroker supbroker = new SupplierBroker();
        RequisitionBroker reqbroker = new RequisitionBroker();
        DepartmentBroker deptBroker = new DepartmentBroker();
        CollectionBroker colBroker = new CollectionBroker();
        ReceiveStationeriesListBroker rebroker = new ReceiveStationeriesListBroker();
        RepresentativeNameDisplayInfoBroker rbroker = new RepresentativeNameDisplayInfoBroker();
        ViewReceiveStationeriesListBroker brbrober = new ViewReceiveStationeriesListBroker();
        updateUnfulfillItemBroker ubroker = new updateUnfulfillItemBroker();
        DelegateController dc = new DelegateController();
        EFFacade ef = new EFFacade();


        JSONTransfer jst = new JSONTransfer();

        public PurchaseOrder[] GetPoList()
        {
            return jst.TransferFrompurchaseOrder(purchasebroker.getPurchasaeOrderList());
        }
        public PurchaseOrder[] GetPoPendingList()
        {
            return jst.TransferFrompurchaseOrder(purchasebroker.getPurchasaeOrderPendingList());
        }
        public PurchaseOrder GetPO(string id)
        {
            return jst.TransferFromPO(purchasebroker.getPurchaseOrder(id));
        }
        public PurchaseOrder GetPoPending(string id)
        {
            return jst.TransferFromPO(purchasebroker.getPurchaseOrderPending(id));
        }
        public PurchaseOrderDetails[] GetPODList(string poid)
        {
            return jst.TransferFromPOD(purchasebroker.getPurchaseOrderDetail(poid));
        }
        public void updatePO(PurchaseOrder po)
        {
            purchasebroker.updatePO(po);
        }
        public string AddPO(PurchaseOrder p)
        {
            return poc.AddPurchaseOrder(p.Sup_code, p.Net_amount, p.Po_duedate);
        }
        public void AddPODD(PurchaseOrderDetails p)
        {
            podc.AddPODD(p);
        }
        public string AddInvAdj(InventoryAdj ia)
        {
            return iac.AddInvAdj(ia);
        }
        public void AddInvAdjDetails(InventoryAdjDetails iad)
        {
            iac.AddInvAdjDetail(iad);
        }
        public InventoryAdj[] getInvAdjPendingList()
        {
            return jst.TransferFromInvAdj(iac.getInvAdjPendingList());
        }
        public InventoryAdj getInvAdjPending(string id)
        {
            return jst.TransferFromInvAdj(iac.getInvAdjPending(id));
        }
        public InventoryAdjDetails[] getInvAdjDList(string id)
        {
            return jst.TransferFromInvAdjDetails(iac.getInvAdjDList(id));
        }
        public void UpdateInvAdj(InventoryAdj ia)
        {
            iac.UpdateInvAdj(ia);
        }
        public void AddDelegate(Delegation d)
        {
            dc.AddDelegate(d);
        }
     
        public Catalogue[] GetCatalogueList()
        {
            return jst.TransferFromcatalogue(catabroker.getCatalogueList());
        }
        public Employee[] GetEmployeeList()
        {
            return jst.TransferFromemployee(empbroker.getAll());
        }
        public Catalogue[] GetCatalogue(string id)
        {
            return jst.TransferFromcatalogue(catabroker.getCatalogue(id));
        }
        public ViewCataloguePrice[] GetCataloguePrice(string id)
        {
            return jst.TransferFromViewCataloguePrice(catabroker.getCataloguePrice(id));
        }
        public Employee GetEmployee(string emp_email)
        {
            return jst.TransferFromEmployeeObject(empbroker.getEmployee(emp_email));
        }

        public Employee GetEmployeeByID(string id)
        {
            return jst.TransferFromEmployeeObject(empbroker.getEmployeeByID(id));
        }
        public InventoryView GetInventory(string item_code)
        {
            return jst.TransferFromInventoryObject(catabroker.getInventory(item_code));
        }
        public InventoryView[] GetInventoryAll()
        {
            return jst.TransferFromInventoryView(catabroker.getInventoryAll());
        }
        public Department[] GetDepartmentAll()
        {
            return jst.TransferFromDepartment(deptBroker.getDepartmentAll());
        }
        public Department GetDepartment(string id)
        {
            return jst.TransferFromViewDepartmentObject(deptBroker.getDepartment(id));
        }
        public Supplier[] GetActiveSupplierList()
        {
            return jst.TransferFromsupplier(supbroker.getActiveSupplierList());
        }
        public Category[] GetCategoryList()
        {
            return jst.TransferFromcategory(catebroker.getCategoryList());
        }
        public bool CheckUserNamePassword(string email, string password)
        {
            bool chk = empbroker.checkUserNamePassword(email, password);
            return chk;
        }
        public Retrieval[] GetRetrievement()
        {
            return reqbroker.getRetrivement();
        }
        public StationeryOrder[] GetStationeryOrder(DateTime fromDate, DateTime toDate)
        {
            return jst.TransferFromStationaryOrderView(purchasebroker.getStationeryOrder(fromDate, toDate));
        }
        public Retrieval[] GetDeptReqList(string dept_id ,DateTime fromDate, DateTime toDate)
        {
            return jst.TransferFromGetDeptReqList(reqbroker.getDeptReqList(dept_id,fromDate, toDate));
        }
        public Retrieval[] GetRetrimentDetail(string item_code, DateTime fromDate, DateTime toDate)
        {
            return jst.TransferFromStationaryTrendView(reqbroker.getRetrimentDetail(item_code, fromDate, toDate));
        }
        public string getUserRole(string email)
        {
            string role = empbroker.getUserRole(email);
            return role;
        }
        public Retrieval[] GetRequisitionByItemCode(string item_code)
        {
            return jst.TransferFromStationaryTrendView(reqbroker.getRequisitionByItemCode(item_code));
        }
        public bool UpdateReqistionByDeptDetail(RequisitionByDeptDetail rq)
        {
            bool chk = reqbroker.updateReqistionByDeptDetail(rq);
            return chk;
        }
        public CollectionPoint GetCollectionPoint(string dept_id)
        {
            return jst.TransferFromCollectionPoint(colBroker.getcollectionPoint(dept_id));
        }

      
        public ReceiveStationeriesList[] GetReceiveStationeriesList()
        {
            return jst.TransferFromReceiveStationeriesList(rebroker.GetReceiveStationeriesList());
        }

        public RepresentativeNameDisplayInfo GetRepresentativeNameDisplayInfo()
        {
            return jst.TransferFromRepresentativeNameDisplayInfo(rbroker.getDisolay());
        }

        public ViewReceiveStationeriesList[] GetViewReceiveStationeriesListInfo()
        {
            return jst.TransferFromViewReceiveStationeriesList(brbrober.GetViewReceiveStationeriesList());
        }

        public void UpdateUnfulfillItem(WCF_UpdateUnfulfillItem uui)
        {
            ubroker.updateunfulfillitem(uui);
        }
     

        public EmployeeRequisition[] GetPenddingRequisitionList()
        {
            return ef.getPeddingRequisitionList().ToArray();
        }

        public RequisitionItem[] GetCurrentRequisition()
        {
            return ef.getCurrentRequisition();
        }

        public RequisitionItem[] GetRequisitionItemByID(string req_id)
        {
            return ef.getRequisitionItemByID(Convert.ToInt32(req_id));
        }

        public int UpdateRequisitionStatus(EmployeeRequisitionDetail reqdetail)
        {
            return ef.updateRequisitionStatus(reqdetail);
        }

        public SelfRequisition[] FindSelfRequisition(int emp_id)
        {
            return new SelfRequisition[2];
        }

        public SelfRequisition[] FindSelfRequisitionByTime(int emp_id, DateTime start, DateTime end)
        {
            return new SelfRequisition[1];
        }

        public CategoryType[] getAllCategoryType()
        {
            return null;
        }

        public CategoryDetail[] getAllCategoryDetails()
        {
            return ef.getCategoriesList().ToArray();
        }

        public CategoryDetail[] getCategoryDetailsByType(string type)
        {
            return ef.getCategoriesListByType(type).ToArray();
        }

        public int CreateRequisition(EmployeeRequisitionDetail emp, RequisitionItem[] reqitems)
        {
            return 1;
        }

        public SelfRequisition[] getSelfRequisitions(string id)
        {
            List<SelfRequisition> sl = ef.getSelfRequisitions(id);
            foreach (SelfRequisition sa in sl)
            {
                sa.Date_string = sa.Req_date.ToString("MM/dd/yyyy");
            }
            return sl.ToArray();
        }

        public int CreateRequisition(EmployeeRequisitionDetail emp)
        {
            requisition req = new requisition();
            req.dept_id = emp.Dept_id;
            req.req_emp_id = emp.Requst_emp_id;
            req.req_date = DateTime.Now;
            req.req_status = "Pending";
            return ef.makenewrequisition(req);
        }

        public int insertDetailItems(RequisitionDetailItems req)
        {
            requisitionDetail reqd = new requisitionDetail();
            reqd.req_id = req.Req_id;
            reqd.item_code = req.Item_code;
            reqd.req_quantity = req.Quantity;
            return ef.insertDetailitem(reqd);
        }

        public EmployeeRequisitionDetail getSpecificRequisition(string req_id)
        {
            return ef.getsepcificrequisiton(req_id);
        }

        public UnfulfilledItems[] getUnfulfillitems(string req_id)
        {
            return ef.getUnfulfillitems(Convert.ToInt32(req_id)).ToArray();
        }

        
        public ViewIssuedRequisiton[] GetViewRequisitionHistoryList()
        {
            return jst.TransferFromTest(ef.getIssuedRequisitionList());
        }

        public ViewIssuedRequisiton[] GetViewPendingList()
        {
            return jst.TransferFromTest(ef.getPendingList());
        }

        public ViewIssuedRequisitonDetail[] GetViewIssuedRequisitonDetail(string id)
        {
            return jst.TransferFromViewIssuedRequisitonDetail(ef.getViewIssuedRequisitonDetail(id));
        }

        public void UpdateRequisitionDetail(WCF_UpdateRequisitionDetail urd)
        {
            ef.updateRequisitionDetial(urd);
        }
        /********************** Begin Gokul *************************/
        public bool createDiscrepancy(List<DiscrepancyDetail> discrepancyDetail)
        {
            ef.createDiscrepancy(discrepancyDetail);
            return true;
        }
        /********************** End Gokul *************************/
       
    }
}
