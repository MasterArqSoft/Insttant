using AutoMapper;
using CodeFirst.Core.DTOs.Flow.Request;
using CodeFirst.Core.DTOs.Flow.Response;
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

namespace CodeFirst.Core.Features.AlumnoServices
{
    public class FlowService : IFlowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly PaginationOptionsSetting _paginationOptions;
        public FlowService(
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
        public PagedResponse<IEnumerable<FlowDtoResponse>> GetFlows(FlowQueryFilter filters, string actionUrl)
        {
            PaginationFilter validFilter = new(filters.PageNumber, filters.PageSize, _paginationOptions);
            IQueryable<Flow> FlowPagedData = _unitOfWork.FlowRepositoryAsync.GetPagedElementsAsync(validFilter.PageNumber, validFilter.PageSize, x => x.Id, true).Result;

            if (!string.IsNullOrEmpty(filters.Code))
            {
                FlowPagedData = FlowPagedData.Where(x => x.Code == filters.Code);
            }

            if (!string.IsNullOrEmpty(filters.Name))
            {
                FlowPagedData = FlowPagedData.Where(x => x.Name == filters.Name);
            }
            var total = FlowPagedData.Count();

            PagedResponse<IEnumerable<FlowDtoResponse>> response = PaginationHelper.PadageCreateResponse<FlowDtoResponse, Flow>(
                                                                    FlowPagedData.ToList(),
                                                                    validFilter,
                                                                    _paginationOptions,
                                                                    total,
                                                                    _uriService,
                                                                    actionUrl,
                                                                    _mapper
                                                               );
            return response;
        }
        public async Task<Response<FlowDtoResponse>> GetFlowAsync(int id)
        {
            Flow flowBuscado = await _unitOfWork.FlowRepositoryAsync.GetByIdAsync(id).ConfigureAwait(false);
            if (flowBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }
            FlowDtoResponse flowMap = _mapper.Map<FlowDtoResponse>(flowBuscado);
            return new Response<FlowDtoResponse>(flowMap) { Message = "La información solicitada ha sido exitosa." };
        }
        public async Task<Response<FlowDtoResponse>> InsertFlowAsync(FlowdAddDtoRequest flow)
        {
            Flow flowMap = _mapper.Map<Flow>(flow);
            await _unitOfWork.FlowRepositoryAsync.AddAsync(flowMap).ConfigureAwait(false);
            await _unitOfWork.CommitAsync();
            FlowDtoResponse flowCreado = _mapper.Map<FlowDtoResponse>(flowMap);
            return new Response<FlowDtoResponse>(flowCreado) { Message = $"El flujo {flowCreado.Name} ha sido creado." };
        }
        public async Task<Response<FlowDtoResponse>> UpdateFlowAsync(FlowUpdateDtoRequest flow)
        {
            Flow flowBuscado = await _unitOfWork.FlowRepositoryAsync
                                                    .GetFirstAsync(x => x.Id.Equals(flow.Id))
                                                    .ConfigureAwait(false);
            if (flowBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }

            flowBuscado.Code = flow.Code;
            flowBuscado.Name = flow.Name;

            await _unitOfWork.FlowRepositoryAsync.UpdateAsync(flowBuscado);
            await _unitOfWork.CommitAsync();
            FlowDtoResponse flowActualizado = _mapper.Map<FlowDtoResponse>(flowBuscado);

            return new Response<FlowDtoResponse>(flowActualizado) { Message = $"El flujo {flowActualizado.Name} ha sido actualizada." };
        }
        public async Task<Response<bool>> DeleteFlowAsync(int id)
        {
            if (id <= 0) { throw new CoreException($"El valor del identificador id debe ser superior a cero(0)."); }
            bool alumnoEliminado = await _unitOfWork.FlowRepositoryAsync.DeleteAsync(id).ConfigureAwait(false);
            if (!alumnoEliminado) { throw new CoreException("El registro no ha sido Eliminado."); }
            await _unitOfWork.CommitAsync();
            return new Response<bool>(alumnoEliminado) { Message = $"El registro solicitado ha sido eliminado." };
        }

    }
}
