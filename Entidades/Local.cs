using System;
using System.Text;

namespace Entidades
{
	public class Local:Llamada
	{
        private float costo;

        public Local(Llamada llamada,float costo):this(llamada.NroOrigen,llamada.Duracion,llamada.NroDestino,costo)
		{
		}
        public Local(string origen,float duracion,string destino,float costo):base(duracion,destino,origen)
        {
			this.costo = costo;
        }

        public override float CostoLlamada { get { return this.CalcularCosto(); } }


        protected override string Mostrar()
        {
            StringBuilder sb = new();
            sb.Append(base.Mostrar());
            sb.AppendLine($"Costo: {this.CostoLlamada}");
            return sb.ToString();
        }
        private float CalcularCosto()
        {
            return this.Duracion * this.costo;
        }
        public override bool Equals(object? obj)
        {
            return obj is Local;
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}

