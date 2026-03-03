using System;
using System.Collections.Generic;
using UnityEngine;

public class TestStateManager : MonoBehaviour
{
    [SerializeField]
    public List<TestStatesAndTransitions> serializableStateList = new List<TestStatesAndTransitions>();

    // Made from the Serializable List
    //private Dictionary<int, TestState_SO> statesDict;
    //private TestState_SO currentState;

    //private void Start()
    //{
    //    for (int i = 0; i < serializableStateList.Count; i++)
    //    {

    //    }
    //}
}

[Serializable]
public class TestStatesAndTransitions
{
    public TestState_SO state;
    public List<TestStateTransitions> transitionChecks;
}

[Serializable]
public class TestStateTransitions
{
    public TestState_SO nextState;
    public List<TestSTC_SO> transitionConditions;
}

[Serializable]
public class TestState_SO
{
    public int stateID;

    //List of parameter stats/data IDs
    public List<TestStateBehavior> behaviors;
}

[Serializable]
public class TestSTC_SO
{
    public int transitionCheckID;

    //List of parameter stats/data IDs
    public List<float> stcParameters;
}

[Serializable]
public class TestStateBehavior
{
    public int behaviorID;

    //List of parameter stats/data IDs
    public List<float> stcParameters;
}


