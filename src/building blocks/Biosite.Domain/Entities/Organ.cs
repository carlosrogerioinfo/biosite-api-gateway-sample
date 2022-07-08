using Biosite.Core.Entities;
using FluentValidator;
using System;

namespace Biosite.Domain.Entities
{
    public class Organ : Entity
    {
        //Constructors
        protected Organ() //EntityFramework needs empty constructor, for prevents corruptive, we sign constructor protected
        {
        }

        public Organ(Guid id, string name, string description, string svg)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Svg = svg;

            //Validations for notifications events here
            new ValidationContract<Organ>(this)
                .IsRequired(x => x.Name, "Nome do órgão ou glândula deve ser informado")
                .IsRequired(x => x.Description, "Descrição do órgão ou glândula deve ser informado")
                .IsRequired(x => x.Svg, "Descrição do órgão ou glândula deve ser informado")
                ;
        }

        public Organ(string name, string description, string svg)
        {
            this.Name = name;
            this.Description = description;
            this.Svg = svg;

            //Validations for notifications events here
            new ValidationContract<Organ>(this)
                .IsRequired(x => x.Name, "Nome do órgão ou glândula deve ser informado")
                .IsRequired(x => x.Description, "Descrição do órgão ou glândula deve ser informado")
                .IsRequired(x => x.Svg, "imagem do órgão ou glândula deve ser informado")
                ;
        }

        //Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Svg { get; private set; }

        //Relationship
    }
}
