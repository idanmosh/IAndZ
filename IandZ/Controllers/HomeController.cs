using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IandZ.Dal;
using IandZ.Models;

namespace IandZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PlaceOrder()// this action is called whe pressing "buy now" on products
        {
            string pid = Request.Form["pid"];
            ProductsDal dal = new ProductsDal();
            OrderDal odal = new OrderDal();
            List<Order> orders = (from x in odal.order select x).ToList<Order>();
            Products ordered = (from y in dal.products where y.ProductId.Equals(pid) select y).ToList<Products>()[0];//grabs the product that was "ordered" from the db into current variable
            Users user = (Session["signedin"] as Users);//the user who comiitted the "buy now" button
            
            if (user != null && ordered != null)
            {
                //inserting the order whith all its details to db

                odal.order.Add(new Order()
                {
                    Orderid = (orders.Count + 1).ToString(),
                    Odate = DateTime.Now.ToString(),
                    Oemail = user.UserEmail,
                    Ofname = user.FirstName,
                    Olname = user.LastName,
                    Opid = ordered.ProductId,
                    Opname = ordered.Product_name,
                    Ousername = user.UserName
                });
                try
                {
                    odal.SaveChanges();
                }
                catch (DbUpdateException)
                {
                }
                ViewBag.succeded = "order submited succesfully, our team will contact you soon";
            }
            else
            {
                ViewBag.succeded = "you must login to submit an order pls login and try again";
            }

            return ShowHomePage();
        }

        public ActionResult ShowHomePage()
        {
            return View("ShowHomePage",new ProductsVM() {
            Products_list=((new ProductsDal()).products.ToList<Products>())});
        }
        
    }
}