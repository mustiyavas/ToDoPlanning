using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Dto;
using ToDoPlanning.Shared.Utility.Results.Abstract;

namespace ToDoPlanning.Service.Abstract
{
    public interface IToDoTaskService
    {
        Task<IDataResult<ToDoTaskListDto>> GetAllByActiveAndNotPlanned();

        Task<IResult> Add(ToDoTaskAddDto ToDoTaskAddDto);

        Task<IResult> Delete(int toDoTaskID);

        Task<IDataResult<IList<ToDoTaskAddDto>>> GetAllFromProvider(ToDoProviderListDto toDoProviderListDto);

        Task<IResult> AddAllFromProvider(IList<ToDoTaskAddDto> toDoTaskAddListDto);
    }
}
