using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase1
{
    [SerializeField] private GameObject[] Enemies;

    Vector3 roomCoords;
    private bool enemyHere = true;
    public GameObject EnemyInstance;

    public void Awake()
    {
        EnemyInstance = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform);
        EnemyInstance.transform.position = new Vector3(roomCoords.x, 4.2f, roomCoords.y);
    }

    public new void SetRoomLocation(Vector3 coordinates)
    {
        roomCoords = coordinates;
    }

    public override void OnRoomEntered()
    {
        if (enemyHere)
        {
            CombatManager.Instance.StartCombat(EnemyInstance);
        }
    }

    public override void OnRoomExited()
    {
        enemyHere = false;
    }

    public override void OnRoomSearched()
    {
        
    }
}
