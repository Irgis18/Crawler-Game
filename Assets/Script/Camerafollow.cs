using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform player;

    public float timeOffset = 0.2f;

    public Vector3 posOffset;

    private Vector3 velocity;

    void Awake()
    {
        transform.position = player.position + posOffset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, timeOffset);
    }
}
