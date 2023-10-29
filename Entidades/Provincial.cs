using System;
using System.Text;

namespace Entidades
{
	public class Provincial:Llamada
	{
        private EFranja franjaHoraria;

        public enum EFranja { Franja_1=099,Franja_2=125,Franja_3=066}
        public override float CostoLlamada { get { return CalcularCosto(); } }

        public Provincial(EFranja miFranja,Llamada llamada):this(llamada.NroOrigen, miFranja,llamada.Duracion,llamada.NroDestino)
		{
		}

        public Provincial(string nroOrigen,EFranja miFranja,float duracion,string nroDestino) : base(duracion, nroDestino, nroOrigen)
        {
			this.franjaHoraria = miFranja;
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new();
            sb.Append(base.Mostrar());
            sb.AppendLine($"Franja horaria: {this.franjaHoraria}");
            sb.AppendLine($"Costo llamada: {this.CostoLlamada}");
            return sb.ToString();
        }
        private float CalcularCosto()
        {
            return this.Duracion * (int)this.franjaHoraria/100;
        }
        public override bool Equals(object? obj)
        {
            return obj is Provincial;
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}

