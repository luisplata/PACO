using UnityEngine;

public class Juego : MonoBehaviour
{
    [SerializeField] private int escena;

    public int Escena { get => escena; set => escena = value; }
}