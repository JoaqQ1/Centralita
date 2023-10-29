namespace Entidades;
using System.Text;
public abstract class Llamada
{
    public enum ETipoLlamada { Local, Provincia, Todas }

    protected float duracion;
    protected string nroDestino;
    protected string nroOrigen;

    public float Duracion { get { return this.duracion; } }
    public string NroDestino { get { return this.nroDestino; } }
    public string NroOrigen { get { return this.nroOrigen; } }
    public abstract float CostoLlamada { get; }

    public Llamada(float duracion, string nroDestino, string nroOrigen)
    {
        this.duracion = duracion;
        this.nroDestino = nroDestino;
        this.nroOrigen = nroOrigen;
    }
    public int OrdenarPorDuraion(Llamada llamada1,Llamada llamada2)
    {
        int rtn = 0;

        if(llamada1.Duracion > llamada2.Duracion)
        {
            return 1;
        }
        else if(llamada1.Duracion < llamada2.Duracion)
        {
            return -1;
        }
        return rtn;
    }
    protected virtual string Mostrar()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Nro de Origen: {this.NroOrigen}");
        sb.AppendLine($"Nro de Destino: {this.NroDestino}");
        sb.AppendLine($"Duracion: {this.Duracion}");
        return sb.ToString();
    }
    public static bool operator ==(Llamada llamada ,Llamada llamada2)
    {
        return llamada.GetType() == llamada2.GetType() && llamada.NroDestino == llamada2.NroDestino && llamada.NroOrigen == llamada2.NroOrigen;
    }
    public static bool operator !=(Llamada llamada, Llamada llamada2)
    {
        return !(llamada == llamada2);
    }
    public override bool Equals(object? obj)
    {
        return obj is Llamada && this == ((Llamada)obj);
    }
}

