using UnityEngine;
public class AudioClipPaco : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private AudioClip clip;

    public string Id => id;

    public AudioClip Clip => clip; 
}