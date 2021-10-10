using AutoMapper;
using CodeFirst.Core.DTOs.Field.Request;
using CodeFirst.Core.DTOs.Field.Response;
using CodeFirst.Core.DTOs.Flow.Request;
using CodeFirst.Core.DTOs.Flow.Response;
using CodeFirst.Core.DTOs.Step.Request;
using CodeFirst.Core.DTOs.Step.Response;
using CodeFirst.Core.DTOs.StepToFlow.Request;
using CodeFirst.Core.DTOs.StepToFlow.Response;
using CodeFirst.Domain.Entities;

namespace CodeFirst.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<FlowdAddDtoRequest, Flow>();
            CreateMap<Flow, FlowDtoResponse>();

            CreateMap<StepAddDtoRequest, Step>();
            CreateMap<Step, StepDtoResponse>();

            CreateMap<FieldAddDtoRequest, Field>();
            CreateMap<Field, FieldDtoResponse>();

            CreateMap<StepToFlowAddDtoRequest, StepToFlow>();
            CreateMap<StepToFlow, StepToFlowDtoResponse>();
        }
    }
}
