using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalBall : MonoBehaviour, IThrowable
{
    [SerializeField] EnemyBallData originalData;
    public EnemyBallData runtimeData { get; private set; }

    float lastThrowTime = -999f;

    float timer = 0f;
    [SerializeField] float upgradeInterval = 10f;

    void Awake()
    {
        runtimeData = Instantiate(originalData);
    }

    public EnemyBallData RuntimeData => runtimeData;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= upgradeInterval)
        {
            EnemyUpgradeManager.Instance.ApplyEnemyUpgrade(this);
            timer = 0f;
        }
    }

    public List<UpgradeCard> AppliedUpgrades { get; private set; } = new List<UpgradeCard>();

    public void AddUpgrade(UpgradeCard card)
    {
        AppliedUpgrades.Add(card);
        card.Apply(RuntimeData);
    }

    bool CanThrow()
    {
        return Time.time >= lastThrowTime + runtimeData.coolTime;
    }

    public void Throw(Vector3 startPosition, Vector3 targetPosition)
    {
        if (!CanThrow()) return;

        const int MAX_SHOTS = 2 ;

        int totalShots = Mathf.Min(1 + runtimeData.extraHorizontalShots, MAX_SHOTS);
        int horizontalShots = totalShots - 1;

        for (int i = 0; i < totalShots; i++)
        {
            // ‰¡•ûŒü‚É­‚µ‚¸‚ÂL‚°‚é
            float angle = (i - horizontalShots * 0.5f) * 10f;

            Vector3 toTarget = targetPosition - startPosition;
            Vector3 rotatedDir = Quaternion.Euler(0, angle, 0) * toTarget;

            // •ú•¨ü‚Ì“ž’B“_
            Vector3 endPoint = startPosition + rotatedDir;

            // •ú•¨ü‰‘¬‚ðŒvŽZ
            Vector3 initialVelocity = CalculateBallisticVelocity(startPosition, endPoint);

            // ’e‚ð¶¬
            Rigidbody rb = Instantiate(runtimeData.ballPrefab, startPosition, Quaternion.identity);

            rb.linearVelocity = initialVelocity;

            rb.GetComponent<BallProjectile>()?.Initialize(runtimeData);
        }

        lastThrowTime = Time.time;
    }


    Vector3 CalculateBallisticVelocity(Vector3 start, Vector3 end)
    {
        Vector3 displacement = end - start;
        Vector3 horizontal = new Vector3(displacement.x, 0, displacement.z);

        float distance = horizontal.magnitude;
        float time = distance / runtimeData.baseSpeed;

        float gravity =
            Mathf.Abs(Physics.gravity.y * runtimeData.gravityScale);

        float verticalSpeed =
            (displacement.y / time) + (gravity * time * 0.5f);

        Vector3 velocity = horizontal.normalized * runtimeData.baseSpeed;
        velocity.y = verticalSpeed;

        return velocity;
    }
}
