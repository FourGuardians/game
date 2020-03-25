using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraBoundsController : MonoBehaviour
{
    [Header("Options")]
    public bool Enabled = true;
    public Grid Bounds;

    [Header("Camera")]
    public Vector2 NormalPosition = new Vector2(0, 0);

    [Header("Border")]
    public float BufferSpace = 1.0f;

    private PositionLock posLock;
    private Camera _camera;
    private Vector3 pos => _camera.transform.localPosition;

    public void Start()
    {
        posLock = GetComponent<PositionLock>();
        _camera = GetComponent<Camera>();
        
        if (!_camera.orthographic)
        {
            Debug.LogWarning("Camera must be orthographic to use with CameraBoundsController!");
            Destroy(this);
        }
    }

    public void Update()
    {
        if (!Enabled || Bounds == null || transform.parent == null)
        {
            posLock.LockX = false;
            posLock.LockY = false;

            return;
        }

        (posLock.LockX, posLock.LockY) = Detect(CameraBounds(_camera), GridBounds(Bounds));

        if (!posLock.LockX)
            _camera.transform.localPosition = new Vector3(NormalPosition.x, pos.y, pos.z);

        if (!posLock.LockY)
            _camera.transform.localPosition = new Vector3(pos.x, NormalPosition.y, pos.z);
    }
    
    private (bool, bool) Detect(Vector4 cb, Vector4 gb) =>
    (
        cb.x <= gb.x || cb.z >= gb.z,
        cb.w >= gb.w || cb.y <= gb.y
    );

    private Vector4 CameraBounds(Camera camera)
    {
        Vector2 v1 = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector2 v2 = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        float xl = (v2.x - v1.x) / 2;
        float yl = (v2.y - v1.y) / 2;

        float x = transform.parent.position.x;
        float y = transform.parent.position.y;

        return new Vector4(x - xl, y - yl, x + xl, y + yl);
    }

    private Vector4 GridBounds(Grid grid)
    {
        Tilemap[] tilemaps = grid.GetComponentsInChildren<Tilemap>();

        int x1 = int.MaxValue,
            y1 = int.MaxValue,
            x2 = int.MinValue,
            y2 = int.MinValue;

        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.CompressBounds();

            Vector3Int bounds = tilemap.size;
            Vector3Int origin = tilemap.origin;

            x1 = Mathf.Min(x1, origin.x);
            y1 = Mathf.Min(y1, origin.y);
            x2 = Mathf.Max(x2, origin.x + bounds.x);
            y2 = Mathf.Max(y2, origin.y + bounds.y);
        }

        return new Vector4(x1 - BufferSpace, y1 - BufferSpace, x2 + BufferSpace, y2 + BufferSpace);
    }
}