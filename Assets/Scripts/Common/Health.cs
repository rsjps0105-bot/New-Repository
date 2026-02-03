using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHp = 5;
    int currentHp;

    [SerializeField] Text hpText;

    void Awake()
    {
        currentHp = maxHp;

        UpdateHPText();
    }

    public void AddMaxHp(int amount)
    {
        maxHp += amount;
        currentHp += amount;   // 最大HP増えた分、現在HPも回復
        UpdateHPText();
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = $"HP : {currentHp}";
        }
    }

    public void TakeDamage(int damage, DamageSource source)
    {
        currentHp -= damage;

        UpdateHPText();

        if (currentHp <= 0)
        {
            Die(source);
        }
    }

    void Die(DamageSource source)
    {
        GameManager.Instance.OnCharacterDead(this, source);

        if (CompareTag("Player"))
        {
            //操作や当たり判定だけ止める（必要なら）
            // GetComponent<PlayerMovement>()?.enabled = false;
            //GetComponent<Collider>()?.enabled = false;
            return;
        }

        Destroy(gameObject);
    }
}
