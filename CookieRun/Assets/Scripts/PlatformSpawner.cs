using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private GameObject[] platforms;

    private int currentIndex;
    private int nextIndex;

    private void Awake()
    {
        platforms = new GameObject[prefabs.Length];

        for (int i = 0; i < prefabs.Length; i++)
        {
            platforms[i] = Instantiate(prefabs[i], transform.position, transform.rotation);
            platforms[i].SetActive(false);
        }
    }

    void Start()
    {
        nextIndex = Random.Range(0, platforms.Length);

        platforms[nextIndex].SetActive(true);
        currentIndex = nextIndex;
    }

    void Update()
    {        
        if (platforms[currentIndex].transform.position.x < 0)
        {
            if (platforms[currentIndex].transform.position.x < -20.48f)
            {
                platforms[currentIndex].SetActive(false);

                platforms[currentIndex].transform.position = transform.position;
                currentIndex = nextIndex;
            }

            else
            {
                while (currentIndex == nextIndex)
                {
                    nextIndex = Random.Range(0, platforms.Length);
                }

                platforms[nextIndex].SetActive(true);
            }
        }
    }
}
