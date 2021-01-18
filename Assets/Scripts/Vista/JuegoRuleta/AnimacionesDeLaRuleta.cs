using TMPro;
using UnityEngine;

public class AnimacionesDeLaRuleta : MonoBehaviour, IAnimacionesDeRuletaMono
{
    private Animator anim;
    [SerializeField] private TextMeshProUGUI[] listaDeTextos;
    private IBaraja baraja;
    private ICarta cartaWin;
    private LogicaDeAnimaciones logica;
    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        logica = new LogicaDeAnimaciones();
        anim = GetComponent<Animator>();
    }
    public void StartAnimation()
    {
        if (logica.VolverAnimar)
        {
            logica.VolverAnimar = false;
            anim.SetTrigger("start");
        }
    }

    public void CambioDeTextosParaRuleta()
    {
        LlenadoDeRuleta();
        ColocandoCartaWin();
    }

    public void Init(IBaraja baraja, ICarta carta)
    {
        Debug.Log(baraja.Cartas.Count);
        StartAnimation();
        this.baraja = baraja;
        cartaWin = carta;
    }

    private void LlenadoDeRuleta()
    {
        var index = 0;
        foreach (TextMeshProUGUI texto in listaDeTextos)
        {
            texto.text = baraja.Cartas[index].Texto;
            index++;
        }
    }

    private void ColocandoCartaWin()
    {
        listaDeTextos[0].text = cartaWin.Texto;
    }

    public void TerminandoAnimacionDeRuleta()
    {
        logica.VolverAnimar = true;
    }

    public void EjecucionDeSonidoDeRuletaAlGirar()
    {
        source.PlayOneShot(clip);
    }
}
