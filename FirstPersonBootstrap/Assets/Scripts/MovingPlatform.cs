using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum PlatformState { Idle, Moving, None }

    public PlatformState currentState = PlatformState.Idle;

    [ReadOnly]
    public PlatformState nextState = PlatformState.None, previousState = PlatformState.None;

    // Start is called before the first frame update
    void Start()
    {
        print(IsStateNone(nextState));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsStateNone(PlatformState state) { return state == PlatformState.None; }

    public void ChangeStates(PlatformState newState)
    {
        if (currentState == newState) { return; }

        nextState = newState;

        OnExitState(currentState);
    }

    void OnExitState(PlatformState state)
    {
        switch (state)
        {
            // TODO: Finish implementation
        }
    }
}
