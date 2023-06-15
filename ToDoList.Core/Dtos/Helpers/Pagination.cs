using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Dtos.Helpers
{
   public class Pagination
    {
        public int PerPage { get; set; } //كم رو في الصفحة الواحدة
                                         //مثلاً عشر صفحات في الصفحة
        public int Page { get; set; } // الصفحة الحالية
        public int Pages { get; set; } // عدد الصفحات الإجمالي 
        public int Total { get; set; } // مجموع البيانات اللي الصفحات
        

    }
}
