using Biosite.Core.Entities;
using FluentValidator;
using System;

namespace Biosite.Domain.Entities
{
    public class PlanArea : Entity
    {
        //Constructors
        protected PlanArea() { } //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected

        public PlanArea(Guid id, Guid areaId, Guid planId)
        {
            this.Id = id;
            this.AreaId = areaId;
            this.PlanId = planId;

            //Validations for notifications events here
            new ValidationContract<PlanArea>(this)
                ;
        }

        //Properties
        public Guid PlanId { get; set; }
        public virtual Plan Plan { get; set; }

        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

    }
}
