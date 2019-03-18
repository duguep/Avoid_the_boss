using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class ViewPaper : MonoBehaviour
{
	
    public float m_MaxDistance = 300f;
    public bool m_HitDetect;

    int layerMask = 1 << 12;
    Collider m_Collider;
    RaycastHit m_Hit;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance, layerMask);
        if (m_HitDetect)
        {
            if (m_Hit.collider.gameObject.GetComponent<ObjectAction>().action)
            {
                print("Hit : " + m_Hit.collider.name);
                //Output the name of the Collider your Box hit
                Debug.Log("Hit : " + m_Hit.collider.name);
                PhotonView bla = m_Hit.collider.gameObject.GetComponent<PhotonView>();
                bla.Owner.SetScore(0);
                PhotonNetwork.Destroy(m_Hit.collider.transform.parent.gameObject
                    ? m_Hit.collider.transform.parent.gameObject
                    : m_Hit.collider.gameObject);
            }
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}
