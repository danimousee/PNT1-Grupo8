using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TurneroMVC.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name = "Numero de Comprobante")]
        public int NroComprobante { get; set; }

        [Display(Name = "Fecha y Hora")]
        public DateTime DiaHora { get; set; }
       
        [EnumDataType(typeof(Actividad))]
        public Actividad Actividad { get; set; }

        //Como hacer para que me pida en las vistas a que cuenta pertenece?
        public Cuenta Cuenta { get; set; }

    }
}
