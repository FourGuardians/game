using GameAPI.Navigation;
using UnityEngine;

public partial class Player : GameEntity
{
    [HideInInspector]
    public FillBar HealthBar;

    [HideInInspector]
    public FillBar InkBar;

    public new void Start()
    {
        base.Start();

        Speed = 2;
    }

    public new void Update()
    {
        base.Update();

        InkBar.MinValue = 0f;
        InkBar.MaxValue = MaxInk;
        InkBar.Target = Ink;

        HealthBar.MinValue = 0f;
        HealthBar.MaxValue = MaxHealth;
        HealthBar.Target = Health;
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        int keys =
            ((Input.GetKey(KeyCode.W) ? 1 : 0) << 3) +
            ((Input.GetKey(KeyCode.S) ? 1 : 0) << 2) +
            ((Input.GetKey(KeyCode.A) ? 1 : 0) << 1) +
            ((Input.GetKey(KeyCode.D) ? 1 : 0) << 0);

        (int, Vector3)[] controls = new [] {
            (0b1000, Direction.North),
            (0b1001, Direction.NorthEast),
            (0b0001, Direction.East),
            (0b0101, Direction.SouthEast),
            (0b0100, Direction.South),
            (0b0110, Direction.SouthWest),
            (0b0010, Direction.West),
            (0b1010, Direction.NorthWest)
        };

        for (int i = 0; i < controls.Length; i++)
        {
            var (key, direction) = controls[i];

            if (keys != key)
                continue;

            AnimIdle = false;
            AnimDirection = i;

            transform.position += direction * Speed * Time.deltaTime;
            return;
        }

        AnimIdle = true;
    }

    public void MountCamera()
    {
        Scene.Camera.Mount(this);

        Scene.Camera.transform.localPosition = new Vector3
        (
            0f,
            0f,
            Scene.Camera.transform.localPosition.z
        );

        Scene.Camera.GetComponent<CameraBoundsController>().Enabled = true;
    }

    public void UnmountCamera()
    {
        Scene.Camera.Unmount();
        Scene.Camera.GetComponent<CameraBoundsController>().Enabled = false;
    }

    public override void Destroy()
    {
        Destroy(HealthBar.gameObject);
        Destroy(InkBar.gameObject);

        ActivePlayer = null;
        ActivePlayerType = PlayerType.None;
        
        UnmountCamera();
        base.Destroy();
    }
}

public partial class Player
{
    public static Player ActivePlayer { get; set; }
    public static PlayerType ActivePlayerType { get; set; } = PlayerType.None;

    public static Player Summon(PlayerType type)
    {
    GameObject prefab = Resources.Load<GameObject>($"Players/{type}.prefab");
        PlayerMetadata meta = prefab.GetComponent<PlayerMetadata>();

        GameObject obj = Instantiate(prefab);
        obj.name = $"Player ({type})"; 

        Player player = obj.GetComponent<Player>();

        // Health
        player.HealthBar = Instantiate(meta.HealthBar);
        player.HealthBar.gameObject.name = $"Health ({type})";
        player.HealthBar.transform.SetParent(Scene.Canvas.Overlay.transform, false);

        // Ink
        player.InkBar = Instantiate(meta.InkBar);
        player.InkBar.gameObject.name = $"Ink ({type})";
        player.InkBar.transform.SetParent(Scene.Canvas.Overlay.transform, false);

        // Camera
        player.MountCamera();

        // Parent
        player.transform.SetParent(Scene.World.Entities.transform);

        ActivePlayer = player;
        ActivePlayerType = type;
        return player;
    }
}

public enum PlayerType
{
    Kierth,
    Konara,
    Naratir,
    Natar,

    None
}