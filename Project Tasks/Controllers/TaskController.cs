using Microsoft.AspNetCore.Mvc;
using Project_Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<TaskModel>> GetTaskDetails()
    {
        return JsonFileHelper.ReadFromJsonFile<TaskModel>();
    }


    [HttpGet("{Name}")]
    public ActionResult<TaskModel> GetTask(string Name)
    {
        var TaskDetails = JsonFileHelper.ReadFromJsonFile<TaskModel>();
        var TaskName = TaskDetails.FirstOrDefault(p => p.Name.ToUpper() == Name.ToUpper());
        if (TaskName == null)
        {
            return NotFound();
        }
        return TaskName;
    }


    [HttpPost]
    public ActionResult<TaskModel> CreateTask([FromBody] TaskModel Task)
 
    {
        var TaskDetails = JsonFileHelper.ReadFromJsonFile<TaskModel>();

        if (TaskDetails.Count() > 0) { TaskDetails.Add(Task); }
        
            JsonFileHelper.WriteToJsonFile(TaskDetails);


         return CreatedAtAction(nameof(CreateTask), new { Priority = Task.Priority }, Task);
       

    }

    [HttpPut]
    public ActionResult UpdateTask([FromBody] TaskModel updatedPerson)                                                                                                                                                                                                                                                                                                                                                                       
    {
        var TaskDetails = JsonFileHelper.ReadFromJsonFile<TaskModel>();
        var TaskName = TaskDetails.Where(u => u.Name == updatedPerson.Name).FirstOrDefault();
        //var TaskName = TaskDetails.FirstOrDefault(TaskDetails => TaskDetails.Name.ToUpper() == updatedPerson.Name.ToUpper());

        if (TaskName == null)
        {
            return NotFound();
        }

        TaskName.Priority = updatedPerson.Priority;
        TaskName.Status = updatedPerson.Status;
        JsonFileHelper.WriteToJsonFile(TaskDetails);

        return NoContent();
    }

    [HttpDelete("{Name}")]
    public ActionResult DeleteTask(string Name)
    {
        var TaskDetails = JsonFileHelper.ReadFromJsonFile<TaskModel>();
        var TaskName = TaskDetails.Where(u => u.Name == Name).FirstOrDefault();

        if (TaskName == null)
        {
            return NotFound();
        }

        TaskDetails.Remove(TaskName);
        JsonFileHelper.WriteToJsonFile(TaskDetails);

        return NoContent();
    }
}