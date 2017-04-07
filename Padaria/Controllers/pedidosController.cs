using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estagio.Contexto;
using Padaria.Models;

namespace Padaria.Controllers
{
    public class pedidosController : Controller
    {
        private Context db = new Context();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pedido([Bind(Include = "Nome,Quantidade,Produto")] pedidos pedido)
        {

            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
            }

            if (pedido.Produto.Equals("coxinha", StringComparison.CurrentCultureIgnoreCase))
            {
                ViewData["valor"] = ("R$" + pedido.Quantidade * 3);
            }
            else if (pedido.Produto.Equals("Kibe", StringComparison.CurrentCultureIgnoreCase))
            {
                ViewData["valor"] = ("R$" + pedido.Quantidade * 2.5);
            }
            else if (pedido.Produto.Equals("Esfiha", StringComparison.CurrentCultureIgnoreCase))
            {
                ViewData["valor"] = ("R$" + pedido.Quantidade * 3.5);
            }
            else
            {
                ViewData["valor"] = ("R$" + pedido.Quantidade * 4);
            }



            ViewData["nome"] = pedido.Nome;
            ViewData["quantidade"] = pedido.Quantidade;
            ViewData["produto"] = pedido.Produto;



            return View();
        }

        public ActionResult Lista()
        {
            return View(db.Pedidos.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Quantidade,Produto")] pedidos pedidos)
        {
            if (string.IsNullOrEmpty(pedidos.Nome))
            {
                ModelState.AddModelError("", "Preencha todos os campos!");
            }

            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedidos);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pedidos pedidos = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedidos);
            db.SaveChanges();
            return RedirectToAction("Lista");
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
