using AutoMapper;
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
    public class ProviderManager : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ToDoProviderListDto>> GetAllToDoProviderByActive()
        {
            var toDoProviders =  await _unitOfWork.ToDoProviders.GetAllAsync(null, a => a.IsActive);
            if (toDoProviders.Count > -1)
            {
                return new DataResult<ToDoProviderListDto>(ResultStatus.Success, new ToDoProviderListDto
                {
                    ToDoProviders = toDoProviders,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ToDoProviderListDto>(ResultStatus.Error, "Active provider Not Found", null);
        }

        public async Task<IResult> Add(ToDoProviderAddDto toDoProviderAddDto)
        {
            var toDoProvider = _mapper.Map<ToDoProvider>(toDoProviderAddDto);
            await _unitOfWork.ToDoProviders.AddAsync(toDoProvider);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{toDoProviderAddDto.Name} added successfully");
        }

        public async Task<IResult> Delete(int toDoProviderID)
        {
            var result = await _unitOfWork.ToDoProviders.AnyAsync(a => a.ID == toDoProviderID);
            if (result)
            {
                var toDoProvider = await _unitOfWork.ToDoProviders.GetAsync(a => a.ID == toDoProviderID);
                toDoProvider.IsActive = false;
                await _unitOfWork.ToDoProviders.UpdateAsync(toDoProvider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{toDoProvider.Name} is passive");
            }
            return new Result(ResultStatus.Error, "Not found ToDoProvider");
        }
    }
}
