using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PACO/SoundConfig")]
public class AudioPacoConfiguration : ScriptableObject
{
    [SerializeField] private AudioClipPaco[] audiosPaco;
    private Dictionary<string, AudioClipPaco> idToAudioPaco;

    private void Awake()
    {
        idToAudioPaco = new Dictionary<string, AudioClipPaco>(audiosPaco.Length);
        foreach (var audioPaco in audiosPaco)
        {
            idToAudioPaco.Add(audioPaco.Id, audioPaco);
        }
    }

    public AudioClipPaco GetAudioPrefabById(string id)
    {
        if (!idToAudioPaco.TryGetValue(id, out var audioPaco))
        {
            throw new AudioNotFoundException($"Audio with id {id} does not exit");
        }
        return audioPaco;
    }
}