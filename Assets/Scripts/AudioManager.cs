using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup soundEffectMixer;
    private int musicIndex = 0;
    public AudioClip[] playlist;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance AudioManager dans la scène");
            return;
        }
        instance = this;
    }
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
        
    }
    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        // new temp gameObject, called TempAudio
        GameObject tempGO = new GameObject("TempAudio");
        // position of the gameobject
        tempGO.transform.position = pos;
        // Add audio source to this GO
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO,clip.length);
        return audioSource;
    }
}
