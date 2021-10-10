namespace CodeFirst.Core.QueryFilters
{
    public class StepToFlowQueryFilter
    {
        public int StepId { get; set; }
        public int FlowId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
