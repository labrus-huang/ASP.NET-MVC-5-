using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5FirstWeek.Models;

namespace MVC5FirstWeek.Controllers
{
    public class ReportController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: Report
        public ActionResult Index()
        {
            var result = (from c in db.客戶資料
                         //join cc in db.客戶聯絡人 on c.Id equals cc.客戶Id
                         //join b in db.客戶銀行資訊 on c.Id equals b.客戶Id
                         where c.已刪除 == false 
                         //   && (cc.已刪除 == false || cc.已刪除 == null) && (b.已刪除 == false || b.已刪除 == null)
                         select new Report1
                         {
                             客戶名稱 = c.客戶名稱,
                             客戶聯絡人數量 = c.客戶聯絡人.Count(p => (p.已刪除 == false || p.已刪除 == null)),
                             客戶銀行資訊數量 = c.客戶銀行資訊.Count(p => (p.已刪除 == false || p.已刪除 == null))
                         });

            //ViewData["ReportData"] = result.ToList();
            var report = result.ToList();

            return View(report);
        }
    }
}