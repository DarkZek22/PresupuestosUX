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
    public class BANCOSController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: BANCOS
        public ActionResult Index()
        {
            return View(db.BANCOS.ToList());
        }

        public ActionResult AgregarSaldo()
        {
            ViewBag.ID = new SelectList(db.BANCOS, "ID", "NOMBRE");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarSaldo([Bind(Include = "ID,SALDO")] BANCOS bANCOS)
        {
            var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
            con.Open();
            int id = bANCOS.ID;
            double saldo = bANCOS.SALDO;

            var command = new SqlCommand("UPDATE BANCOS SET SALDO = "+saldo+" WHERE ID=" + id + "", con);
            command.ExecuteNonQuery();

            string fecha = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "";

            var command2 = new SqlCommand("INSERT INTO BANCO_SALDOS (SALDO, FECHA_SALDO, ID_BANCO) VALUES ("+saldo+", "+fecha+","+id+")", con);
            command2.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
        // GET: BANCOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BANCOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,CUENTA,SALDO")] BANCOS bANCOS)
        {
            if (ModelState.IsValid)
            {
                db.BANCOS.Add(bANCOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bANCOS);
        }

        // GET: BANCOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANCOS bANCOS = db.BANCOS.Find(id);
            if (bANCOS == null)
            {
                return HttpNotFound();
            }
            return View(bANCOS);
        }

        // POST: BANCOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANCOS bANCOS = db.BANCOS.Find(id);
            db.BANCOS.Remove(bANCOS);
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
