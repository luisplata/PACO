using UnityEngine;

public class AudioPacoFactory
{
    private readonly AudioPacoConfiguration audioPacoConfiguration;

    public AudioPacoFactory(AudioPacoConfiguration audioPacoConfiguration)
    {
        this.audioPacoConfiguration = audioPacoConfiguration;
    }

    public AudioClipPaco Create(string id)
    {
        var prefab = audioPacoConfiguration.GetAudioPrefabById(id);

        return Object.Instantiate(prefab);
    }
}