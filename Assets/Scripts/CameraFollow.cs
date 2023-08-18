using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    

    void Update() {
        transform.position = player.transform.position + offset;
    }
}