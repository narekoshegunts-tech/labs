using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;

    private float _audioVolumeGrowingSpeed = 0.1f;
    private float _audioVolumeFallingSpeed = 0.1f;
    
    private Coroutine _audioRoutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private IEnumerator StartAudio()
    {
        _audioSource.Play();
        while (_audioSource.volume < 1f)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, _audioVolumeGrowingSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator StopAudio()
    {
        while (_audioSource.volume > 0f)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0f, _audioVolumeFallingSpeed * Time.deltaTime);
            yield return null;
        }
        _audioSource.Stop();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Start Audio");
        StopAudioCoroutine();
        _audioRoutine = StartCoroutine(StartAudio());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Stop Audio");
        StopAudioCoroutine();
        _audioRoutine = StartCoroutine(StopAudio());
    }
    
    private void StopAudioCoroutine()
    {
        if (_audioRoutine != null)
        {
            Debug.Log(_audioRoutine);
            StopCoroutine(_audioRoutine);
            
        }
    }
}
