using System.Collections.Generic;
using System;

namespace TurneroMVC.Models
{
    public class Cuenta
    {
        public int IdCuenta;
        public String DireccionCorreo;
        public String Contraseña;
        public String CodVerif;
        public String NombreCompleto;
        public int Edad;
        public int Dni;
        public List<Turno> TurnosReservados;
    }
}
