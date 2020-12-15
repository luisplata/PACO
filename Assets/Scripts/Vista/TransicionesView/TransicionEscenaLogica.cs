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

    public int IndexScene { get; private set; }

    public TransicionEscenaLogica(ITransicionEscenaMono transicionEscenaMono, Image cortina)
    {
        this.transicionEscenaMono = transicionEscenaMono;
        Assert.IsNotNull(cortina, "La cortina, osea la imagen, es nula. Agregala al Script de la transicion");
        this.cortina = cortina;
        curtOff = this.hasEnter ? 1 : 0;
        this.cortina.material.SetFloat("_Cutoff", curtOff);
    }


    public void OnTransicionExit(int indexScene)
    {
        IndexScene = indexScene;
        ComienzaTransicionSalida().WrapErrors();
    }

    public void OnTransicionEnter()
    {
        ComienzaTransicionEntrada().WrapErrors();
    }

    private async Task ComienzaTransicionEntrada()
    {
        while (curtOff > 0)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            curtOff -= 0.1f;
            cortina.material.SetFloat("_Cutoff", curtOff);
        }
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
        transicionEscenaMono.CambiarDeEscena(IndexScene);
    }
}