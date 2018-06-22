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
    public class HomeController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        public ActionResult Index()
        {
            var con = new SqlConnection("Data Source=DESKTOP-I5C9AA0\\SQLEXPRESS2008;Initial Catalog=InventarioUXBD;Integrated Security=True");
            con.Open();
            //var command = new SqlCommand("SELECT ID FROM BANCOS WHERE NOMBRE='SANTANDER'", con);
            var command = new SqlCommand("SELECT SUM(SALDO) FROM BANCOS", con);
            object result = command.ExecuteScalar(); 
            //int wea = (int)(result);
            ViewBag.Saldo = result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}