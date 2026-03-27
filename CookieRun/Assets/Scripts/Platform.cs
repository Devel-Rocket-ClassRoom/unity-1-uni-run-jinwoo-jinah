using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] coins;
   
    private void OnEnable()
    {
        foreach (var co in coins)
        {
            co.SetActive(true);
        }
    }
}
