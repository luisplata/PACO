using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primero : MonoBehaviour, IVistaGenero
{
    public IGenero Genero { get; private set; }
    [SerializeField] private string nombreGenero;

    // Start is called before the first frame update
    void Start()
    {
        Genero = new Genero();
        //debo buscar llenar el genero con datos del servidor
        Genero.Nombre = nombreGenero;

    }
}