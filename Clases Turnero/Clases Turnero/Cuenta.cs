using System;

public class Cuenta
{
	private String direccionCorreo;
	private String contraseña;
	private String codVerif;
	private String nombreCompleto;
	private int edad;
	private int dni;

	public Cuenta(String correo, String contraseña, String codVerif, String nombreCompleto, int edad, int dni)
    {
		this.direccionCorreo = correo;
		this.contraseña = contraseña;
		this.codVerif = codVerif;
		this.nombreCompleto = nombreCompleto;
		this.edad = edad;
		this.dni = dni;

    }
}
