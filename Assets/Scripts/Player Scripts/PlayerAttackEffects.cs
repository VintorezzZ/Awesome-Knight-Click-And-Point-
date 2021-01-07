using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject groundImpact_Spawn, kickFX_Spawn, fireTornado_Spawn, fireShield_Spawn;

    public GameObject groundImpact_Prefab,
        kickFX_Prefab,
        fireTornado_Prefab,
        fireShield_Prefab,
        healFX_Prefab,
        thunderFX_Prefab;
  
    void GroundImpact()
    {
        Instantiate(groundImpact_Prefab, groundImpact_Spawn.transform.position, Quaternion.identity);
    }

    void Kick()
    {
        Instantiate(kickFX_Prefab, kickFX_Spawn.transform.position, Quaternion.identity);
    }

    void FireTornado()
    {
        Instantiate(fireTornado_Prefab, fireTornado_Spawn.transform.position, Quaternion.identity);
    }

    void FireShield()
    {
        GameObject fireShield =
            Instantiate(fireShield_Prefab, fireShield_Spawn.transform.position, Quaternion.identity);
        
        fireShield.transform.SetParent(transform);
    }

    void Heal()
    {
        Vector3 temp = transform.position;
        temp.y += 2f;
        GameObject healObj = Instantiate(healFX_Prefab, temp, Quaternion.identity);
        healObj.transform.SetParent(transform);
    }

    void ThunderAttack()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 targetPos = Vector3.zero;
            
            var currPos = transform.position;
            
            if (i == 0)
            {
                targetPos = new Vector3(currPos.x - 4f, currPos.y + 2f, currPos.z);
            }
            else if (i == 1)
            {
                targetPos = new Vector3(currPos.x + 4f, currPos.y + 2f, currPos.z);
            }
            else if (i == 2)
            {
                targetPos = new Vector3(currPos.x, currPos.y + 2f, currPos.z - 4f);
            }
            else if (i == 3)
            {
                targetPos = new Vector3(currPos.x, currPos.y + 2f, currPos.z + 4f);
            }
            else if (i == 4)
            {
                targetPos = new Vector3(currPos.x + 2.5f, currPos.y + 2f, currPos.z + 2.5f);
            }
            else if (i == 5)
            {
                targetPos = new Vector3(currPos.x - 2.5f, currPos.y + 2f, currPos.z + 2.5f);
            }
            else if (i == 6)
            {
                targetPos = new Vector3(currPos.x - 2.5f, currPos.y + 2f, currPos.z - 2.5f);
            }
            else if (i == 7)
            {
                targetPos = new Vector3(currPos.x + 2.5f, currPos.y + 2f, currPos.z + 2.5f);
            }
            
            Instantiate(thunderFX_Prefab, targetPos, Quaternion.identity);
        }
    }
}
