using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Dto;
using ToDoPlanning.Shared.Utility.Results.Abstract;

namespace ToDoPlanning.Service.Abstract
{
    public interface IProviderService
    {
        Task<IDataResult<ToDoProviderListDto>> GetAllToDoProviderByActive();

        Task<IResult> Add(ToDoProviderAddDto toDoProviderAddDto);

        Task<IResult> Delete(int toDoProviderID);
    }
}
