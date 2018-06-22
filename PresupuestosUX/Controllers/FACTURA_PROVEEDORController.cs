using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PresupuestosUX.Models;

namespace PresupuestosUX.Controllers
{
    public class FACTURA_PROVEEDORController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: FACTURA_PROVEEDOR
        public ActionResult Index()
        {
            var fACTURA_PROVEEDOR = db.FACTURA_PROVEEDOR.Include(f => f.PROVEEDORES);
            return View(fACTURA_PROVEEDOR.ToList());
        }

        // GET: FACTURA_PROVEEDOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA_PROVEEDOR fACTURA_PROVEEDOR = db.FACTURA_PROVEEDOR.Find(id);
            if (fACTURA_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA_PROVEEDOR);
        }

        // GET: FACTURA_PROVEEDOR/Create
        public ActionResult Create()
        {
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDORES, "ID", "NOMBRE");
            return View();
        }

        // POST: FACTURA_PROVEEDOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESC_FACTURA,SALDO,FOLIO,FECHA,IDPROVEEDOR")] FACTURA_PROVEEDOR fACTURA_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.FACTURA_PROVEEDOR.Add(fACTURA_PROVEEDOR);
                db.SaveChanges();

                var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
                con.Open();
                string fecha = ""+DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year+"";
                var command = new SqlCommand("INSERT INTO PAGO_PROVEEDOR (SALDO, FECHA_PAGO, IDESTATUS, IDPRESUPUESTOMENSUAL,ID_FACTURA) VALUES ("+fACTURA_PROVEEDOR.SALDO+","+fecha+",2,2,"+fACTURA_PROVEEDOR.ID+")", con);
                command.ExecuteNonQuery();
                return RedirectToAction("Index");
            }

            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDORES, "ID", "NOMBRE", fACTURA_PROVEEDOR.IDPROVEEDOR);
            return View(fACTURA_PROVEEDOR);
        }

        // GET: FACTURA_PROVEEDOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA_PROVEEDOR fACTURA_PROVEEDOR = db.FACTURA_PROVEEDOR.Find(id);
            if (fACTURA_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDORES, "ID", "NOMBRE", fACTURA_PROVEEDOR.IDPROVEEDOR);
            return View(fACTURA_PROVEEDOR);
        }

        // POST: FACTURA_PROVEEDOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESC_FACTURA,SALDO,FOLIO,IDPROVEEDOR")] FACTURA_PROVEEDOR fACTURA_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA_PROVEEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDORES, "ID", "NOMBRE", fACTURA_PROVEEDOR.IDPROVEEDOR);
            return View(fACTURA_PROVEEDOR);
        }

        // GET: FACTURA_PROVEEDOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA_PROVEEDOR fACTURA_PROVEEDOR = db.FACTURA_PROVEEDOR.Find(id);
            if (fACTURA_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA_PROVEEDOR);
        }

        // POST: FACTURA_PROVEEDOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACTURA_PROVEEDOR fACTURA_PROVEEDOR = db.FACTURA_PROVEEDOR.Find(id);
            db.FACTURA_PROVEEDOR.Remove(fACTURA_PROVEEDOR);
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
