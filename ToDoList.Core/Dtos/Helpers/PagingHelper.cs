using ToDoList.Core.Dtos.Helpers;
using System;

namespace ToDoList.Core.Dtos
{
   public static class PagingHelper
    {
        // page current
        public static int GetSkipValue(this Pagination pagination)
        {
           return (pagination.Page - 1) * pagination.PerPage;
        }
        // all pages 
        // تقسمهم على عدد معين
        //عدد الصفحات
        public static int GetPages(this Pagination pagination , int dataCount)
        {
            return Convert.ToInt32(Math.Ceiling(dataCount / (float) pagination.PerPage));
        } 
    }
}
