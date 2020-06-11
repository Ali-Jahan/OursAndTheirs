using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Random = UnityEngine.Random;

public class enemySpawn : MonoBehaviour
{
    public Vector2 initialSpeed;
    public float coolDown;
    public float coolDownReduceFactor = 1.1f;
    private float initialTime;
    public float rad = 5f;
    public GameObject prefab;
    
    void Start()
    {
        initialTime = Time.time;
    }
    Vector3 RandomCircle ( Vector3 center ,   float radius  ){
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    private void Update()
    {
        if (Time.time - initialTime > coolDown)
        {
            initialTime = Time.time;
            var center = transform.position;
            var pos = RandomCircle(center, rad);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
            var enemy = Instantiate(prefab, pos, rot);
            enemy.GetComponent<Rigidbody2D>().velocity = initialSpeed;
            coolDown /= coolDownReduceFactor;
        }
    }
}