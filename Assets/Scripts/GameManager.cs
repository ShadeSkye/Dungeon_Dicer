using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;
    [SerializeField] private GameManager _gameManager;
    
    private MapManager _gameMap;
    private PlayerController _playerController;

    public static bool GamePaused = false;
    
    public void Start()
    {
        GameManagerSetup();
    }

    public void GameManagerSetup()
    {
        Debug.Log("GameManager Start Begins");

        transform.position = Vector3.zero;

        SetupMap();
        SpawnPlayer();
        StartGame();

        Debug.Log("GameManager Start Complete");
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

        var spawnRoom = _gameMap._rooms.ElementAt(0);

        _playerController = Instantiate(PlayerPrefab, transform);

        _playerController.transform.position = new Vector3(spawnRoom.Key.x, 8f, spawnRoom.Key.z);

        _playerController.Setup();

        Debug.Log("GameManager SpawnPlayer Complete");


    }

    private void StartGame()
    {
        Debug.Log("GameManager StartGame Begins");
        Debug.Log("GameManager StartGame Complete");
    }

    public void ResumeGame()
    {
        GamePaused = false;
    }
} 
