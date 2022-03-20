using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    public GameObject knife;
    public int range = 10000;
    public GameObject stuckKnife;
    public GameObject Log;
    public int KnifeAmount=10;
    public Canvas ContMenu;
    public Canvas EndMenu;

    public int score=0;
    public int apples=0;
    public int maxlevel;
    public int currlevel;

    public Animator KnifeThrow;
    private GameObject sknife;
    [SerializeField]
    Object destructuble;

    public Text scoreText;
    public Text ApplesText;
    public Text KnifeAmountText;
    public Text TotalScore;
    public Text MaxLevelText;

    public Button nextlevel;
    bool GameState = false;
    public Data data;
    private void Start()
    {
        Vibration.Init();
        data.LoadGame();
        maxlevel = PlayerPrefs.GetInt("MaxLevel",0);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& KnifeAmount>0)
        {
            KnifeThrow.SetTrigger("Play");
            shoot();
            KnifeAmount--;
        }
        if (KnifeAmount==0&& GameState == false)//условие победы
        {
            GameObject destruct = (GameObject)Instantiate(destructuble);
            destruct.transform.position = Log.transform.position;
            Destroy(Log);
            Debug.Log("You win");
            GameState = true;   
            currlevel++;
            data.SaveGame();
            ContMenu.gameObject.SetActive(true);
            Vibration.Vibrate();
        }
        KnifeAmountText.text = KnifeAmount.ToString()+"/10 Ќожей";
        scoreText.text = score.ToString();
        ApplesText.text = apples.ToString();
        MaxLevelText.text ="–екордный уровень "+ maxlevel;
    }
    void shoot()
    {

       RaycastHit2D hit = Physics2D.Raycast(knife.transform.position, Vector2.up);
        if (hit.collider!=null&& hit.collider.tag != "Knife"&& hit.collider.tag != "Apple")//попадание в дерево
        {
            sknife=Instantiate(stuckKnife, hit.point, Quaternion.Euler(0,0,-90),Log.transform);
            score++;
            Vibration.VibratePop();

        }
        else
        if (hit.collider.tag == "Apple" && hit.collider.tag != "Knife")//попадание в €блоко
        {
            GameObject sknife = Instantiate(stuckKnife, hit.point, Quaternion.Euler(0, 0, -90), Log.transform);
            sknife.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y+0.2f, 0);
            Vibration.VibratePop();
            apples++;
            score++;
        }
        else
        if (hit.collider.tag=="Knife") //попадание в ножик
        {
            Vibration.VibratePeek();
            TotalScore.text = "¬ы набрали " + score + " очков";
            EndMenu.gameObject.SetActive(true);
            score = 0;
            currlevel = 0;
            data.SaveGame();
        }
    }
}
