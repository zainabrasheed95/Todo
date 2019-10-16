using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Task1_api
{
    public class Todo_list
    {
        public int id { get; set; }
        public string todo_title { get; set; }

        public bool is_deleted { get; set; }

        public bool is_completed { get; set; }

        // here ? shows that in datetime allow null is allowed
        public DateTime? DandT { get; set; } = DateTime.Now;


    }
}
