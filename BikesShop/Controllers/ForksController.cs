using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.Services;
using BikesShop.DAL.Models;

namespace BikesShop.Controllers
{
    public class ForksController : Controller
    {
       private readonly ForkService _forkService = new ForkService();

        // GET: Forks
        public ActionResult Index()
        {
            return View(_forkService.GetAll());
        }

        // GET: Forks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fork fork = _forkService.GetById(id);
            if (fork == null)
            {
                return HttpNotFound();
            }
            return View(fork);
        }

        // GET: Forks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ForkType,ForkBrand")] Fork fork)
        {
            if (ModelState.IsValid)
            {
                _forkService.Create(fork);
                return RedirectToAction("Index");
            }

            return View(fork);
        }

        // GET: Forks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fork fork = _forkService.GetById(id);
            if (fork == null)
            {
                return HttpNotFound();
            }
            return View(fork);
        }

        // POST: Forks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ForkType,ForkBrand")] Fork fork)
        {
            if (ModelState.IsValid)
            {
                _forkService.Update(fork);
                return RedirectToAction("Index");
            }
            return View(fork);
        }

        // GET: Forks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fork fork = _forkService.GetById(id);
            if (fork == null)
            {
                return HttpNotFound();
            }
            return View(fork);
        }

        // POST: Forks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _forkService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _forkService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
