using UnityEngine;

public class TestComponent : MonoBehaviour
{
    public TestInterface testInterface;

    private void Start()
    {
        testInterface = GetComponent<TestInterface>();
        Debug.Log(testInterface.ToString());
    }
}
