using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    // Text zetten
    // nieuwe bool aanmaken voor range upgrade  ( can upgrade )

    [SerializeField]
    Text UpgradeCounterTextDamage;
    [SerializeField]
    Text UpgradeCounterTextRange;

    ScoreHandler _ScoreHandler;
    EnemyHealth _EnemyHealth;
    Bullet _Bullet;

    int Upgrade_Gun_Damage_Level_Cap = 10;
    int Upgrade_Gun_Range_Level_Cap = 15;
    int Gun_Current_Damage_Level;
    int Gun_Current_Range_Level;

    bool canUpgrade = true;
    public int Bullet_Damage = 20;
    public float Bullet_Range = 0.40f;
    int UpgradePriceDamage;
    int UpgradePriceRange;

    void Start()
    {
        _ScoreHandler = gameObject.GetComponent<ScoreHandler>();
        
        _Bullet = gameObject.GetComponent<Bullet>();
    }

    void Update()
    {
        UpgradeCounterTextDamage.text = Gun_Current_Damage_Level.ToString() + " / " + Upgrade_Gun_Damage_Level_Cap.ToString();
        //_EnemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        if (Gun_Current_Damage_Level >= Upgrade_Gun_Damage_Level_Cap)
        {
            // disable further upgrade.
            canUpgrade = false;
        }
    }


    public void Upgrade_Gun_Damage()
    {
        // increase damage
        // first check if able to upgrade
        // if able to upgrade && if player have enough points
        // if player have enough points increase damage
        // increase Gun_Current_Level
        if(canUpgrade)
        {
            UpgradePriceDamage = 100;
            if (_ScoreHandler.Score >= 100)
            {
                //increase damage
                // increase upgrade level
                // withdraw points
                Bullet_Damage = Bullet_Damage + 5;
                Gun_Current_Damage_Level++;
                _ScoreHandler.Score -= UpgradePriceDamage;
                Debug.Log(Bullet_Damage);
            }
            else
            {
                // messange , not enough money OR max level for the upgrade.
                Debug.Log("Not Enough Points!" + Gun_Current_Damage_Level);
            }
        }
        else
        {
            Debug.Log("Upgrade Level Cap Reached!");
        }
    }

    public void Upgrade_Gun_Range()
    {
        if (canUpgrade)
        {

            UpgradePriceRange = 100;
            if (_ScoreHandler.Score >= 200)
            {
                Bullet_Range = Bullet_Range + 10f;
                Gun_Current_Range_Level++;
                _ScoreHandler.Score -= UpgradePriceRange;
                Debug.Log(Bullet_Range);
            }
            else
            {
                // geen geld
                Debug.Log("Not enough points!");
            }
        }
        else
        {
            // upgrade level cap reached
            Debug.Log("Upgrade Level Cap Reached!");
        }
    }

}