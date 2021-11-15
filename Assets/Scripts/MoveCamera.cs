using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}