using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VST
{
    public partial class C_VCZ_CT_PRJController : Controller
    {
        private SBO_TESTEntities1 db = new SBO_TESTEntities1();


        ///<summary>
        ///GetProjects 
        ///</summary>
        public IEnumerable<C_VCZ_CT_PRJ> GetProjects()
        {
            IEnumerable<C_VCZ_CT_PRJ> c_VCZ_CT_PRJ = db.C_VCZ_CT_PRJ.Where(t=>t.U_Status == "7").Take(200).ToList();
            return c_VCZ_CT_PRJ;
        }

        // GET: C_VCZ_CT_PRJ
        public ActionResult Index()
        {

            return View(GetProjects());
        }

        // GET: C_VCZ_CT_PRJ/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_VCZ_CT_PRJ c_VCZ_CT_PRJ = db.C_VCZ_CT_PRJ.Find(id);
            if (c_VCZ_CT_PRJ == null)
            {
                return HttpNotFound();
            }
            return View(c_VCZ_CT_PRJ);
        }

        // GET: C_VCZ_CT_PRJ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C_VCZ_CT_PRJ/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,DocEntry,Canceled,Object,LogInst,UserSign,Transfered,CreateDate,CreateTime,UpdateDate,UpdateTime,DataSource,U_Descript,U_Series,U_Type,U_CardCode,U_CardName,U_CntCode,U_Price,U_StartDat,U_EndDate,U_ActStart,U_ActEndDt,U_DelDate,U_AcptDate,U_CurSourc,U_DocCurr,U_DocRate,U_SysRate,U_Rezijni,U_BlockNPB,U_Status,U_EmpNo,U_SmlCode,U_SmlName,U_SmlDesc,U_SmlOrdN,U_SmlRev,U_SmlExp,U_FaktType,U_FaktItm,U_FinType,U_SmlVers,U_ValidFr,U_ValidTo,U_HoldRecs,U_EquipID,U_ContrID,U_PaymGrp,U_PlaRev,U_PlaRevFC,U_PlaRevSC,U_ActRev,U_ActRevFC,U_ActRevSC,U_PlaExp,U_PlaExpFC,U_PlaExpSC,U_ActExp,U_ActExpFC,U_ActExpSC,U_AttPath,U_DonePrc,U_ProbRealO,U_DonePrAR,U_MainPrj,U_GenATmpl")] C_VCZ_CT_PRJ c_VCZ_CT_PRJ)
        {
            if (ModelState.IsValid)
            {
                db.C_VCZ_CT_PRJ.Add(c_VCZ_CT_PRJ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c_VCZ_CT_PRJ);
        }

        // GET: C_VCZ_CT_PRJ/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_VCZ_CT_PRJ c_VCZ_CT_PRJ = db.C_VCZ_CT_PRJ.Find(id);
            if (c_VCZ_CT_PRJ == null)
            {
                return HttpNotFound();
            }
            return View(c_VCZ_CT_PRJ);
        }

        // POST: C_VCZ_CT_PRJ/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,DocEntry,Canceled,Object,LogInst,UserSign,Transfered,CreateDate,CreateTime,UpdateDate,UpdateTime,DataSource,U_Descript,U_Series,U_Type,U_CardCode,U_CardName,U_CntCode,U_Price,U_StartDat,U_EndDate,U_ActStart,U_ActEndDt,U_DelDate,U_AcptDate,U_CurSourc,U_DocCurr,U_DocRate,U_SysRate,U_Rezijni,U_BlockNPB,U_Status,U_EmpNo,U_SmlCode,U_SmlName,U_SmlDesc,U_SmlOrdN,U_SmlRev,U_SmlExp,U_FaktType,U_FaktItm,U_FinType,U_SmlVers,U_ValidFr,U_ValidTo,U_HoldRecs,U_EquipID,U_ContrID,U_PaymGrp,U_PlaRev,U_PlaRevFC,U_PlaRevSC,U_ActRev,U_ActRevFC,U_ActRevSC,U_PlaExp,U_PlaExpFC,U_PlaExpSC,U_ActExp,U_ActExpFC,U_ActExpSC,U_AttPath,U_DonePrc,U_ProbRealO,U_DonePrAR,U_MainPrj,U_GenATmpl")] C_VCZ_CT_PRJ c_VCZ_CT_PRJ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c_VCZ_CT_PRJ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c_VCZ_CT_PRJ);
        }

        // GET: C_VCZ_CT_PRJ/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_VCZ_CT_PRJ c_VCZ_CT_PRJ = db.C_VCZ_CT_PRJ.Find(id);
            if (c_VCZ_CT_PRJ == null)
            {
                return HttpNotFound();
            }
            return View(c_VCZ_CT_PRJ);
        }

        // POST: C_VCZ_CT_PRJ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            C_VCZ_CT_PRJ c_VCZ_CT_PRJ = db.C_VCZ_CT_PRJ.Find(id);
            db.C_VCZ_CT_PRJ.Remove(c_VCZ_CT_PRJ);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
