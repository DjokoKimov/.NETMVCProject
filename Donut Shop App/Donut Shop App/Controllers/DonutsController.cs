using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Donut_Shop_App.Models;

namespace Donut_Shop_App.Controllers
{
    public class DonutsController : Controller
    {
        private DonutsContext db = new DonutsContext();

        // GET: Donuts
        public ActionResult Index()
        {
            return View(db.donuts.ToList());
        }

        // GET: Donuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donut donut = db.donuts.Find(id);
            if (donut == null)
            {
                return HttpNotFound();
            }
            return View(donut);
        }

        // GET: Donuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Calories,Price,Description,Image")] Donut donut)
        {
            if (ModelState.IsValid)
            {
                db.donuts.Add(donut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donut);
        }

        // GET: Donuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donut donut = db.donuts.Find(id);
            if (donut == null)
            {
                return HttpNotFound();
            }
            return View(donut);
        }

        // POST: Donuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Calories,Price,Description,Image")] Donut donut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donut);
        }

        public ActionResult InsertNewClient(int id)
        {
            ClientDonut model = new ClientDonut();
            model.DonutId = id;
            model.donuts = db.donuts.Find(id);
            model.clients = db.clients.ToList();
            ViewBag.Clients = db.clients.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertNewClient(ClientDonut model)
        {
            var client = db.clients.FirstOrDefault(m => m.Id == model.ClientId);
            var donut = db.donuts.FirstOrDefault(m => m.Id == model.DonutId);
            donut.clients.Add(client);
            db.SaveChanges();
            return View("Index",db.donuts.ToList());
        }

        // GET: Donuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donut donut = db.donuts.Find(id);
            if (donut == null)
            {
                return HttpNotFound();
            }
            return View(donut);
        }

        // POST: Donuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donut donut = db.donuts.Find(id);
            db.donuts.Remove(donut);
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
