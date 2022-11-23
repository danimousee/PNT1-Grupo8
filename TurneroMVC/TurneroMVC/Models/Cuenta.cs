using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TurneroMVC.Models
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public String Contrasenia { get; set; }

        public String CodVerif { get; set; }

        [Display(Name = "Nombre y Apellido")]
        public String NombreCompleto { get; set; }

        public int Edad { get; set; }

        public int Dni { get; set; }

        public List<Turno> TurnosReservados { get; set; }
    }
}
