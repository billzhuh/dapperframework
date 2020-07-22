using DapperEx;
using dapperFramewoek.Models;
using IYRSystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRSystemService;


namespace dapperFramewoek.Controllers
{
    public class OrderInfoController : Controller
    {

        IOrderInfoService orderinfoservice = new OrderInfoService();

        public ActionResult Index(int pageIndex = 1,string key="")
        {
            long pageCount = 0;
            List<OrderInfo> list = orderinfoservice.getPage(pageIndex, 10, out pageCount, m => m.OrderDes, OperationMethod.Equal,key);
            ViewBag.PageList = ComHelper.PageList(pageCount, 10, pageIndex, "/OrderInfo?pageIndex={P}");
            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderInfo orderinfo)
        {
            int id = orderinfoservice.Add(orderinfo);
            if (id > 0)
                return Content("添加成功");
            else
                return Content("添加失败");
        }


        public ActionResult Edit(int id)
        {
            OrderInfo orderinfo = orderinfoservice.GetModel(id);
            return View(orderinfo);
        }
        [HttpPost]
        public ActionResult Edit(OrderInfo orderinfo)
        {
           bool result=  orderinfoservice.Update(orderinfo);
           if (result)
               return Content("编辑成功");
           else
               return Content("编辑失败");
           
        }


        public ActionResult Details(int id=0)
        {
            OrderInfo orderinfo = orderinfoservice.GetModel(id);
            return View(orderinfo);
        }

        public ActionResult Delete(int id=0)
        {
           bool result= orderinfoservice.Delete(id);
           if (result)
               return Content("删除成功");
           else
               return Content("删除失败");
        }

    }
}
