using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresupuestosUX.Models;

namespace PresupuestosUX.Controllers
{
    public class PagoFacturaController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        // GET: PagoFactura
        public ActionResult Index()
        {
            ViewBag.ProveedorID = new SelectList(db.PROVEEDORES, "ID", "NOMBRE");
            ViewBag.ID = new SelectList(db.BANCOS, "ID", "NOMBRE");
            return View();
        }

        public ActionResult SelectFactura()
        {
            ViewBag.ProveedorID = new SelectList(db.PROVEEDORES, "ID", "NOMBRE");
            return View();
        }


        public ActionResult BuscarFactura(FormCollection fc)
        {
            ViewBag.ProveedorID = new SelectList(db.PROVEEDORES, "ID", "NOMBRE");
            ViewBag.ID = new SelectList(db.BANCOS, "ID", "NOMBRE");
            string[] cantidad = fc.GetValues("FacturaID");
            int FID = Int32.Parse(cantidad[0]);
            return RedirectToAction("Agregar", new { id = FID });

        }

        public ActionResult Agregar(int id)
        {
            ViewBag.ProveedorID = new SelectList(db.PROVEEDORES, "ID", "NOMBRE");
            ViewBag.ID = new SelectList(db.BANCOS, "ID", "NOMBRE");
            FACTURA_PROVEEDOR f = new FACTURA_PROVEEDOR();
            PROVEEDORES p = new PROVEEDORES();
            PAGO_PROVEEDOR pag = new PAGO_PROVEEDOR();
            f = db.FACTURA_PROVEEDOR.Find(id);

            var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
            con.Open();

            var command = new SqlCommand("SELECT SALDO FROM PAGO_PROVEEDOR WHERE ID_FACTURA=" + id + "", con);
            int wea = (int)(command.ExecuteScalar());

            var command2 = new SqlCommand("SELECT IDESTATUS FROM PAGO_PROVEEDOR WHERE ID_FACTURA=" + id + "", con);
            int wea2 = (int)(command2.ExecuteScalar());

            List<FACTURA_PROVEEDOR> cart = new List<FACTURA_PROVEEDOR>();
            cart.Add(f);
            Session["Factura"] = cart;
            Session["SaldoRestante"] = wea;
            ViewBag.FacturaEncontrada = true;
            ViewBag.Folio = f.FOLIO;
            ViewBag.DescFactura = f.DESC_FACTURA;
            ViewBag.Saldo = f.SALDO;
            ViewBag.SaldoRestante = wea;
            ViewBag.Fecha = f.FECHA;
            if (wea2 == 1)
            {
                ViewBag.Estatus = "Pagado";
            }
            if (wea2 == 2)
            {
                ViewBag.Estatus = "Sin pagar";
            }
            if (wea2 == 3)
            {
                ViewBag.Estatus = "En proceso de pago";
            }

            p = db.PROVEEDORES.Find(f.IDPROVEEDOR);
            ViewBag.Proveedor = p.NOMBRE;
            return View("Index");
        }

        public ActionResult PagoFactura(FormCollection fc)
        {
            ViewBag.ProveedorID = new SelectList(db.PROVEEDORES, "ID", "NOMBRE");
            ViewBag.ID = new SelectList(db.BANCOS, "ID", "NOMBRE");
            List<FACTURA_PROVEEDOR> cart = (List<FACTURA_PROVEEDOR>)Session["Factura"];
            int id = (int)(cart[0].ID);
            int saldofactura = (int)(Session["SaldoRestante"]);
            string[] cantidad = fc.GetValues("PagoFactura");
            string[] idbanco = fc.GetValues("ID");
            string[] fecha = fc.GetValues("FECHA");
            int idb = Convert.ToInt32(idbanco[0]);
            int saldopagado = Convert.ToInt32(cantidad[0]);
            string fecha_pago = fecha[0].ToString();
            int nuevosaldo = saldofactura - saldopagado;

            var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
            con.Open();


            if (nuevosaldo == 0)
            {
                var command = new SqlCommand("UPDATE PAGO_PROVEEDOR SET SALDO =" + nuevosaldo + ", IDESTATUS=1 WHERE ID_FACTURA=" + id + "", con);
                command.ExecuteNonQuery();

                var command2 = new SqlCommand("INSERT INTO FACTURA_RECIBO_PAGO (MONTO_PAGO, MONTO_RESTANTE, NUMERO_PAGO, ID_FACTURA, ID_BANCO, FECHA_PAGO) VALUES ("+saldopagado+","+nuevosaldo+",1,"+id+","+idb+","+fecha_pago+")", con);
                command2.ExecuteNonQuery();
            }
            if (nuevosaldo > 0)
            {
                var command3 = new SqlCommand("UPDATE PAGO_PROVEEDOR SET SALDO =" + nuevosaldo + ", IDESTATUS=3 WHERE ID_FACTURA=" + id + "", con);
                command3.ExecuteNonQuery();

                var command4 = new SqlCommand("INSERT INTO FACTURA_RECIBO_PAGO (MONTO_PAGO, MONTO_RESTANTE, NUMERO_PAGO, ID_FACTURA, ID_BANCO, FECHA_PAGO) VALUES (" + saldopagado + "," + nuevosaldo + ",1," + id + "," + idb + "," + fecha_pago + ")", con);
                command4.ExecuteNonQuery();
            }
            var command5 = new SqlCommand("SELECT SALDO FROM BANCOS WHERE ID=" + idb + "", con);
            double saldobanco = (double)(command5.ExecuteScalar());
            double nuevosaldobanco = saldobanco - (double)(saldopagado);

            var command6 = new SqlCommand("UPDATE BANCOS SET SALDO =" + nuevosaldobanco + " WHERE ID=" + idb + "", con);
            command6.ExecuteNonQuery();

            return View("Index");
        }

        public JsonResult GetStateById(int ProveedorID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<FACTURA_PROVEEDOR> FacturaList = db.FACTURA_PROVEEDOR.Where(x => x.IDPROVEEDOR == ProveedorID).ToList();
            return Json(FacturaList, JsonRequestBehavior.AllowGet);
        }
    }
}