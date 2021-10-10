using CodeFirst.Core.DTOs.Step.Request;
using CodeFirst.Core.DTOs.Step.Response;
using CodeFirst.Core.QueryFilters;
using CodeFirst.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface IStepService
    {
        PagedResponse<IEnumerable<StepDtoResponse>> GetSteps(SetpQueryFilter filters, string actionUrl);
        Task<Response<StepDtoResponse>> GetStepAsync(int id);
        Task<Response<StepDtoResponse>> InsertStepAsync(StepAddDtoRequest Step);
        Task<Response<StepDtoResponse>> UpdateStepAsync(StepUpdateDtoRequest Step);
        Task<Response<bool>> DeleteStepAsync(int id);
    }
}
