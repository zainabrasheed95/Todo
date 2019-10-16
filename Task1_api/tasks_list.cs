using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_api
{
    public class tasks_list
    {

        public int id { get; set; }

        [Required]
        [StringLength(100 , MinimumLength = 2)]
      
        public string task_name { get; set; }

        public bool is_completed { get; set; }

        public bool is_deleted { get; set; }

        public DateTime? creation_time { get; set;} = DateTime.Now;

        public DateTime? updation_time { get; set; } = DateTime.Now;

        public DateTime? deletion_time { get; set; } = DateTime.Now;

    }
}
