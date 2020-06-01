using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFTestAWS.Models;

namespace EFTestAWS.Controllers
{
    public class ButtonDatasController : Controller
    {
        private ChoiceModel db = new ChoiceModel();

        // GET: ButtonDatas
        public ActionResult Index()
        {
            var buttonData = db.ButtonData.Include(b => b.PageData1);
            return View(buttonData.ToList());
        }

        // GET: ButtonDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ButtonData buttonData = db.ButtonData.Find(id);
            if (buttonData == null)
            {
                return HttpNotFound();
            }
            return View(buttonData);
        }

        // GET: ButtonDatas/Create
        public ActionResult Create()
        {
            ViewBag.PageData = new SelectList(db.PageData, "PageID", "PageTitle");
            return View();
        }

        // POST: ButtonDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ButtonID,ButtonDescription,ButtonDestinationPage,PageData")] ButtonData buttonData)
        {
            if (ModelState.IsValid)
            {
                db.ButtonData.Add(buttonData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageData = new SelectList(db.PageData, "PageID", "PageTitle", buttonData.PageData);
            return View(buttonData);
        }

        // GET: ButtonDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ButtonData buttonData = db.ButtonData.Find(id);
            if (buttonData == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageData = new SelectList(db.PageData, "PageID", "PageTitle", buttonData.PageData);
            return View(buttonData);
        }

        // POST: ButtonDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ButtonID,ButtonDescription,ButtonDestinationPage,PageData")] ButtonData buttonData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buttonData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageData = new SelectList(db.PageData, "PageID", "PageTitle", buttonData.PageData);
            return View(buttonData);
        }

        // GET: ButtonDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ButtonData buttonData = db.ButtonData.Find(id);
            if (buttonData == null)
            {
                return HttpNotFound();
            }
            return View(buttonData);
        }

        // POST: ButtonDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ButtonData buttonData = db.ButtonData.Find(id);
            db.ButtonData.Remove(buttonData);
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
