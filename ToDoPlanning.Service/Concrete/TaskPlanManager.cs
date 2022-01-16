using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Data.Abstract;
using ToDoPlanning.Entity.Dto;
using ToDoPlanning.Service.Abstract;
using ToDoPlanning.Shared.Utility.Results.Abstract;
using System.Linq;
using ToDoPlanning.Entity.Concrete;
using ToDoPlanning.Shared.Utility.Results.Concrete;
using ToDoPlanning.Shared.Utility.Results.ComplexTypes;

namespace ToDoPlanning.Service.Concrete
{
    public class TaskPlanManager : ITaskPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskPlanManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IResult> Add(TaskPlanAddDto taskPlanAddDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<TaskPlanListDto>> CreatePlan(ToDoTaskListDto toDoTaskListDto, DeveloperListDto developerListDto)
        {
            if (toDoTaskListDto.ToDoTasks.Count > 0 && developerListDto.Developers.Count > 0)
            {
                var taskPlanDtoList = new TaskPlanListDto();
                taskPlanDtoList.TaskPlan = new TaskPlan();
                taskPlanDtoList.TaskPlan.ToDoTasks = new List<ToDoTask>();

                developerListDto.Developers.ForEach(developer => developer.Remaining = developer.WeeklyEfficiency);

                toDoTaskListDto.ToDoTasks.ForEach(task =>
                {
                    var availableDev = developerListDto.Developers.OrderByDescending(x => x.Remaining).OrderBy(x => x.CalendarWeek).Take(1).First();
                    var toDoTask = task;
                    toDoTask.Developer = availableDev;

                    taskPlanDtoList.TaskPlan.TotalWeek = taskPlanDtoList.TaskPlan.TotalWeek + availableDev.CalendarWeek;

                    taskPlanDtoList.TaskPlan.TotalHour = taskPlanDtoList.TaskPlan.TotalHour + toDoTask.TaskCost;

                    taskPlanDtoList.TaskPlan.ToDoTasks.Add(toDoTask);

                    if (task.TaskCost < availableDev.Remaining)
                    {
                        availableDev.Remaining -= task.TaskCost;
                    }
                    else
                    {
                        int remainingCost = task.TaskCost - availableDev.Remaining;
                        availableDev.CalendarWeek += 1;
                        availableDev.Remaining = availableDev.WeeklyEfficiency - remainingCost;
                    }
                });

                return new DataResult<TaskPlanListDto>(ResultStatus.Success, new TaskPlanListDto
                {
                     TaskPlan= taskPlanDtoList.TaskPlan,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<TaskPlanListDto>(ResultStatus.Error, "Could not create plan", null);
            }
        }

        public Task<IResult> Delete(int taskPlanID)
        {
            throw new NotImplementedException();
        }

        
    }
}
