using CRUDMVC.DataAccessLayer;
using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRUDMVC.Controllers
{
    public class CustomerController : Controller
    {
        //    
        // GET: /Customer/   
        //[Route("api/[controller]")]
        [HttpGet]
        public IActionResult Customer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {

            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            //if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccess objDB = new DataAccess();
                string result = objDB.InsertData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("ShowAllCustomerDetails");
            }

            //else
            //{
            //    ModelState.AddModelError("", "Error in saving data");
            //    return View();
            //}
        }

        [HttpGet]
        public ActionResult Customerdetails()
        {
            Customer objCustomer = new Customer();
            DataAccess objDB = new DataAccess(); //calling class DBdata    
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {
            //Customer objCustomer = new Customer();    
            //DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            //objCustomer.ShowallCustomer = objDB.Selectalldata();    
            //return View(objCustomer);    
            Customer objCustomer = new Customer();
            DataAccess objDB = new DataAccess(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccess objDB = new DataAccess(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccess objDB = new DataAccess(); //calling class DBdata    
                string result = objDB.UpdateData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                //return View();    
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccess objDB = new DataAccess();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
                                //return View();    
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}


