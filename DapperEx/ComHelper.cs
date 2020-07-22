using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEx
{
   public  class ComHelper
    {
       #region 页码显示方法
       public static string PageList(long PageCount, long Pagesize, int PageIndex, string links)
       {
           string Pagenum = "";
           long page_p = 1;
           if (PageCount % Pagesize == 0)
           {
               page_p = PageCount / Pagesize;
           }
           else
           {
               page_p = (PageCount / Pagesize) + 1;
           }
           Pagenum += "<ul ><li  >共" + PageCount + "条记录/" + page_p + "页</li>";

           if (PageIndex > 1) { Pagenum += "<li><a href=\"" + links.Replace("{P}", "1") + "\">首页</a></li><li><a href=\"" + links.Replace("{P}", Convert.ToString(PageIndex - 1)) + "\">上一页</a></li>"; }
           long s = 1;
           long t = 5;
           long e = t;
           if (page_p < t) { e = page_p; }
           if (PageIndex > t - 1)
           {
               s = PageIndex - t + 1;
               e = PageIndex + t;
               if (PageIndex + t > page_p) { e = page_p; }
           }
           string pthis = null;
           for (long i = s; i <= e; i++)
           {
               if (PageIndex == i) { pthis = " id=\"this\""; } else { pthis = ""; }
               Pagenum += "<li" + pthis + "><a href=\"" + links.Replace("{P}", Convert.ToString(i)) + "\">" + i + "</a></li>";

           }

           if (PageIndex < page_p) { Pagenum += "<li><a href=\"" + links.Replace("{P}", Convert.ToString(PageIndex + 1)) + "\">下一页</a></li><li><a href=\"" + links.Replace("{P}", Convert.ToString(page_p)) + "\">最后一页</a></li>"; }

           Pagenum += "</ul>";

           return Pagenum;
       }
       #endregion
    }
}
