using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHybridController : MonoBehaviour
{

    public GameObject Character;    //TODO: Get character
    Transform CharacterOriginalTransform;

    KeyCode SpaceBar, KeyForward, KeyLeft, KeyReverse, KeyRight;
    public static List<Command> OldCommands;
    HybridCommand CurrentCommand;

    public static bool ShouldStartReplay;
    private Coroutine ReplayCoroutine;
    private static bool ReplayMode;

    // Use this for initialization
    void Start()
    {
        OldCommands = new List<Command>();

        SpaceBar = KeyCode.Space;

        KeyForward = KeyCode.W;
        KeyLeft = KeyCode.A;
        KeyReverse = KeyCode.S;
        KeyRight = KeyCode.D;

        ReplayMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ReplayMode)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Vector2 movementDirection = Vector2.zero;
        if (Input.GetKey(KeyForward))
        {
            CurrentCommand = MakeCommand<HybridMoveCommands>();
            movementDirection.x += 0.1f;
        }
        if (Input.GetKey(KeyLeft))
        {
            CurrentCommand = MakeCommand<HybridMoveCommands>();
            movementDirection.y += 0.1f;
        }
        if (Input.GetKey(KeyReverse))
        {
            CurrentCommand = MakeCommand<HybridMoveCommands>();
            //SetCurrentCommandToType (typeof(HybridMoveCommands));
            movementDirection.x += -0.1f;
        }
        if (Input.GetKey(KeyRight))
        {
            CurrentCommand = MakeCommand<HybridMoveCommands>();
            //SetCurrentCommandToType (typeof(HybridMoveCommands));
            movementDirection.y += -0.1f;
        }

        HybridBaseState state = null;

        if (CurrentCommand != null)
            state = CurrentCommand.Execute(Character, CurrentCommand);
        //TODO: Change this to be a generic type of command it takes
        if (state != null)
            state.HandleInput(Character, movementDirection);

        CurrentCommand = null;
    }

    public void ChangeCommandKeyBind(KeyCode key, HybridCommand command)
    {
        //switch with KeyCodes, then set appropriately 
    }

    public static void AddCommandToReplayList(HybridCommand command)
    {
        if (!ReplayMode)
        {
            //OldCommands.Add(command);
        }
    }

    T MakeCommand<T>()
    {
        return (T)Activator.CreateInstance(typeof(T));
    }
}

