using UnityEngine;

public class RunManager : MonoBehaviour
{
    private float maxHeightReached = 0;

    public bool hasLaunched { get; private set; } = false;
    public bool hasLanded { get; private set; } = false;

    public void SetHasLaunched()
    {
        hasLaunched = true;
    }

    public void SetHasLanded()
    {
        if (hasLaunched)
        {
            hasLanded = true;
        }
    }


}
