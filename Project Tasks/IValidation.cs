using Microsoft.AspNetCore.Mvc;

namespace Project_Tasks
{    
        public interface IValidation
        {
        public string Validate(TaskModel Task);

        }

    //public class ValidName:IValidation
    //{
    //    public string Validate(TaskModel Task) { return ""; }
    //}


    }
