using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class randombomb : MonoBehaviour
{
    public GameObject box;
    public GameObject bomb;
    public TMP_Text txt;
    public GameObject[] items;
    public modeSO modedropdown;
    GameObject[] boxes;
    GameObject[] bombs;

    int temp;
    int mode=10;
    int[] grid = new int[100];
    int enabledcounter;
    void Start()
    {
        //initialize
        for (int i = 0; i < 100; i++)
        {
            grid[i] = 0;
        }
        mode = modedropdown.Value;
        mode = mode * 10;
        int[] randomnum = new int[mode];
        boxes = new GameObject[mode];
        bombs = new GameObject[mode];
        for (int i = 0; i < mode; i++)
        {
            randomnum[i]=-1;
        }
        //randomize
        for (int i = 0; i < mode; i++)
        {
            do
            {
            temp = Random.Range(0,items.Length);
            } while (randomnum.Contains(temp));
            GameObject clone = Instantiate(bomb,items[temp].transform.position,Quaternion.identity);
            GameObject clone2 = Instantiate(box,items[temp].transform.position,Quaternion.identity);
            boxes[i]=clone2;
            bombs[i]=clone;
            randomnum[i] = temp;
        }
        //number assignment
        for (int i = 0; i < 100; i++)
        {
            if(randomnum.Contains(i)){
                grid[i]=-20;
                // corners
                // upper right corner
                if (i == 0){
                    grid[(i+1)]++;
                    grid[(i+10)]++;
                    grid[(i+11)]++;
                }
                // upper left corner
                else if (i == 9){
                    grid[(i-1)]++;
                    grid[(i + 10)]++;
                    grid[(i + 9)]++;
                }
                // lower left corner
                else if (i == 99){
                    grid[(i - 1)]++;
                    grid[(i - 10)]++;
                    grid[(i - 11)]++;
                }
                // lower right corner
                else if (i == 90){
                    grid[(i + 1)]++;
                    grid[(i - 10)]++;
                    grid[(i - 9)]++;
                }
                //edges
                // right edge
                else if (i % 10 == 0){
                    grid[(i + 1)]++;
                    grid[(i + 10)]++;
                    grid[(i + 11)]++;
                    grid[(i - 9)]++;
                    grid[(i - 10)]++;
                }
                // left edge
                else if (i % 10 == 9){
                    grid[(i - 1)]++;
                    grid[(i - 10)]++;
                    grid[(i - 11)]++;
                    grid[(i + 9)]++;
                    grid[(i + 10)]++;
                }
                // upper edge
                else if (i > 0 && i < 9){
                    grid[(i + 1)]++;
                    grid[(i - 1)]++;
                    grid[(i + 11)]++;
                    grid[(i + 9)]++;
                    grid[(i + 10)]++;
                }
                // lower edge
                else if (i > 90 && i < 99){
                    grid[(i + 1)]++;
                    grid[(i - 1)]++;
                    grid[(i - 11)]++;
                    grid[(i - 9)]++;
                    grid[(i - 10)]++;
                }
                //middle number
                else{
                    grid[(i + 1)]++;
                    grid[(i - 1)]++;
                    grid[(i + 9)]++;
                    grid[(i + 10)]++;
                    grid[(i + 11)]++;
                    grid[(i - 9)]++;
                    grid[(i - 10)]++;
                    grid[(i - 11)]++;
                }

            }
        }
        
        //number placement
        for (int i = 0; i < 100; i++)
        {
            txt.text = grid[i].ToString();
            if (!(randomnum.Contains(i)))
            {
                Vector3 posvect = new Vector3(items[i].transform.position.x,-0.15F,items[i].transform.position.z);;
                TMP_Text clone = Instantiate(txt,posvect,txt.transform.rotation);
            }
        }
    }

    void Update()
    {
        enabledcounter=0;
        for (int i = 0; i < 100; i++)
        {

            if(!items[i].gameObject.activeSelf){
                //lose
                if(grid[i]<0){
                    for(int j=0;j<mode;j++){
                        boxes[j].gameObject.SetActive(true);
                        bombs[j].gameObject.SetActive(true);
                    }
                    Invoke("losescene",2f);
                }
                //zero clearance
                else if(grid[i]==0)
                {
                    if (i == 0){
                        items[(i+1)].gameObject.SetActive(false);
                        items[(i+10)].gameObject.SetActive(false);
                        items[(i+11)].gameObject.SetActive(false);
                    }
                    // upper left corner
                    else if (i == 9){
                        items[(i-1)].gameObject.SetActive(false);
                        items[(i + 10)].gameObject.SetActive(false);
                        items[(i + 9)].gameObject.SetActive(false);
                    }
                    // lower left corner
                    else if (i == 99){
                        items[(i - 1)].gameObject.SetActive(false);
                        items[(i - 10)].gameObject.SetActive(false);
                        items[(i - 11)].gameObject.SetActive(false);
                    }
                    // lower right corner
                    else if (i == 90){
                        items[(i + 1)].gameObject.SetActive(false);
                        items[(i - 10)].gameObject.SetActive(false);
                        items[(i - 9)].gameObject.SetActive(false);
                    }
                    //edges
                    // right edge
                    else if (i % 10 == 0){
                        items[(i + 1)].gameObject.SetActive(false);
                        items[(i + 10)].gameObject.SetActive(false);
                        items[(i + 11)].gameObject.SetActive(false);
                        items[(i - 9)].gameObject.SetActive(false);
                        items[(i - 10)].gameObject.SetActive(false);
                    }
                    // left edge
                    else if (i % 10 == 9){
                        items[(i - 1)].gameObject.SetActive(false);
                        items[(i - 10)].gameObject.SetActive(false);
                        items[(i - 11)].gameObject.SetActive(false);
                        items[(i + 9)].gameObject.SetActive(false);
                        items[(i + 10)].gameObject.SetActive(false);
                    }
                    // upper edge
                    else if (i > 0 && i < 9){
                        items[(i + 1)].gameObject.SetActive(false);
                        items[(i - 1)].gameObject.SetActive(false);
                        items[(i + 11)].gameObject.SetActive(false);
                        items[(i + 9)].gameObject.SetActive(false);
                        items[(i + 10)].gameObject.SetActive(false);
                    }
                    // lower edge
                    else if (i > 90 && i < 99){
                        items[(i + 1)].gameObject.SetActive(false);
                        items[(i - 1)].gameObject.SetActive(false);
                        items[(i - 11)].gameObject.SetActive(false);
                        items[(i - 9)].gameObject.SetActive(false);
                        items[(i - 10)].gameObject.SetActive(false);
                    }
                    //middle number
                    else{
                        items[(i + 1)].gameObject.SetActive(false);
                        items[(i - 1)].gameObject.SetActive(false);
                        items[(i + 9)].gameObject.SetActive(false);
                        items[(i + 10)].gameObject.SetActive(false);
                        items[(i + 11)].gameObject.SetActive(false);
                        items[(i - 9)].gameObject.SetActive(false);
                        items[(i - 10)].gameObject.SetActive(false);
                        items[(i - 11)].gameObject.SetActive(false);
                    }
                }   
            }
            else
            {
                enabledcounter++;
            }
        }
        //win
        if(enabledcounter==mode)
        {
            Invoke("winscene",1f);
        }
    }
    void winscene(){
        SceneManager.LoadScene("win");
    }
    void losescene(){
        SceneManager.LoadScene("lose");
    }
}
