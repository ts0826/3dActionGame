using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offSet;
    void Start()
    {
        offSet = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + offSet;
        transform.RotateAround(target.position,
                                Vector2.up,
                                orbitSpeed * Time.deltaTime);
        offSet = transform.position - target.position;

    }
}
