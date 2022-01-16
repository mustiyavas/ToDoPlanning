using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Dto;
using ToDoPlanning.Shared.Utility.Results.Abstract;

namespace ToDoPlanning.Service.Abstract
{
    public interface ITaskPlanService
    {
        Task<IDataResult<TaskPlanListDto>> CreatePlan(ToDoTaskListDto toDoTaskListDto, DeveloperListDto developerListDto);

        Task<IResult> Add(TaskPlanAddDto taskPlanAddDto);

        Task<IResult> Delete(int taskPlanID);
    }
}
