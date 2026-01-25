using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    Transform target;

    [SerializeField] Transform holdPoint;
    [SerializeField] MonoBehaviour ballBehaviour;
    [SerializeField] float startDelay = 2f;

    float spawnTime;

    IThrowable ball;

    Animator anim;

    void Start()
    {
        spawnTime = Time.time;

        target = GameObject.FindGameObjectWithTag("Player")?.transform;

        ball = ballBehaviour as IThrowable;

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Time.time - spawnTime < startDelay) return;
        if (target == null) return;

        anim.SetTrigger("Throw");

        ball.Throw(
            holdPoint.position,
            target.position
        );
    }
}
