using CodeFirst.Core.DTOs.StepToFlow.Request;
using CodeFirst.Core.DTOs.StepToFlow.Response;
using CodeFirst.Core.QueryFilters;
using CodeFirst.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface IStepToFlowService
    {
        PagedResponse<IEnumerable<StepToFlowDtoResponse>> GetStepToFlows(StepToFlowQueryFilter filters, string actionUrl);
        Task<Response<StepToFlowDtoResponse>> GetStepToFlowAsync(int id);
        Task<Response<StepToFlowDtoResponse>> InsertStepToFlowAsync(StepToFlowAddDtoRequest StepToFlow);
        Task<Response<StepToFlowDtoResponse>> UpdateStepToFlowAsync(StepToFlowUpdateDtoRequest StepToFlow);
        Task<Response<bool>> DeleteStepToFlowAsync(int id);
    }
}
