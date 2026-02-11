using UnityEngine;

public class KeepObjects : MonoBehaviour
{
    private static KeepObjects keepThisObject;
    private void Awake()
    {
        if (keepThisObject == null)
        {
            keepThisObject = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
