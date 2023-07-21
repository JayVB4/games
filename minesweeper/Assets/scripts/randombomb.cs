using System.Linq;
using UnityEngine;
using TMPro;

public class randombomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject txt;
    public TMP_Text t;
    public GameObject[] items;
    int temp;
    int[] grid = new int[100];
    int[] randomnum = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            grid[i] = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            do
            {
                temp = Random.Range(0, items.Length);
            } while (randomnum.Contains(temp));
            GameObject clone = Instantiate(bomb,items[temp].transform.position,Quaternion.identity);
            randomnum[i] = temp;
        }
        for (int i = 0; i < 100; i++)
        {
            if(randomnum.Contains(i)){
                grid[i+1]++;
            }
        }
        for (int i = 0; i < 100; i++)
        {
            t.text = grid[i].ToString();
            if (!(randomnum.Contains(i)))
            {
                GameObject clone = Instantiate(txt,items[i].transform.position,txt.transform.rotation);
            }
        }
    }
}
