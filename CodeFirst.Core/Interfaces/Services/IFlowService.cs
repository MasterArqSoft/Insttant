using CodeFirst.Core.DTOs.Flow.Request;
using CodeFirst.Core.DTOs.Flow.Response;
using CodeFirst.Core.QueryFilters;
using CodeFirst.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface IFlowService
    {
        PagedResponse<IEnumerable<FlowDtoResponse>> GetFlows(FlowQueryFilter filters, string actionUrl);
        Task<Response<FlowDtoResponse>> GetFlowAsync(int id);
        Task<Response<FlowDtoResponse>> InsertFlowAsync(FlowdAddDtoRequest Flow);
        Task<Response<FlowDtoResponse>> UpdateFlowAsync(FlowUpdateDtoRequest Flow);
        Task<Response<bool>> DeleteFlowAsync(int id);
    }
}
