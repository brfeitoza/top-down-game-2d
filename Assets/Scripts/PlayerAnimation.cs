using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const int IDLE_ANIMATION = 0;
    private const int WALKING_ANIMATION = 1;
    private const int RUNNING_ANIMATION = 2;

    private Player player;
    private Animator anim;

    private bool isWalking
    {
        get { return player.direction.sqrMagnitude > 0; }
    }

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SetDirection();

        OnIdle();
        OnWalk();
        OnRun();
        OnRoll();
    }

    #region Movement

    void SetDirection()
    {
        bool isWalkingRight = player.direction.x > 0;
        if (isWalkingRight) transform.eulerAngles = new Vector2(0, 0);

        bool isWalkingLeft = player.direction.x < 0;
        if (isWalkingLeft) transform.eulerAngles = new Vector2(0, 180);
    }

    void OnIdle()
    {
        if (!isWalking)
        {
            anim.SetInteger("transition", IDLE_ANIMATION);
        }
    }

    void OnWalk()
    {
        if (isWalking)
        {
            anim.SetInteger("transition", WALKING_ANIMATION);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", RUNNING_ANIMATION);
        }
    }

    void OnRoll()
    {
        if (isWalking && player.isRolling)
        {
            anim.SetTrigger("isRolling");
        }
    }

    #endregion
}

