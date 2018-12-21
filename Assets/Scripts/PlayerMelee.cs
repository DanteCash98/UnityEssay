using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public float damage;
    public float range;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) return;
        if (hit.distance < range)
        {
            hit.transform.SendMessage(("ApplyDamage"), damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
