using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase1
{
    [SerializeField] private GameObject[] Enemies;

  
    Vector3 roomCoords;
    private bool enemyHere = true;

    public void Awake()
    {
        var enemyInstance = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform);
        enemyInstance.transform.position = new Vector3(roomCoords.x, 7, roomCoords.y);
    }

    public new void SetRoomLocation(Vector3 coordinates)
    {
        roomCoords = coordinates;
    }

    public override void OnRoomEntered()
    {
        Debug.Log("an enemy is here!");
        if (enemyHere)
        {
            StartCombat();
        }
    }

    public override void OnRoomSearched()
    {
        
    }

    private void StartCombat()
    {
        _playerController._inCombat = true;
    }
}
