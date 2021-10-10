using CodeFirst.Domain.BaseEntities;

namespace CodeFirst.Domain.Entities
{
    public class StepToFlow : BaseEntity
    {
        public int IdFlow { get; set; }
        public int IdSetp { get; set; }
        public int IdField { get; set; }

        public virtual Flow Flow { get; set; }
        public virtual Step Step { get; set; }
        public virtual Field Field { get; set; }
    }
}
