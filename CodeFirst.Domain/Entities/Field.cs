using CodeFirst.Domain.BaseEntities;
using System.Collections.Generic;

namespace CodeFirst.Domain.Entities
{
    public class Field : BaseEntity
    {
        public Field()
        {
            StepToFlow = new HashSet<StepToFlow>();
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StepToFlow> StepToFlow { get; set; }
    }
}
