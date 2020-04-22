using GameAPI.Entities;
using UnityEngine;

public class TestEnemy : Enemy
{
    public new void Update()
    {
        base.Update();

        Player player = Nearest<Player>();

        if (player == null || !IsAt(player))
            return;

        player.Health -= Damage;
    }
}