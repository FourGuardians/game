using UnityEngine;

public class PositionLock : MonoBehaviour
{
    [Header("Lock Position")]
    public bool LockX = false;
    public bool LockY = false;
    public bool LockZ = false;

    private float x, y, z;

    public void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    public void LateUpdate()
    {
        if (!LockX)
            x = transform.position.x;

        if (!LockY)
            y = transform.position.y;

        if (!LockZ)
            z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}