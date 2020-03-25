using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target => transform.parent;

    public void Mount<T>(T target) where T : Component =>
        Mount(target.transform);

    public void Mount(GameObject target) =>
        Mount(target.transform);

    public void Mount(Transform target) =>
        transform.SetParent(target);

    public void Unmount() =>
        transform.SetParent(Scene.Cameras.transform);
}