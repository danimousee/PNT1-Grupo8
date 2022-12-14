using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TurneroMVC.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Numero de Comprobante")]
        public int Id { get; set; }


        [Display(Name = "Fecha y Hora")]
        [DataType(DataType.DateTime)]
        public DateTime DiaHora { get; set; }
       
        [EnumDataType(typeof(Actividad))]
        public Actividad Actividad { get; set; }

        public int CuentaId { get; set; }

        public Cuenta Cuenta { get; set; }


    }
}
