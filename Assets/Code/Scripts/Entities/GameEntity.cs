using Fg.Entities;
using GameAPI.Entities;
using UnityEngine;

public abstract class GameEntity : Entity2D, IInkHolder, IAnimatedEntity
{
    public int Ink { get; set; } = 20;
    public int MaxInk { get; set; } = 20;

    public Animator Animator { get; set; }

    public new void Start()
    {
        Animator = GetComponent<Animator>();

        base.Start();
    }

    public bool AnimIdle
    {
        get
        {
            return Animator.GetBool("Idle");
        }

        set
        {
            Animator.SetBool("Idle", value);
        }
    }

    public int AnimDirection
    {
        get
        {
            return Animator.GetInteger("Direction");
        }

        set
        {
            Animator.SetInteger("Direction", value);
        }
    }
}