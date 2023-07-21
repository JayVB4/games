using System.Linq;
using UnityEngine;
public class randombomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject[] items;
    int temp;
    int[] randomnum={-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            do
            {
                temp = Random.Range(0,items.Length);        
            }while(randomnum.Contains(temp));
            GameObject clone = Instantiate(bomb,items[temp].transform.position,Quaternion.identity);
            randomnum[i] = temp;
        }
    }
}
