using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.AI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class GibCorpse : MonoBehaviour
{
    Health m_Health;
    EnemyController m_EnemyController;
    EnemyMobile m_EnemyMobile;
    float totalDamage;
    [Tooltip("Amount of damage required to gib the corpse")]
    public float GibDamage = 80;
    // Start is called before the first frame update
    void Start()
    {
        m_Health = gameObject.GetComponentInParent<Health>();
        m_EnemyController = gameObject.GetComponentInParent<EnemyController>();
        m_EnemyMobile = gameObject.GetComponentInParent<EnemyMobile>();
        //DebugUtility.HandleErrorIfNullGetComponent<Health, EnemyController>(m_Health, this, gameObject);
        m_Health.OnDamagedCorpse += corpseHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void corpseHit(float damage)
    {
        print("Took damage "  + damage);
        totalDamage += damage;
        var vfxHit = Instantiate(m_EnemyController.DeathVfx, transform.position, Quaternion.identity);
        Destroy(vfxHit, 5f);

        if (totalDamage >= GibDamage)
        {
            var vfxDeath = Instantiate(m_EnemyController.DeathVfx, transform.position, Quaternion.identity);
            Destroy(vfxDeath, 5f);
            Destroy(transform.parent.gameObject);
        }
        //Destroy(gameObject);
    }
}
