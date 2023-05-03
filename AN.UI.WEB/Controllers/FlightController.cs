using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AN.UI.WEB.Controllers
{
    public class FlightController : Controller

    {
        IServiceFlight serviceFlight;
        IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight , IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;


        }
        // GET: FlightController
        public ActionResult Index()
        {
            var flights = serviceFlight.GetAll();
            return View(flights);
        }

        public ActionResult search( string departure, string destination )
        {
            if (departure!=null)
            {
                var flights = serviceFlight.GetAll().Where(f => f.Departure.Contains(departure));
                return View("index", flights);

            }
            else 
            {
                var flights = serviceFlight.GetAll().Where(f => f.Destination.Contains(destination));
                return View("index", flights);

            }


        }
        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.Plane = new SelectList(servicePlane.GetAll(),"PlaneId","Information"); 
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection)
        {
            try
            {
                serviceFlight.Add(collection);
                serviceFlight.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var list = servicePlane.GetAll();
            ViewBag.Planes = new SelectList( list, "PlaneId","Information");
            return View(serviceFlight.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                serviceFlight.Update(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
