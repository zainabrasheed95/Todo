using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task1_api.Controllers
{

    [Route("api/[controller]")]


    [ApiController]
    public class ListController : ControllerBase
    {


        private readonly DbClass dbcontext;

        public ListController(DbClass _dbcontext)
        {

            this.dbcontext = _dbcontext;

        }

        [HttpPost]

        public ActionResult<tasks_list> add_tasks([FromBody]tasks_list todo_tasks)
        {
            if (dbcontext.tasks.Any(a => a.task_name == todo_tasks.task_name))
            {
                return BadRequest("Task already exists....");

            }

            dbcontext.tasks.Add(todo_tasks);

            dbcontext.SaveChanges();
          
            return Ok(dbcontext.tasks.Where(a=>a.task_name == todo_tasks.task_name).Select(a => new

            {

                Id = a.id,
                Task_Name = a.task_name,
                Creation_Time= a.creation_time,
                Task_Status = a.is_deleted? "Cancelled" : a.is_completed? "Completed" : "Incomplete"


            }

            ).ToList());
        }

        
        [HttpGet]
     

        public IActionResult task_list()
        {
            if (dbcontext.tasks.Any())
            {
                
                return Ok(dbcontext.tasks.Where(a=>a.is_deleted==false).Select(a => new
                {
                    Id = a.id,

                    Task_Name = a.task_name,

                    Task_Creation_Time = a.creation_time,

                    Completion_Status = a.is_completed ? "Completed" : "Incomplete"

                }
                    ).ToList());

            }

            return BadRequest("No task exists in list....");
        }

        
        [HttpGet("getid/{id}")]
    


        public IActionResult specific_task([FromRoute] int id)

        {
            if (dbcontext.tasks.Any(b => b.id == id))
            {
                return Ok(dbcontext.tasks.Where(a => a.id == id).Select(b => new

                {

                    Id = b.id,

                    Task_Name = b.task_name,

                    Task_Creation_Time = b.creation_time,
 
                    Task_Status = b.is_deleted ? "Cancelled" : b.is_completed? "Completed" : "Incomplete"





                }).FirstOrDefault());

            }

            return BadRequest("Task not found....");

        }


        
        [HttpGet("getname/{name}")]
       
        public IActionResult get_task_name([FromRoute] string name)
        {

            if (dbcontext.tasks.Any(b => b.task_name == name))
            {
                return Ok(dbcontext.tasks.Where(a => a.task_name == name).Select(b => new

                {

                    Id = b.id,

                    Task_Name = b.task_name,

                    Task_Creation_Time = b.creation_time,

                    Task_Status = b.is_deleted ? "Cancelled" : b.is_completed ? "Completed" : "Incomplete"




                }).FirstOrDefault());

            }

            return BadRequest("Task not found....");




        }


        [HttpGet("pending")]

        public ActionResult<tasks_list> tasks_left()
        {
            return Ok(dbcontext.tasks.Where(a => a.is_completed == false && a.is_deleted == false).Select(a => new


            {

                Id = a.id,
                Task_Name = a.task_name,
                Task_Creation_Time = a.creation_time,
                Completion_Status = a.is_completed ? "Completed" : "Incomplete",
                Deletion_Status = a.is_deleted ? "Cancelled" : "Not cancelled yet"

            }).ToList()); 


        }
        
        [HttpPut("mark_completed/{id}")]

        public ActionResult<tasks_list> comp_status([FromRoute] int id)
        {

            if (dbcontext.tasks.Any(a => a.id == id && a.is_deleted == false && a.is_completed == false))

            {
                

                var up = dbcontext.tasks.Where(b => b.id == id).FirstOrDefault();

               
                    up.is_completed = true;
                    up.updation_time = DateTime.Now;

                    dbcontext.SaveChanges();

                return Ok("Completion status updated....");
            }


            else if (dbcontext.tasks.Any(a => a.id == id && a.is_deleted == true))
            {
                return BadRequest("Task has already been cancelled....");

            }

            else if (dbcontext.tasks.Any(a => a.id == id && a.is_completed == true))
            {

                return BadRequest("Status has alreday been updated....");
            }
            else if (dbcontext.tasks.Any(a => a.id != id))
            {
                return BadRequest("Task not found....");
            }


            else
                return BadRequest("Updation error occured");
        }


        [HttpPut("delete_task/{id}")]

        public ActionResult<tasks_list> del_status([FromRoute] int id)
        {

            if (dbcontext.tasks.Any(a => a.id == id && a.is_completed == false && a.is_deleted == false))
          
            {
                var up = dbcontext.tasks.Where(b => b.id == id).FirstOrDefault();

                
                    up.is_deleted = true;
                    up.deletion_time = DateTime.Now;

                    dbcontext.SaveChanges();

                return Ok("Deletion status updated....");
            }

            else if (dbcontext.tasks.Any(a => a.id == id && a.is_completed == true))
            {
                return BadRequest("Task has already been completed , can not be cancelled....");

            }

             else if (dbcontext.tasks.Any(a => a.id == id && a.is_deleted == true))
           
            {

                return BadRequest("Task has already been deleted....");
            }
            else if (dbcontext.tasks.Any(a => a.id != id))
            {
                return BadRequest("Task not found....");
            }


            else
                return BadRequest("Updation error occured");


        }


        [HttpPut("update_task/{id}")]

        public ActionResult<tasks_list> update_task([FromRoute] int id, [FromBody] tasks_list task_name)
        {
            if (dbcontext.tasks.Any(a => a.id == id))
            {
                if (dbcontext.tasks.Any(a => a.task_name == task_name.task_name))

                {

                    return BadRequest("Same task already exists....");

                }

                else
                {

                    if (dbcontext.tasks.Any(a => a.id == id && a.task_name != task_name.task_name))

                    {

                        var up = dbcontext.tasks.Where(a => a.id == id).FirstOrDefault();

                        
                            up.task_name = task_name.task_name;

                            dbcontext.SaveChanges();


                        return Ok("Task name updated....");

                    }

                  
                }

            }
                return BadRequest("Task not found....");

            
        }

     
        
        [HttpGet("get_deleted")]

        public IActionResult cancelled_task()
        {

            if (dbcontext.tasks.Any(b => b.is_deleted == true))
            {
                return Ok(dbcontext.tasks.Where(a => a.is_deleted == true).Select(b => new

                {

                    Id = b.id,

                    Task_Name = b.task_name,

                    cancellation_Status = b.is_deleted ? "Cancelled" : "Inprocess",
                 
                    Task_Deletion_Time = b.deletion_time




                }).ToList());

            }

            return BadRequest("No task Cancelled yet");
           
        }

        
         [HttpGet("get_completed")]

        public IActionResult completed_task()
        {
            if (dbcontext.tasks.Any(a => a.is_completed == true))
            {

                return Ok(dbcontext.tasks.Where(a => a.is_completed == true).Select(b => new

                {

                    Id = b.id,

                    Task_Name = b.task_name,

                    completion_Status = b.is_completed ? "Completed" : "Incomplete",

                    Task_Completion_Time = b.updation_time




                }).ToList());
            }

            return BadRequest("task not completed yet");
        }



        [HttpDelete("{id}")]

        public async Task<ActionResult<tasks_list>> del_task([FromRoute] int id)
        {
            

            var task = dbcontext.tasks.FirstOrDefault(a => a.id == id);
            if(task is null)
            {
                return BadRequest("Task not found");
            }
            if(task.is_deleted)
            {
                return Ok("Already deleted....");
            }
            task.is_deleted = true;
            task.deletion_time = DateTime.Now;
            await dbcontext.SaveChangesAsync();
            return Ok("Deleted....");
            





        }


    }
}