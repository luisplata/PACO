using System.Collections.Generic;

public class BarajaRuleta : Baraja
{
    public BarajaRuleta(List<ICarta> listaDeCartas) : base(listaDeCartas)
    {
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override ICarta TomarCarta()
    {
        if (Cartas.Count <= 0)
        {
            throw new NoHayCartasException("No hay mas cartas que elegir");
        }
        int index = RandomLocal(0, Cartas.Count);
        int countAllViews = 0;
        while (Cartas[index].FueElegido && countAllViews <= 10)
        {
            index = RandomLocal(0, Cartas.Count);
            countAllViews++;
        }
        if(countAllViews >= 10)
        {
            foreach(ICarta carta in Cartas)
            {
                carta.FueElegido = false;
            }
        }
        Cartas[index].FueElegido = true;
        ICarta cartaElejida = Cartas[index];
        //Cartas.RemoveAt(index);
        return cartaElejida;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}