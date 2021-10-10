using AutoMapper;
using CodeFirst.Core.DTOs.Step.Request;
using CodeFirst.Core.DTOs.Step.Response;
using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Helpers;
using CodeFirst.Core.Interfaces.Repositories;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Core.QueryFilters;
using CodeFirst.Core.QueryFilters.Pagination;
using CodeFirst.Core.Wrappers;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.StepServices
{
    public class StepService : IStepService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly PaginationOptionsSetting _paginationOptions;
        public StepService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUriService uriService,
            IOptions<PaginationOptionsSetting> options
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uriService = uriService;
            _paginationOptions = options.Value;
        }

        public PagedResponse<IEnumerable<StepDtoResponse>> GetSteps(SetpQueryFilter filters, string actionUrl)
        {
            PaginationFilter validFilter = new(filters.PageNumber, filters.PageSize, _paginationOptions);
            IQueryable<Step> StepPagedData = _unitOfWork.
                StepRepositoryAsync.GetPagedElementsAsync(validFilter.PageNumber, validFilter.PageSize, x => x.Id, true).Result;

            if (!string.IsNullOrEmpty(filters.Code))
            {
                StepPagedData = StepPagedData.Where(x => x.Code == filters.Code);
            }

            if (!string.IsNullOrEmpty(filters.Name))
            {
                StepPagedData = StepPagedData.Where(x => x.Name == filters.Name);
            }
            var total = StepPagedData.Count();

            PagedResponse<IEnumerable<StepDtoResponse>> response = PaginationHelper.PadageCreateResponse<StepDtoResponse, Step>(
                                                                    StepPagedData.ToList(),
                                                                    validFilter,
                                                                    _paginationOptions,
                                                                    total,
                                                                    _uriService,
                                                                    actionUrl,
                                                                    _mapper
                                                               );
            return response;
        }
        public async Task<Response<StepDtoResponse>> GetStepAsync(int id)
        {
            Step stepBuscado = await _unitOfWork.StepRepositoryAsync.GetByIdAsync(id).ConfigureAwait(false);
            if (stepBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }
            StepDtoResponse stepMap = _mapper.Map<StepDtoResponse>(stepBuscado);
            return new Response<StepDtoResponse>(stepMap) { Message = "La información solicitada ha sido exitosa." };
        }
        public async Task<Response<StepDtoResponse>> InsertStepAsync(StepAddDtoRequest step)
        {
            Step stepMap = _mapper.Map<Step>(step);
            await _unitOfWork.StepRepositoryAsync.AddAsync(stepMap).ConfigureAwait(false);
            await _unitOfWork.CommitAsync();
            StepDtoResponse stepCreado = _mapper.Map<StepDtoResponse>(stepMap);
            return new Response<StepDtoResponse>(stepCreado) { Message = $"El pasos {stepCreado.Name} ha sido creado." };
        }
        public async Task<Response<StepDtoResponse>> UpdateStepAsync(StepUpdateDtoRequest step)
        {
            Step stepBuscado = await _unitOfWork.StepRepositoryAsync
                                                    .GetFirstAsync(x => x.Id.Equals(step.Id))
                                                    .ConfigureAwait(false);
            if (stepBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }

            stepBuscado.Code = step.Code;
            stepBuscado.Name = step.Name;

            await _unitOfWork.StepRepositoryAsync.UpdateAsync(stepBuscado);
            await _unitOfWork.CommitAsync();
            StepDtoResponse stepActualizado = _mapper.Map<StepDtoResponse>(stepBuscado);

            return new Response<StepDtoResponse>(stepActualizado) { Message = $"El pasos {stepActualizado.Name} ha sido actualizada." };
        }
        public async Task<Response<bool>> DeleteStepAsync(int id)
        {
            if (id <= 0) { throw new CoreException($"El valor del identificador id debe ser superior a cero(0)."); }
            bool alumnoEliminado = await _unitOfWork.StepRepositoryAsync.DeleteAsync(id).ConfigureAwait(false);
            if (!alumnoEliminado) { throw new CoreException("El registro no ha sido Eliminado."); }
            await _unitOfWork.CommitAsync();
            return new Response<bool>(alumnoEliminado) { Message = $"El registro solicitado ha sido eliminado." };
        }
    }
}
