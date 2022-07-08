using Biosite.Core.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Biosite.Domain.Entities
{
    public class Plan : Entity
    {
        //Constructors
        protected Plan() { } //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected

        public Plan(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.LastUpdate = DateTime.Now;

            //Validations for notifications events here
            new ValidationContract<Plan>(this)
                ;
        }

        //Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime LastUpdate { get; private set; }

        //Relationchip 1:N
        public virtual ICollection<User> Users { get; set; }

        //Relationchip N:N
        public virtual ICollection<PlanArea> PlanAreas { get; set; }
    }

}
