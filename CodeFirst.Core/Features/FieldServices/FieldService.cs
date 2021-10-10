using AutoMapper;
using CodeFirst.Core.DTOs.Field.Request;
using CodeFirst.Core.DTOs.Field.Response;
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

namespace CodeFirst.Core.Features.FieldServices
{
    public class FieldService : IFieldService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly PaginationOptionsSetting _paginationOptions;
        public FieldService(
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

        public PagedResponse<IEnumerable<FieldDtoResponse>> GetFields(FieldQueryFilter filters, string actionUrl)
        {
            PaginationFilter validFilter = new(filters.PageNumber, filters.PageSize, _paginationOptions);
            IQueryable<Field> FieldPagedData = _unitOfWork.FieldRepositoryAsync.GetPagedElementsAsync(validFilter.PageNumber, validFilter.PageSize, x => x.Id, true).Result;

            if (!string.IsNullOrEmpty(filters.Code))
            {
                FieldPagedData = FieldPagedData.Where(x => x.Code == filters.Code);
            }

            if (!string.IsNullOrEmpty(filters.Name))
            {
                FieldPagedData = FieldPagedData.Where(x => x.Name == filters.Name);
            }
            var total = FieldPagedData.Count();

            PagedResponse<IEnumerable<FieldDtoResponse>> response = PaginationHelper.PadageCreateResponse<FieldDtoResponse, Field>(
                                                                    FieldPagedData.ToList(),
                                                                    validFilter,
                                                                    _paginationOptions,
                                                                    total,
                                                                    _uriService,
                                                                    actionUrl,
                                                                    _mapper
                                                               );
            return response;
        }
        public async Task<Response<FieldDtoResponse>> GetFieldAsync(int id)
        {
            Field fieldBuscado = await _unitOfWork.FieldRepositoryAsync.GetByIdAsync(id).ConfigureAwait(false);
            if (fieldBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }
            FieldDtoResponse fieldMap = _mapper.Map<FieldDtoResponse>(fieldBuscado);
            return new Response<FieldDtoResponse>(fieldMap) { Message = "La información solicitada ha sido exitosa." };
        }
        public async Task<Response<FieldDtoResponse>> InsertFieldAsync(FieldAddDtoRequest field)
        {
            Field fieldMap = _mapper.Map<Field>(field);
            await _unitOfWork.FieldRepositoryAsync.AddAsync(fieldMap).ConfigureAwait(false);
            await _unitOfWork.CommitAsync();
            FieldDtoResponse fieldCreado = _mapper.Map<FieldDtoResponse>(fieldMap);
            return new Response<FieldDtoResponse>(fieldCreado) { Message = $"El campo {fieldCreado.Name} ha sido creado." };
        }
        public async Task<Response<FieldDtoResponse>> UpdateFieldAsync(FieldUpdateDtoRequest field)
        {
            Field fieldBuscado = await _unitOfWork.FieldRepositoryAsync
                                                    .GetFirstAsync(x => x.Id.Equals(field.Id))
                                                    .ConfigureAwait(false);
            if (fieldBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }

            fieldBuscado.Code = field.Code;
            fieldBuscado.Name = field.Name;

            await _unitOfWork.FieldRepositoryAsync.UpdateAsync(fieldBuscado);
            await _unitOfWork.CommitAsync();
            FieldDtoResponse fieldActualizado = _mapper.Map<FieldDtoResponse>(fieldBuscado);

            return new Response<FieldDtoResponse>(fieldActualizado) { Message = $"El campo {fieldActualizado.Name} ha sido actualizada." };
        }
        public async Task<Response<bool>> DeleteFieldAsync(int id)
        {
            if (id <= 0) { throw new CoreException($"El valor del identificador id debe ser superior a cero(0)."); }
            bool fieldEliminado = await _unitOfWork.FieldRepositoryAsync.DeleteAsync(id).ConfigureAwait(false);
            if (!fieldEliminado) { throw new CoreException("El registro no ha sido Eliminado."); }
            await _unitOfWork.CommitAsync();
            return new Response<bool>(fieldEliminado) { Message = $"El registro solicitado ha sido eliminado." };
        }
    }
}
