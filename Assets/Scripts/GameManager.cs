using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;

    private MapManager _gameMap;
    private PlayerController _playerController;


    public void Start()
    {
        Debug.Log("GameManager Start Begins");

        transform.position = Vector3.zero;

        SetupMap();
        SpawnPlayer();
        StartGame();

        Debug.Log("GameManager Start Complete");

        StartGame();
    }

    private void SetupMap()
    {
        Debug.Log("GameManager SetupMap Begins");

        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;

        _gameMap.CreateMap();
        Debug.Log("GameManager Setup Complete");
    }

    private void SpawnPlayer()
    {
        Debug.Log("GameManager SpawnPlayer Begins");

        var randomStartingRoom = _gameMap._rooms.ElementAt(Random.Range(0, _gameMap._rooms.Keys.Count));

        _playerController = Instantiate(PlayerPrefab, transform);

        _playerController.transform.position = new Vector3(randomStartingRoom.Key.x, 4f, randomStartingRoom.Key.z);

        _playerController.Setup();

        Debug.Log("GameManager SpawnPlayer Complete");


    }

    private void StartGame()
    {
        Debug.Log("GameManager StartGame Begins");
        Debug.Log("GameManager StartGame Complete");
    }
} 
