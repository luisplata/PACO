using UnityEngine;

public class SonidosUnity : IPlaySoundEfect
{
    private AudioSource audioSource;
    private readonly AudioPacoFactory audioPacoFactory;

    public SonidosUnity(AudioPacoConfiguration config, AudioSource audioSource)
    {
        this.audioSource = audioSource;
        audioPacoFactory = new AudioPacoFactory(config);
    }
    public void PlayOneShot(string audio)
    {
        var clip = audioPacoFactory.Create(audio);
        audioSource.PlayOneShot(clip.Clip);
        Object.Destroy(clip.gameObject);
    }
    
}
