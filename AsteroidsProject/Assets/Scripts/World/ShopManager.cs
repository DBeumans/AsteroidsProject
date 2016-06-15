using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    [SerializeField]
    Text UpgradeCounterText;

    ScoreHandler _ScoreHandler;
    EnemyHealth _EnemyHealth;
    Bullet _Bullet;

    int Upgrade_Gun_Level_Cap = 10;
    int Gun_Current_Level;

    bool canUpgrade = true;
    public int Bullet_Damage = 20;
    int UpgradePrice;

    void Start()
    {
        _ScoreHandler = gameObject.GetComponent<ScoreHandler>();
        
        _Bullet = gameObject.GetComponent<Bullet>();
    }

    void Update()
    {
        UpgradeCounterText.text = Gun_Current_Level.ToString() + " / " + Upgrade_Gun_Level_Cap.ToString();
        //_EnemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        if (Gun_Current_Level >= Upgrade_Gun_Level_Cap)
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
            UpgradePrice = 100;
            if(_ScoreHandler.Score >= 100)
            {
                //increase damage
                // increase upgrade level
                // withdraw points
                Bullet_Damage = Bullet_Damage + 5;
                Gun_Current_Level++;
                _ScoreHandler.Score -= 1;
                Debug.Log(Bullet_Damage);
            }
            else
            {
                // messange , not enough money OR max level for the upgrade.
                Debug.Log("Not Enough Points!" + Gun_Current_Level);
            }
        }
        else
        {
            Debug.Log("Upgrade Level Cap Reached!");
        }
    }

}