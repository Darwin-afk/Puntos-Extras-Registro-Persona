using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Registro_Persona.Entidad
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombres = string.Empty;
        }
    }
}
