using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Dto;
using ToDoPlanning.Shared.Utility.Results.Abstract;

namespace ToDoPlanning.Service.Abstract
{
    public interface IDeveloperService
    {
        Task<IDataResult<DeveloperListDto>> GetAllDeveloperByActive();

        Task<IResult> Add(DeveloperAddDto developerAddDto);

        Task<IResult> Delete(int developerID);
    }
}
