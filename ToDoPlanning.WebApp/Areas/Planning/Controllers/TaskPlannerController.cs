using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDoPlanning.Service.Abstract;
using ToDoPlanning.Shared.Utility.Results.ComplexTypes;

namespace ToDoPlanning.WebApp.Areas.Planning.Controllers
{
    [Area("Planning")]
    public class TaskPlannerController : Controller
    {
        private readonly ITaskPlanService _taskPlanService;
        private readonly IDeveloperService _developerService;
        private readonly IToDoTaskService _toDoTaskService;

        public TaskPlannerController(ITaskPlanService taskPlanService, IDeveloperService developerService, IToDoTaskService toDoTaskService)
        {
            _taskPlanService = taskPlanService;
            _developerService = developerService;
            _toDoTaskService = toDoTaskService;
        }

        public async Task<IActionResult> Index()
        {
            var toDoTaskListResult =  _toDoTaskService.GetAllByActiveAndNotPlanned();
            if(toDoTaskListResult.Result.ResultStatus==ResultStatus.Success && toDoTaskListResult.Result.Data.ToDoTasks.Count >0)
            {
                var developerListResult = _developerService.GetAllDeveloperByActive();
                if (developerListResult.Result.ResultStatus == ResultStatus.Success && developerListResult.Result.Data.Developers.Count > 0)
                {
                    var result = await _taskPlanService.CreatePlan(toDoTaskListResult.Result.Data, developerListResult.Result.Data);
                    return View(result.Data);
                }
            }
           
            return View();
        }

        public async Task<JsonResult> GetAllTaskPlan()
        {

            var toDoTaskListResult = _toDoTaskService.GetAllByActiveAndNotPlanned();
            if (toDoTaskListResult.Result.ResultStatus == ResultStatus.Success && toDoTaskListResult.Result.Data.ToDoTasks.Count > 0)
            {
                var developerListResult = _developerService.GetAllDeveloperByActive();
                if (developerListResult.Result.ResultStatus == ResultStatus.Success && developerListResult.Result.Data.Developers.Count > 0)
                {
                    var result = await _taskPlanService.CreatePlan(toDoTaskListResult.Result.Data, developerListResult.Result.Data);
                    var taskPlans = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    });
                    return Json(taskPlans);
                }
            }

            return Json(null);
        }
    }
}
