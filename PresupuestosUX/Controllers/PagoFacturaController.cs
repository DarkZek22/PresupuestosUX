using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresupuestosUX.Controllers
{
    public class PagoFacturaController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        // GET: PagoFactura
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult SelectFactura()
        {
            return View();
        }

        public ActionResult BuscarFactura(FormCollection fc)
        {
            var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
            con.Open();
            string[] cantidad = fc.GetValues("BuscarFactura");
            var command = new SqlCommand("SELECT ID FROM FACTURA_PROVEEDOR WHERE FOLIO='" + cantidad[0] + "'", con);

            try
            {
                int id = (int)(command.ExecuteScalar());
                return RedirectToAction("Agregar", new { id = id });
            }
            catch
            {
                ViewBag.Error = true;
                return View("Index");
            }
        }

        public ActionResult Agregar(int id)
        {
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
            List<FACTURA_PROVEEDOR> cart = (List<FACTURA_PROVEEDOR>)Session["Factura"];
            int id = (int)(cart[0].ID);
            int saldofactura = (int)(Session["SaldoRestante"]);
            string[] cantidad = fc.GetValues("PagoFactura");
            int saldopagado = Convert.ToInt32(cantidad[0]);
            int nuevosaldo = saldofactura - saldopagado;

            var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
            con.Open();

            if (nuevosaldo==0)
            {
                var command = new SqlCommand("UPDATE PAGO_PROVEEDOR SET SALDO =" + nuevosaldo + ", IDESTATUS=1 WHERE ID_FACTURA="+id+"", con);
                command.ExecuteNonQuery();
            }
            if (nuevosaldo>0)
            {
                var command = new SqlCommand("UPDATE PAGO_PROVEEDOR SET SALDO =" + nuevosaldo + ", IDESTATUS=3 WHERE ID_FACTURA=" + id + "", con);
                command.ExecuteNonQuery();
            }
            

            return View("Index");
        }
    }
}