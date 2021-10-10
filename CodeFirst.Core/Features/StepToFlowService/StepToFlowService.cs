using AutoMapper;
using CodeFirst.Core.DTOs.StepToFlow.Request;
using CodeFirst.Core.DTOs.StepToFlow.Response;
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
    public class StepToFlowService : IStepToFlowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly PaginationOptionsSetting _paginationOptions;
        public StepToFlowService(
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

        public PagedResponse<IEnumerable<StepToFlowDtoResponse>> GetStepToFlows(StepToFlowQueryFilter filters, string actionUrl)
        {
            PaginationFilter validFilter = new(filters.PageNumber, filters.PageSize, _paginationOptions);
            IQueryable<StepToFlow> StepToFlowPagedData = _unitOfWork.StepToFlowRepositoryAsync.GetPagedElementsAsync(validFilter.PageNumber, validFilter.PageSize, x => x.Id, true).Result;

            if (filters.FlowId != default)
            {
                StepToFlowPagedData = StepToFlowPagedData.Where(x => x.IdFlow == filters.FlowId);
            }

            if (filters.StepId != default)
            {
                StepToFlowPagedData = StepToFlowPagedData.Where(x => x.IdSetp == filters.StepId);
            }
            var total = StepToFlowPagedData.Count();

            PagedResponse<IEnumerable<StepToFlowDtoResponse>> response = PaginationHelper.PadageCreateResponse<StepToFlowDtoResponse, StepToFlow>(
                                                                    StepToFlowPagedData.ToList(),
                                                                    validFilter,
                                                                    _paginationOptions,
                                                                    total,
                                                                    _uriService,
                                                                    actionUrl,
                                                                    _mapper
                                                               );
            return response;
        }
        public async Task<Response<StepToFlowDtoResponse>> GetStepToFlowAsync(int id)
        {
            StepToFlow stepToFlowBuscado = await _unitOfWork.StepToFlowRepositoryAsync.GetByIdAsync(id).ConfigureAwait(false);
            if (stepToFlowBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }
            StepToFlowDtoResponse stepToFlowMap = _mapper.Map<StepToFlowDtoResponse>(stepToFlowBuscado);
            return new Response<StepToFlowDtoResponse>(stepToFlowMap) { Message = "La información solicitada ha sido exitosa." };
        }
        public async Task<Response<StepToFlowDtoResponse>> InsertStepToFlowAsync(StepToFlowAddDtoRequest stepToFlow)
        {
            StepToFlow stepToFlowMap = _mapper.Map<StepToFlow>(stepToFlow);
            await _unitOfWork.StepToFlowRepositoryAsync.AddAsync(stepToFlowMap).ConfigureAwait(false);
            await _unitOfWork.CommitAsync();
            StepToFlowDtoResponse stepToFlowCreado = _mapper.Map<StepToFlowDtoResponse>(stepToFlowMap);
            return new Response<StepToFlowDtoResponse>(stepToFlowCreado) { Message = $"Asignado el flujo {stepToFlowCreado.Id} ha sido creado." };
        }
        public async Task<Response<StepToFlowDtoResponse>> UpdateStepToFlowAsync(StepToFlowUpdateDtoRequest stepToFlow)
        {
            StepToFlow stepToFlowBuscado = await _unitOfWork.StepToFlowRepositoryAsync
                                                    .GetFirstAsync(x => x.Id.Equals(stepToFlow.Id))
                                                    .ConfigureAwait(false);
            if (stepToFlowBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }

            stepToFlowBuscado.IdFlow = stepToFlow.FlowId;
            stepToFlowBuscado.IdSetp = stepToFlow.SetpId;

            await _unitOfWork.StepToFlowRepositoryAsync.UpdateAsync(stepToFlowBuscado);
            await _unitOfWork.CommitAsync();
            StepToFlowDtoResponse stepToFlowActualizado = _mapper.Map<StepToFlowDtoResponse>(stepToFlowBuscado);

            return new Response<StepToFlowDtoResponse>(stepToFlowActualizado) { Message = $"Asignado el flujo {stepToFlowActualizado.Id} ha sido actualizada." };
        }
        public async Task<Response<bool>> DeleteStepToFlowAsync(int id)
        {
            if (id <= 0) { throw new CoreException($"El valor del identificador id debe ser superior a cero(0)."); }
            bool alumnoEliminado = await _unitOfWork.StepToFlowRepositoryAsync.DeleteAsync(id).ConfigureAwait(false);
            if (!alumnoEliminado) { throw new CoreException("El registro no ha sido Eliminado."); }
            await _unitOfWork.CommitAsync();
            return new Response<bool>(alumnoEliminado) { Message = $"El registro solicitado ha sido eliminado." };
        }
    }
}
