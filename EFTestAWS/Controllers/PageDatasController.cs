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
    public class PageDatasController : Controller
    {
        private ChoiceModel db = new ChoiceModel();

        // GET: PageDatas
        public ActionResult Index()
        {
            return View(db.PageData.ToList());
        }

        // GET: PageDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageData pageData = db.PageData.Find(id);
            if (pageData == null)
            {
                return HttpNotFound();
            }
            return View(pageData);
        }

        // GET: PageDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PageDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,PageTitle,PageDescription,Ending,Result,Victory")] PageData pageData)
        {
            if (ModelState.IsValid)
            {
                db.PageData.Add(pageData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageData);
        }

        // GET: PageDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageData pageData = db.PageData.Find(id);
            if (pageData == null)
            {
                return HttpNotFound();
            }
            return View(pageData);
        }

        // POST: PageDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,PageTitle,PageDescription,Ending,Result,Victory")] PageData pageData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageData);
        }

        // GET: PageDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageData pageData = db.PageData.Find(id);
            if (pageData == null)
            {
                return HttpNotFound();
            }
            return View(pageData);
        }

        // POST: PageDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageData pageData = db.PageData.Find(id);
            db.PageData.Remove(pageData);
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
