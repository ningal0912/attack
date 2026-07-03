using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float height = 15f;

    void LateUpdate()
    {
        if (player == null) return;

        transform.position = player.position + new Vector3(0, height, 0);

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}