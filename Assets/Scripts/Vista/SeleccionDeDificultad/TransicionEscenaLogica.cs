using System;
using System.Threading.Tasks;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class TransicionEscenaLogica
{
    private ITransicionEscenaMono transicionEscenaMono;
    private bool hasEnter;
    private Image cortina;
    private float curtOff;
    

    public TransicionEscenaLogica(ITransicionEscenaMono transicionEscenaMono, bool hasEnter, Image cortina)
    {
        this.transicionEscenaMono = transicionEscenaMono;
        this.hasEnter = hasEnter;
        Assert.IsNotNull(cortina, "La cortina, osea la imagen, es nula. Agregala al Script de la transicion");
        this.cortina = cortina;
        curtOff = this.hasEnter ? 1 : 0;
        this.cortina.material.SetFloat("_Cutoff", curtOff);
    }

    public void OnTransicion()
    {
        
        if (hasEnter)
        {
            ComienzaTransicionEntrada().WrapErrors();
        }
        else
        {
            ComienzaTransicionSalida().WrapErrors();
        }
    }

    private async Task ComienzaTransicionEntrada()
    {
        while (curtOff > 0)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            curtOff -= 0.1f;
            cortina.material.SetFloat("_Cutoff", curtOff);
        }
        transicionEscenaMono.CambiarDeEscena();
    }

    private async Task ComienzaTransicionSalida()
    {
        while(curtOff <= 1)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            curtOff += 0.1f;
            cortina.material.SetFloat("_Cutoff", curtOff);
        }
        await Task.Delay(TimeSpan.FromSeconds(2));
        transicionEscenaMono.CambiarDeEscena();
    }
}

