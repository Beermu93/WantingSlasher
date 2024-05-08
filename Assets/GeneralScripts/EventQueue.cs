using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    private List<ICommand> currentCommands = new List<ICommand>();
    public static EventQueue Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    public void QueueCommand(ICommand command)
    {
        currentCommands.Add(command);
    }

    private void LateUpdate()
    {
        if (currentCommands.Count == 0)
        {
            return;
        }
        foreach (var command in currentCommands)
        {
            command.Execute();
        }
        currentCommands.Clear();
    }
}
