using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Data.Abstract;
using ToDoPlanning.Entity.Concrete;
using ToDoPlanning.Entity.Dto;
using ToDoPlanning.Service.Abstract;
using ToDoPlanning.Shared.Utility.Results.Abstract;
using ToDoPlanning.Shared.Utility.Results.ComplexTypes;
using ToDoPlanning.Shared.Utility.Results.Concrete;

namespace ToDoPlanning.Service.Concrete
{
    public class ToDoTaskManager : IToDoTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoTaskManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ToDoTaskAddDto toDoTaskAddDto)
        {
            var toDoTask = _mapper.Map<ToDoTask>(toDoTaskAddDto);
            await _unitOfWork.ToDoTasks.AddAsync(toDoTask);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Added successfully");
        }

        public async Task<IResult> Delete(int toDoTaskID)
        {
            var result = await _unitOfWork.ToDoTasks.AnyAsync(a => a.ID == toDoTaskID);
            if (result)
            {
                var toDoTask = await _unitOfWork.ToDoTasks.GetAsync(a => a.ID == toDoTaskID);
                toDoTask.IsActive = false;
                await _unitOfWork.ToDoTasks.UpdateAsync(toDoTask);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Passive");
            }
            return new Result(ResultStatus.Error, "Not found ToDoTask");
        }

        public async Task<IDataResult<ToDoTaskListDto>> GetAllByActiveAndNotPlanned()
        {
            var toDoTasks = await _unitOfWork.ToDoTasks.GetAllAsync(null, a => a.IsActive && !a.isPlanned);
            if (toDoTasks.Count > -1)
            {
                return new DataResult<ToDoTaskListDto>(ResultStatus.Success, new ToDoTaskListDto
                {
                    ToDoTasks = toDoTasks.ToList(),
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ToDoTaskListDto>(ResultStatus.Error, "Active task Not Found", null);
        }

        public async Task<IDataResult<IList<ToDoTaskAddDto>>> GetAllFromProvider(ToDoProviderListDto toDoProviderListDto )
        {
            var retVal = new DataResult<IList<ToDoTaskAddDto>>(ResultStatus.Error, "Active task Not Found", null);

            var toDoTaskAddDtoList = new List<ToDoTaskAddDto>();

            if (toDoProviderListDto != null && toDoProviderListDto.ToDoProviders.Count > -1)
            {
                foreach (var toDoProvider in toDoProviderListDto.ToDoProviders)
                {
                    var client = new RestClient(toDoProvider.Url);
                    var request = new RestRequest("",Method.Get);
                    var providerResponse = await client.ExecuteAsync(request);
                    if(providerResponse.StatusCode==System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(providerResponse.Content))
                    {
                        toDoTaskAddDtoList.AddRange(JsonConvert.DeserializeObject<IList<ToDoTaskAddDto>>(providerResponse.Content));
                    }
                }

                retVal = new DataResult<IList<ToDoTaskAddDto>>(ResultStatus.Success, toDoTaskAddDtoList);

            }
            
            return retVal;
        }

        public async Task<IResult> AddAllFromProvider(IList<ToDoTaskAddDto> toDoTaskAddListDto)
        {
            #region
            foreach (var toDoTaskAddDto in toDoTaskAddListDto)
            {
                var toDoTask = _mapper.Map<ToDoTask>(toDoTaskAddDto); //Bulk and Logging
                await _unitOfWork.ToDoTasks.AddAsync(toDoTask);
                await _unitOfWork.SaveAsync();                
            }
            #endregion

            return new Result(ResultStatus.Success, "Added successfully");

        }
    }
}
