using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockEnemy : MonoBehaviour
{
    public GameObject electricity;
    private List<GameObject> enemyObjects;
    public float enemyDistance;
    private GameObject[] enemies;
    public GameObject lamp;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (var g in enemies)
        {
            var distance = Vector2.Distance(transform.position,
                g.transform.position);
            if (distance <= enemyDistance)
            {
                GameObject e = null;
                if (Input.GetKey(KeyCode.G))
                {
                    if (!g.GetComponent<attackPlayer>().tagged)
                    {
                        e = Instantiate(electricity, lamp.transform.position,
                            Quaternion.identity);
                        e.GetComponent<shock>().lamp = lamp;
                        e.GetComponent<shock>().setTarget(g.gameObject);
                        g.GetComponent<attackPlayer>().tagged = true;
                    }
                    
                    // e.GetComponent<shock>().enabled = true;
                    // e.GetComponent<shock>().target = g.gameObject;
                }
                
            }
        }
    }
}
