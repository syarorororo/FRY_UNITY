using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("探索グループ")]
    GameObject patrolArea;

    [SerializeField]
    [Tooltip("はじめに探索する地点")]
    int destpoint = 0;

    [SerializeField, Range(0, 100)]
    [Tooltip("探索範囲")]
    float trackingRange = 3.0f;

    [SerializeField,Range(0,150)]
    [Tooltip("追跡範囲")]
    float quitRange = 5f;

    [SerializeField,Range(0,25)]
    [Tooltip("敵のスピード")]
    float speed = 5.0f;

    private List<Transform> points = new List<Transform>();
    private bool tracking = false;
    private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        target = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
