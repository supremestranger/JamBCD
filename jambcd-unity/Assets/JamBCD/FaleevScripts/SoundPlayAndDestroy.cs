using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayAndDestroy : MonoBehaviour
{
public GameObject player;
 [SerializeField] private AudioClip soundClip;
    private AudioSource audioSource;
    private bool hasPlayed;
    private GameObject thisGameObject;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasPlayed = false;
        thisGameObject = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        if (!hasPlayed && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
            hasPlayed = true;
        }
        else if (!audioSource.isPlaying)
        {
            thisGameObject.SetActive(false);
        }
    }
}
