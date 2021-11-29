using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSound : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private AudioClip wallSound;
    [SerializeField] AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayOneShot(wallSound);
        }
    }
}
