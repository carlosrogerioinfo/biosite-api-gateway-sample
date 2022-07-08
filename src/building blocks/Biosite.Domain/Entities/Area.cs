using Biosite.Core.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;

namespace Biosite.Domain.Entities
{
    public class Area : Entity
    {
        //Constructors
        protected Area() //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected
        {
        }

        public Area(Guid id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;

            //Validations for notifications events here
            new ValidationContract<Area>(this)
                .IsRequired(x => x.Name, "Nome da área deve ser informado")
                .IsRequired(x => x.Description, "Descrição da área deve ser informado")
                ;
        }

        //Properties
        public string Name { get; private set; }
        public string Description { get; private set; }

        //Relationchip N:N
        public virtual ICollection<PlanArea> PlanAreas { get; set; }

    }
}
