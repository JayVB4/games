using System.Linq;
using UnityEngine;
using TMPro;

public class randombomb : MonoBehaviour
{
    public GameObject bomb;
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
                // corners
                // upper right corner
                if (i == 0){
                    if (!(randomnum.Contains(i+1))){
                        grid[(i+1)]++;
                    }
                    if (!(randomnum.Contains(i+10))){
                        grid[(i+10)]++;
                    }
                    if (!(randomnum.Contains(i+11))){
                        grid[(i+11)]++;
                    }
                }
                // upper left corner
                else if (i == 9){
                    if (!(randomnum.Contains(i-1))){
                        grid[(i-1)]++;
                    }
                    if (!(randomnum.Contains(i+10))){
                        grid[(i + 10)]++;
                    }
                    if (!(randomnum.Contains(i+9))){
                        grid[(i + 9)]++;
                    }
                }
                // lower left corner
                else if (i == 99){
                    if (!(randomnum.Contains(i-1))){
                        grid[(i - 1)]++;
                    }
                    if (!(randomnum.Contains(i-10))){
                        grid[(i - 10)]++;
                    }
                    if (!(randomnum.Contains(i-11))){
                        grid[(i - 11)]++;
                    }
                }
                // lower right corner
                else if (i == 90){
                    if (!(randomnum.Contains(i+1))){
                        grid[(i + 1)]++;
                    }
                    if (!(randomnum.Contains(i-10))){
                        grid[(i - 10)]++;
                    }
                    if (!(randomnum.Contains(i-9))){
                        grid[(i - 9)]++;
                    }
                }
                //edges
                // right edge
                else if (i % 10 == 0){
                    if (!(randomnum.Contains(i+1))){
                        grid[(i + 1)]++;
                    }
                    if (!(randomnum.Contains(i+10))){
                        grid[(i + 10)]++;
                    }
                    if (!(randomnum.Contains(i+11))){
                        grid[(i + 11)]++;
                    }
                    if (!(randomnum.Contains(i-9))){
                        grid[(i - 9)]++;
                    }
                    if (!(randomnum.Contains(i-10))){
                        grid[(i - 10)]++;
                    }
                }
                // left edge
                else if (i % 10 == 9){
                    if (!(randomnum.Contains(i-1))){
                        grid[(i - 1)]++;
                    }
                    if (!(randomnum.Contains(i-10))){
                        grid[(i - 10)]++;
                    }
                    if (!(randomnum.Contains(i-11))){
                        grid[(i - 11)]++;
                    }
                    if (!(randomnum.Contains(i+9))){
                        grid[(i + 9)]++;
                    }
                    if (!(randomnum.Contains(i+10))){
                        grid[(i + 10)]++;
                    }
                }
                // upper edge
                else if (i > 0 && i < 9){
                    if (!(randomnum.Contains(i+1))){
                        grid[(i + 1)]++;
                    }
                    if (!(randomnum.Contains(i-1))){
                        grid[(i - 1)]++;
                    }
                    if (!(randomnum.Contains(i+11))){
                        grid[(i + 11)]++;
                    }
                    if (!(randomnum.Contains(i+9))){
                        grid[(i + 9)]++;
                    }
                    if (!(randomnum.Contains(i+10))){
                        grid[(i + 10)]++;
                    }
                }
                // lower edge
                else if (i > 90 && i < 99){
                    if (!(randomnum.Contains(i+1))){
                        grid[(i + 1)]++;
                    }
                    if (!(randomnum.Contains(i-1))){
                        grid[(i - 1)]++;
                    }
                    if (!(randomnum.Contains(i-11))){
                        grid[(i - 11)]++;
                    }
                    if (!(randomnum.Contains(i-9))){
                        grid[(i - 9)]++;
                    }
                    if (!(randomnum.Contains(i-10))){
                        grid[(i - 10)]++;
                    }
                }
                //middle number
                else{
                    if (!(randomnum.Contains(i+1))){
                        grid[(i + 1)]++;
                    }
                    if (!(randomnum.Contains(i-1))){
                        grid[(i - 1)]++;
                    }
                    if (!(randomnum.Contains(i+9))){
                        grid[(i + 9)]++;
                    }
                    if (!(randomnum.Contains(i+10))){
                        grid[(i + 10)]++;
                    }
                    if (!(randomnum.Contains(i+11))){
                        grid[(i + 11)]++;
                    }
                    if (!(randomnum.Contains(i-9))){
                        grid[(i - 9)]++;
                    }
                    if (!(randomnum.Contains(i-10))){
                        grid[(i - 10)]++;
                    }
                    if (!(randomnum.Contains(i-11))){
                        grid[(i - 11)]++;
                    }
                }

            }
        }
        for (int i = 0; i < 100; i++)
        {
            t.text = grid[i].ToString();
            if (!(randomnum.Contains(i)))
            {
                Vector3 posvect = new Vector3(items[i].transform.position.x,-0.15F,items[i].transform.position.z);;
                TMP_Text clone = Instantiate(t,posvect,t.transform.rotation);
            }
        }

        for (int i = 0; i < 100; i++)
        {
            Debug.Log(grid[i]);
        }
    }
}
