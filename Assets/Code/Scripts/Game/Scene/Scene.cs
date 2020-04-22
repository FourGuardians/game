#pragma warning disable CS0649
#pragma warning disable IDE0044

using UnityEngine;

public class Scene : MonoBehaviour
{
    [SerializeField]
    private GameObject system;

    [SerializeField]
    private GameObject cameras;

    [SerializeField]
    private SceneCanvas canvas;

    [SerializeField]
    private SceneWorld world;

    public void Start()
    {
        if (Globals.Scene != null)
            Destroy(this);

        Globals.Scene = this;
    }

    public static GameObject System => Globals.Scene.system;
    public static SceneCanvas Canvas => Globals.Scene.canvas;
    public static SceneWorld World => Globals.Scene.world;
    public static GameObject Cameras => Globals.Scene.cameras;
    public static CameraController Camera => GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
}
