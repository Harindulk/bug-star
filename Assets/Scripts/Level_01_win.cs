using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level_01_win : MonoBehaviour
{
    public GameObject EndScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endCam;

    [SerializeField] private Transform player_boi;
    [SerializeField] private AudioClip winSound;
    [SerializeField] AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        EndScreen.gameObject.SetActive(true);
        endCam.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Destroy(player);

        if (other.CompareTag("Player"))
        {
            AudioSource.PlayOneShot(winSound);
        }
    }

}
