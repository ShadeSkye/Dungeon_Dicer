using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Dictionary<MapManager.Direction, int> _rotationByDirection = new()
    {
        { MapManager.Direction.North, 0 },
        { MapManager.Direction.East, 90 },
        { MapManager.Direction.South, 180 },
        { MapManager.Direction.West, 270 }
    };
    private MapManager.Direction _facingDirection;
    private bool _isRotating = false;

    //smooth rotation
    [SerializeField] private float RotationTime = 0.5f;
    private float _rotationTimer = 0.0f;
    private Quaternion _previousRotation;

    private RoomBase1 _currentRoom = null;

    [SerializeField] private float MovementTime = 2.0f;
    private bool _isMoving = false;
    private float _movementTimer = 0.0f;
    private Vector3 _previousPosition;
    private Vector3 _moveToPosition;
    internal bool _inCombat = false;

    private int baseATK = 10;
    private int maxHp = 50;
    public int damage;
    
    public void Setup()
    {
        MapManager.Direction[] directions = new MapManager.Direction[] { MapManager.Direction.North, MapManager.Direction.East, MapManager.Direction.South, MapManager.Direction.West };

        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];

        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        Vector3 facing = transform.rotation.eulerAngles;

        facing.y = _rotationByDirection[_facingDirection];

        transform.rotation = Quaternion.Euler(facing);
    }

    // Counterclockwise
    private void TurnLeft()
    {
        switch (_facingDirection)
        {
            case MapManager.Direction.South:
                _facingDirection = MapManager.Direction.East;
                break;
            case MapManager.Direction.North:
                _facingDirection = MapManager.Direction.West;
                break;
            case MapManager.Direction.East:
                _facingDirection = MapManager.Direction.North;
                break;
            case MapManager.Direction.West:
                _facingDirection = MapManager.Direction.South;
                break;
        }
        StartRotating();
    }

    // Clockwise
    private void TurnRight()
    {
        switch (_facingDirection)
        {
            case MapManager.Direction.South:
                _facingDirection = MapManager.Direction.West;
                break;
            case MapManager.Direction.North:
                _facingDirection = MapManager.Direction.East;
                break;
            case MapManager.Direction.East:
                _facingDirection = MapManager.Direction.South;
                break;
            case MapManager.Direction.West:
                _facingDirection = MapManager.Direction.North;
                break;
        }
        StartRotating();
    }

    private void StartRotating()
    {
        _previousRotation = transform.rotation;
        _isRotating = true;
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        _currentRoom = otherObject.GetComponent<RoomBase1>();
        _currentRoom.SetPlayerReference(this);
        _currentRoom.OnRoomEntered();
    }

    private void OnTriggerExit(Collider otherObject)
    {
        RoomBase1 exitingRoom = otherObject.GetComponent<RoomBase1>();
        exitingRoom.OnRoomExited();
    }

    void Update()
    {
        if (GameManager.GamePaused == false)
        {
            if (_inCombat)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("You defeated the enemy!");
                    _inCombat = false;
                }
            }
            else
            {
                if (_isMoving)
                {
                    Vector3 currentPosition = Vector3.Lerp(_previousPosition, _moveToPosition, _movementTimer / MovementTime);
                    transform.position = currentPosition;
                    _movementTimer += Time.deltaTime;
                    if (_movementTimer > MovementTime)
                    {
                        _isMoving = false;
                        _movementTimer = 0.0f;
                        transform.position = _moveToPosition; //snap to final position
                    }
                }
                else
                {
                    if (_isRotating)
                    {
                        //continue movement until finished
                        //quanternion.lerp for linear movement, quanternion.slerp for smoothed movement
                        Quaternion currentRotation = Quaternion.Slerp(_previousRotation, Quaternion.Euler(new Vector3(0, _rotationByDirection[_facingDirection])), _rotationTimer / RotationTime);

                        transform.rotation = currentRotation;

                        _rotationTimer += Time.deltaTime;
                        if (_rotationTimer > RotationTime)
                        {
                            _isRotating = false;
                            _rotationTimer = 0.0f;
                            SetFacingDirection(); //snap to final rotation
                        }
                    }
                    else
                    {
                        bool rotateLeft = Input.GetKeyDown(KeyCode.A);
                        bool rotateRight = Input.GetKeyDown(KeyCode.D);

                        if (rotateLeft && !rotateRight)
                        {
                            TurnLeft();
                        }
                        else if (rotateRight && !rotateLeft)
                        {
                            TurnRight();
                        }
                        else if (Input.GetKeyDown(KeyCode.Space))
                        {
                            if (_currentRoom != null)
                            {
                                _currentRoom.OnRoomSearched();
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.W))
                        {
                            RoomBase1 roomInFacingDirection = NextRoomInDirection();
                            if (roomInFacingDirection != null && _isMoving == false)
                            {
                                StartMovement(roomInFacingDirection);
                            }
                        }
                    }
                }
            }
        }
    }

    private void StartMovement(RoomBase1 targetRoom)
    {
        _previousPosition = transform.position;
        _moveToPosition = new Vector3(targetRoom.transform.position.x, 8, targetRoom.transform.position.z);
        _isMoving = true;
    }

    private RoomBase1 NextRoomInDirection()
    {
        if (_currentRoom == null)
            return null;

        switch (_facingDirection)
        {
            case MapManager.Direction.North:
                return _currentRoom.North;
            case MapManager.Direction.East:
                return _currentRoom.East;
            case MapManager.Direction.South:
                return _currentRoom.South;
            case MapManager.Direction.West:
                return _currentRoom.West;
            default:
                Debug.LogError("Error: Unknown Direction!");
                return null;
        }
    }
}
