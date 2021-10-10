using CodeFirst.Core.DTOs.Field.Request;
using CodeFirst.Core.DTOs.Field.Response;
using CodeFirst.Core.QueryFilters;
using CodeFirst.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface IFieldService
    {
        PagedResponse<IEnumerable<FieldDtoResponse>> GetFields(FieldQueryFilter filters, string actionUrl);
        Task<Response<FieldDtoResponse>> GetFieldAsync(int id);
        Task<Response<FieldDtoResponse>> InsertFieldAsync(FieldAddDtoRequest Field);
        Task<Response<FieldDtoResponse>> UpdateFieldAsync(FieldUpdateDtoRequest Field);
        Task<Response<bool>> DeleteFieldAsync(int id);
    }
}
