using System.Xml.Linq;

namespace Project_Tasks
{
    public class ValidateName : IValidation
    {
        string IValidation.Validate(TaskModel Task)
        {

            var TaskDetails = JsonFileHelper.ReadFromJsonFile<TaskModel>();
            var TaskPriority = TaskDetails.FirstOrDefault(p => p.Name.ToUpper() == Task.Name.ToUpper());
            if (TaskPriority == null)
            {
                return "";
            }
            
            return "yes";

        }
    }


}
