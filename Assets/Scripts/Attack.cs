///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    PhotonView view;
    ElementiaPlayer p1, p2;
    ElementiaMonster p1AttackMonster, p2AttackMonster;

    private void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        p2 = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<ElementiaPlayer>();
        p1AttackMonster = p1.AttackMonster;
        p2AttackMonster = p2.AttackMonster;
        view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
    }

    public void AttactBtnPressed()
    {
        // if game is paused, do nothing
        if (SettingMenuController.Instance.IsGamePause)
            return;

        // both player play animation
        view.RPC("playAttackAnimation", PhotonTargets.All, p1AttackMonster.Name);

        // caculate the attact value and send to fight menu controller
        float attackValue = ElementiaDamageFunction(p1AttackMonster, p2AttackMonster);

        // after 1 second float attact value 
        StartCoroutine(waitSeconds(1, attackValue));
    }

    IEnumerator waitSeconds(float waitTime, float attackValue)
    {
        yield return new WaitForSeconds(waitTime);
        // float attact value
        getDamage(p2.AttackMonster, (int)attackValue);

        //reduce hp for player one, and synchronize hp for player two
        FightMenuController.Instance.reducePlayerTwoHp((int)attackValue);
        view.RPC("reducePlayerOneHp", PhotonTargets.Others, (int)attackValue);

        // end this round for player one, and start round for player two
        FightMenuController.Instance.IsMyTurn = false;
        view.RPC("changePlayerRound", PhotonTargets.Others, true);
    }

    // reduce the player two hp and synchronize this action after attact
    void getDamage(ElementiaMonster monster, int amount)
    {
        if (amount > 0) // if attact not missed
        {
            // play hit animation
            GameObject.FindGameObjectWithTag(monster.Name).GetComponent<Animator>().Play("Hit");
            // synchronize for player two
            view.RPC("playHitAnimation", PhotonTargets.Others, monster.Name);

            // float attack value
            FloatingTextController.CreateFloatingText(monster, amount.ToString());
            // synchronize attack value for player two
            view.RPC("floatAttackValue", PhotonTargets.Others, amount.ToString());
        }
        // miss attact
        if (amount == 0)
        {
            // float miss text
            FloatingTextController.CreateFloatingText(monster, "Miss");

            // synchronize miss text for player two
            view.RPC("floatAttackValue", PhotonTargets.Others, "miss");
        }
    }

    /// <summary>
    /// Hit function
    /// </summary>
    /// <returns>Whether the attack hits the other player </returns>
    /// <param name="evasiveness">Evasiveness value (int) </param>
    static bool Hit(int evasiveness)
    {
        System.Random r = new System.Random();
        if (r.NextDouble() < (evasiveness / 100f))
            return false;
        return true;
    }

    /// <summary>
    /// Get the Elemental Damage Coeffient
    /// </summary>
    /// <returns>The damage coeffient in float between 0.5 to 1.5 </returns>
    /// <param name="attMonst">Monster, who attack</param>
    /// <param name="defMonst">Monster, who defend</param>
    static float ElmentialDamageCoeffient(ElementiaMonster attMonst, ElementiaMonster defMonst)
    {
        float dmgCoeffient = 0;
        // Fire attacks
        if (attMonst.Type == ElementiaMonsterTypes.Fire)
        {
            if (defMonst.Type == ElementiaMonsterTypes.Earth)
                dmgCoeffient = 1.5f;
            else if (defMonst.Type == ElementiaMonsterTypes.Water)
                dmgCoeffient = 0.5f;
            else if (defMonst.Type == ElementiaMonsterTypes.Air)
                dmgCoeffient = 1.0f;
            else if (defMonst.Type == ElementiaMonsterTypes.Fire)
                dmgCoeffient = 1.0f;
        }

        // Water attacks
        if (attMonst.Type == ElementiaMonsterTypes.Water)
        {
            if (defMonst.Type == ElementiaMonsterTypes.Fire)
                dmgCoeffient = 1.5f;
            else if (defMonst.Type == ElementiaMonsterTypes.Air)
                dmgCoeffient = 0.5f;
            else if (defMonst.Type == ElementiaMonsterTypes.Earth)
                dmgCoeffient = 1.0f;
            else if (defMonst.Type == ElementiaMonsterTypes.Water)
                dmgCoeffient = 1.0f;
        }

        // Earth attacks
        if (attMonst.Type == ElementiaMonsterTypes.Earth)
        {
            if (defMonst.Type == ElementiaMonsterTypes.Air)
                dmgCoeffient = 1.5f;
            else if (defMonst.Type == ElementiaMonsterTypes.Fire)
                dmgCoeffient = 0.5f;
            else if (defMonst.Type == ElementiaMonsterTypes.Water)
                dmgCoeffient = 1.0f;
            else if (defMonst.Type == ElementiaMonsterTypes.Earth)
                dmgCoeffient = 1.0f;
        }

        // Air attacks
        if (attMonst.Type == ElementiaMonsterTypes.Air)
        {
            if (defMonst.Type == ElementiaMonsterTypes.Water)
                dmgCoeffient = 1.3f;
            else if (defMonst.Type == ElementiaMonsterTypes.Earth)
                dmgCoeffient = 1.4f;
            else if (defMonst.Type == ElementiaMonsterTypes.Fire)
                dmgCoeffient = 1.0f;
            else if (defMonst.Type == ElementiaMonsterTypes.Air)
                dmgCoeffient = 1.0f;
        }
        return dmgCoeffient;
    }

    /// <summary>
    /// The main attact function
    /// </summary>
    /// <returns>Damage Value</returns>
    /// <param name="attMonst">Attack Monster</param>
    /// <param name="defMonst">Defend Monster</param>
    public static float ElementiaDamageFunction(ElementiaMonster attMonst, ElementiaMonster defMonst)
    {
        bool hit = Hit(defMonst.Evasiveness);
        if (!hit)
            return 0f;
        System.Random r = new System.Random();
        float elm = ElmentialDamageCoeffient(attMonst, defMonst);
        double critical = 0.65 * r.NextDouble() + 0.95;
        //Debug.Log("critical= " + critical);
        return (attMonst.Attact - defMonst.Defense) * elm * (float)critical;
    }
}
