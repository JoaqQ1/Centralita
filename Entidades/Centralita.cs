using System;
using System.Text;
using Entidades;
using static Entidades.Llamada;

namespace Entidades
{
	public class Centralita
	{
        private string razonSocial;
        private readonly List<Llamada> listaDeLlamadas;

        public float GananciaPorTotal { get { return CalcularGanacia(ETipoLlamada.Todas); } }
        public float GananciaPorLocal { get { return CalcularGanacia(ETipoLlamada.Local); } }
        public float GananciaPorProvincial { get { return CalcularGanacia(ETipoLlamada.Provincia); } }
        public List<Llamada> LLamadas { get { return this.listaDeLlamadas; } }

        public Centralita()
		{
			this.listaDeLlamadas = new List<Llamada>();
		}
        public Centralita(string nombreEmpresa):this()
        {
			this.razonSocial = nombreEmpresa;
        }
        private float CalcularGanacia(ETipoLlamada tipoLlamada)
		{
            float acumuladorProvincial = 0;
            float acumuladorLocal = 0;
            float acumuladorTotal = 0;
            foreach (Llamada item in this.listaDeLlamadas)
            {
                acumuladorTotal += item.CostoLlamada;
                if (item is Provincial)
                {
                    acumuladorProvincial += ((Provincial)item).CostoLlamada;
                }
                else if(item is Local)
                {
                    acumuladorLocal += ((Local)item).CostoLlamada;
                }
            }
            if (tipoLlamada == ETipoLlamada.Local)
            {
                return acumuladorLocal;
            }
            else if(tipoLlamada == ETipoLlamada.Provincia)
            {
                return acumuladorProvincial;
            }
            else
            {
                return acumuladorTotal;
            }
            
		}
		private string Mostrar()
		{
            StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Razon Social: {this.razonSocial}");
			sb.AppendLine($"Ganancia Total: {this.GananciaPorTotal}");
            sb.AppendLine($"Ganancia Local: {this.GananciaPorLocal}");
            sb.AppendLine($"Ganancia Provincial: {this.GananciaPorProvincial}");
            return sb.ToString();
        }
        public void OrdenarLlamadas()
        {
            foreach (var item in this.listaDeLlamadas)
            {
                this.listaDeLlamadas.Sort(item.OrdenarPorDuraion);
            }
        }
        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            if(nuevaLlamada is not null)
            {
                this.LLamadas.Add(nuevaLlamada);
            }
        }
        public static bool operator ==(Centralita c, Llamada llamada)
        {
            bool rtn = false;
            foreach (var item in c.LLamadas)
            {
                if(item == llamada)
                {
                    rtn = true;
                }
            }
            return rtn;
        }
        public static bool operator !=(Centralita c, Llamada llamada)
        {
            return !(c == llamada);
        }
        public static Centralita operator +(Centralita c,Llamada llamada)
        {
            if (c != llamada)
            {
                c.AgregarLlamada(llamada);              
            }
            return c;
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
