using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum PlatformState { Idle, Moving, None }

    [Header("States")]
    public PlatformState initialState = PlatformState.Idle;

    [ReadOnly]
    public PlatformState currentState = PlatformState.None,
    nextState = PlatformState.None,
    previousState = PlatformState.None;

    [Header("Movement"), SerializeField]
    float moveSpeed;

    [SerializeField]
    bool loop;

    [SerializeField]
    TravelPoint[] points;

    TravelPoint currentPoint;

    [SerializeField, ReadOnly]
    int pointIndex = 0;

    [Header("Idling"), SerializeField]
    float idleTime = 3f;
    [SerializeField, ReadOnly]
    float idle;

    MeshRenderer meshRenderer;

    [Header("Colors")]
    public Color idleColor;
    public Color movingColor;
    public Color occupiedColor;
    public Color inactiveColor;

    bool isOccupied;
    bool isReverse;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        ChangeStates(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdateState(currentState);
    }

    void FixedUpdate()
    {
        OnFixedUpdateState(currentState);
    }

    void LateUpdate()
    {
        OnLateUpdateState(currentState);
    }


#pragma warning disable IDE0060

    #region Methods

    public bool IsStateNone(PlatformState state) { return state == PlatformState.None; }

    void ChooseNextPoint()
    {
        currentPoint = points[pointIndex];

        if (isReverse)
        {
            pointIndex--;
        }
        else
        {
            pointIndex++;
        }

        if (pointIndex >= points.Length)
        {
            pointIndex -= 2;
            isReverse = true;
        }
        else if (pointIndex < 0)
        {
            pointIndex = 1;
            isReverse = false;
        }
    }

    public void SetIsOccupied(bool value)
    {
        isOccupied = value;
        UpdateColor(currentState);
    }

    void UpdateColor(PlatformState state)
    {
        switch (state)
        {
            case PlatformState.Idle:
                SetRenderColor(idleColor);
                break;
            case PlatformState.Moving:
                if (isOccupied)
                {
                    SetRenderColor(occupiedColor);
                }
                else
                    SetRenderColor(movingColor);
                break;
            case PlatformState.None:
                SetRenderColor(inactiveColor);
                break;
            default:
                break;
        }
    }

    public void ChangeStates(PlatformState newState)
    {
        if (currentState == newState && newState != PlatformState.None) { return; }

        nextState = newState;

        OnExitState(currentState);
        previousState = currentState;
        currentState = nextState;
        OnEnterState(nextState);
    }

    public void ChangeStates(int newState)
    {
        if (currentState == (PlatformState)newState && (PlatformState)newState != PlatformState.None) { return; }

        nextState = (PlatformState)newState;

        OnExitState(currentState);
        previousState = currentState;
        currentState = nextState;
        OnEnterState(nextState);
    }

    void OnExitState(PlatformState state)
    {
        switch (state)
        {
            case PlatformState.Idle:
                break;
            case PlatformState.Moving:
                break;
            case PlatformState.None:
                break;
            default:
                break;
        }
    }

    void OnEnterState(PlatformState state)
    {
        switch (state)
        {
            case PlatformState.Idle:
                idle = idleTime;
                break;
            case PlatformState.Moving:
                ChooseNextPoint();
                break;
            case PlatformState.None:
                break;
            default:
                break;
        }

        UpdateColor(state);
    }

    void OnUpdateState(PlatformState state)
    {
        switch (state)
        {
            case PlatformState.Idle:
                if (idle > 0)
                    idle -= Time.deltaTime;

                if (idle <= 0)
                    ChangeStates(PlatformState.Moving);
                break;
            case PlatformState.Moving:
                if (currentPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);
                    var distance = Vector3.Distance(transform.position, currentPoint.transform.position);
                    if (distance < 0.1f)
                    {
                        ChangeStates(PlatformState.Idle);
                    }
                }
                break;
            case PlatformState.None:
                break;
            default:
                break;
        }
    }

    void OnFixedUpdateState(PlatformState state)
    {
        switch (state)
        {
            case PlatformState.Idle:
                break;
            case PlatformState.Moving:
                break;
            case PlatformState.None:
                break;
            default:
                break;
        }
    }

    void OnLateUpdateState(PlatformState state)
    {
        switch (state)
        {
            case PlatformState.Idle:
                break;
            case PlatformState.Moving:
                break;
            case PlatformState.None:
                break;
            default:
                break;
        }
    }

    void SetRenderColor(Color color)
    {
        if (meshRenderer)
        {
            meshRenderer.material.color = color;
        }
    }
    #endregion

}
