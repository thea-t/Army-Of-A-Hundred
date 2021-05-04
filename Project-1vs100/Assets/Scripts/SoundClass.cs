using UnityEngine;
using UnityEngine.Audio;

//Sound Class Script from <https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys> timestamp ~ 5:30
[System.Serializable]
public class SoundClass
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool loop;
    [HideInInspector]public AudioSource source;

}
