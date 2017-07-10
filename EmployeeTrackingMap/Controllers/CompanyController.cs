using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeTrackingMap.Models;
using PagedList;
using EmployeeTrackingMap.Models.ViewModels;

namespace EmployeeTrackingMap.Controllers
{
    public class CompanyController : Controller
    {
        private EmployeeTrackingMapEntities1 db = new EmployeeTrackingMapEntities1();

        // GET: Company
        public ActionResult Index(int? page)
        {
            List<CompanyViewModel> com = new List <CompanyViewModel>();

            var items = (from i in db.Companies
                         select new { i.Id, i.Active, i.Address, i.City, i.Country, i.CountryCode, i.FullCompanyName,
                             i.Latitude, i.Longitude, i.LocationId, i.Name}).ToList();

            foreach (var i in items)
            {
                CompanyViewModel company = new CompanyViewModel();

                company.Id = i.Id;
                company.Name = i.Name;
                company.Active = i.Active;
                company.Address = i.Address;
                company.City = i.City;
                company.Country = i.Country;
                company.CountryCode = i.CountryCode;
                company.FullCompanyName = i.FullCompanyName;
                company.Latitude = Convert.ToDecimal(i.Latitude);
                company.Longitude = Convert.ToDecimal(i.Longitude);
                company.LocationId = Convert.ToInt32(i.LocationId);

                com.Add(company);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(com.ToList().ToPagedList(pageNumber, pageSize));
            //return View(db.Companies.ToList().ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int? id, CompanyViewModel Vm)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = db.Companies.Find(id);

            if (company == null)
             {
                return HttpNotFound();
             }

            //Vm.Id = company.Id;
            Vm.Name = company.Name;
            Vm.Active = company.Active;
            Vm.Address = company.Address;
            Vm.City = company.City;
            Vm.Country = company.Country;
            Vm.CountryCode = company.CountryCode;
            Vm.FullCompanyName = company.FullCompanyName;
            Vm.Latitude = Convert.ToDecimal(company.Latitude);
            Vm.Longitude = Convert.ToDecimal(company.Longitude);
        
            return View(Vm);
        }


        // GET: Company/Create
        public ActionResult Create()
        {
            return View(new CompanyViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                Company co = new Company();

                co.Id = company.Id;
                co.Name = company.Name;
                co.Active = company.Active;
                co.Address = company.Address;
                co.City = company.City;
                co.Country = company.Country;
                co.CountryCode = company.CountryCode;
                co.FullCompanyName = company.FullCompanyName;
                co.Latitude = Convert.ToDecimal(company.Latitude);
                co.LocationId = Convert.ToInt32(company.LocationId);
                co.Longitude = Convert.ToDecimal(company.Longitude);

                db.Companies.Add(co);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id, CompanyViewModel Vm)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Company company = db.Companies.Find(id);

                Vm.Id = company.Id;
                Vm.Name = company.Name;
                Vm.Active = company.Active;
                Vm.Address = company.Address;
                Vm.City = company.City;
                Vm.Country = company.Country;
                Vm.CountryCode = company.CountryCode;
                Vm.FullCompanyName = company.FullCompanyName;
                Vm.Latitude = Convert.ToDecimal(company.Latitude);
                Vm.LocationId = Convert.ToInt32(company.LocationId);
                Vm.Longitude = Convert.ToDecimal(company.Longitude);

            if (Vm == null)
            {
                return HttpNotFound();
            }

            return View(Vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Company com = new Company();

                com.Id = vm.Id;
                com.Active = vm.Active;
                com.Address = vm.Address;
                com.City = vm.City;
                com.Country = vm.Country;
                com.CountryCode = vm.CountryCode;
                com.FullCompanyName = vm.FullCompanyName;
                com.Latitude = vm.Latitude;
                com.LocationId = vm.LocationId;
                com.Longitude = vm.Longitude;
                com.Name = vm.Name;

                db.Entry(com).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }


        // GET: Company/Delete/5
        public ActionResult Delete(int? id, CompanyViewModel Vm)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = db.Companies.Find(id);

            Vm.Id = company.Id;
            Vm.Name = company.Name;
            Vm.Active = company.Active;
            Vm.Address = company.Address;
            Vm.City = company.City;
            Vm.Country = company.Country;
            Vm.CountryCode = company.CountryCode;
            Vm.FullCompanyName = company.FullCompanyName;
            Vm.Latitude = Convert.ToDecimal(company.Latitude);
            Vm.LocationId = Convert.ToInt32(company.LocationId);
            Vm.Longitude = Convert.ToDecimal(company.Longitude);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(Vm);
        }

        //POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
