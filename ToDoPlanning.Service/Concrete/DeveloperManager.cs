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
    public class DeveloperManager : IDeveloperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeveloperManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(DeveloperAddDto developerAddDto)
        {
            var developer = _mapper.Map<Developer>(developerAddDto);
            await _unitOfWork.Developers.AddAsync(developer);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{developerAddDto.Name} added successfully");
        }

        public async Task<IResult> Delete(int developerID)
        {
            var result = await _unitOfWork.Developers.AnyAsync(a => a.ID == developerID);
            if (result)
            {
                var developer = await _unitOfWork.Developers.GetAsync(a => a.ID == developerID);
                developer.IsActive = false;
                await _unitOfWork.Developers.UpdateAsync(developer);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{developer.Name} is passive");
            }
            return new Result(ResultStatus.Error, "Not found Developer");
        }

        public async Task<IDataResult<DeveloperListDto>> GetAllDeveloperByActive()
        {
            var developers = await _unitOfWork.Developers.GetAllAsync(null, a => a.IsActive);
            if (developers.Count > -1)
            {
                return new DataResult<DeveloperListDto>(ResultStatus.Success, new DeveloperListDto
                {
                    Developers = developers.ToList(),
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DeveloperListDto>(ResultStatus.Error, "Active developer Not Found", null);
        }
    }
}
