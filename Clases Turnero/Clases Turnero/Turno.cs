using System;

public class Turno
{
	private int nroComprobante;
	private DateTime diaHora;
	private Actividad actividad;


	public Turno(int nroComprobante, DateTime diaHora, Actividad actividad)
	{
		this.nroComprobante = nroComprobante;
		this.diaHora = diaHora;
		this.actividad = actividad;
	}
}
