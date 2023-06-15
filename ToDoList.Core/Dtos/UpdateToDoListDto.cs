﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDoList.Core.Enums;

namespace ToDoList.Core.Dtos
{
    public class UpdateToDoListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
      
        public DateTime UpdateAt { get; set; }

    }
}
