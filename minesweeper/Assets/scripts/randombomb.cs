using UnityEngine;

public class randombomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject[] items;
    int randomnum;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            do
            {
                randomnum = Random.Range(0,items.Length);        
            }while(false);
            GameObject clone = Instantiate(bomb,items[randomnum].transform.position,Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
