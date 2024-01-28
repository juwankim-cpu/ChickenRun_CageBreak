using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public enum PLAYERSTATE
    {
        IDLE = 0,
        JUMP,
        DOWN,
        HIT,
        SLIDE
    }

    public Rigidbody pc;
    public hpBarTimer hpBar;
    public PLAYERSTATE playerState;
    public GameObject dataManager;
    public DataManager dataMgr;
    public GameMgr gameMgr;
    public GameObject hitFX;
    public GameObject boostFX;
    public GameObject[] fxPrefab;
    
    
    

    public bool isSlide = false;
    public bool isHit = false;
    public float jumpPower = 5f;
    public float hitCurTime;

    public float score;
    public float bestScore=0;
    public int coinCnt;
    public int goldenEggCnt;
    public Text scoreText;
    
    
    public int coinAmount = 0;
    public int goldEggAmount = 0;
    public Text coinText;
    public Text goldEggText;
    public float hp;
    public float maxHp = 100;
    public int lv=1;
    public float maxExp;

    public bool isBooster = false;
    public bool isGod = false;
    public float boosterCurTime;
    public float boosterCoolTime = 8f;

    public Transform cameraPos;
    public Vector3 cameraOrigin;
    public float shakeTime;


    int jumpCnt;
    int maxJumpCnt = 2;
    public Animator playerAnim;
    //public Button jumpBtn;

    public void Start()
    {
        
        score = 0;
        dataManager = GameObject.Find("DataManager");
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        dataMgr = dataManager.GetComponent<DataManager>();
        lv = dataMgr.Lv;
        maxExp = dataMgr.MaxExp;
        maxHp = dataMgr.MaxHp;
        hp = maxHp;
        playerAnim = GetComponentInChildren<Animator>();
        
        coinAmount = PlayerPrefs.GetInt("Coin");
        goldEggAmount = PlayerPrefs.GetInt("GoldEgg" );

        scoreText = GameObject.Find("ScoreTxt").GetComponent<Text>();
       
        coinText = GameObject.Find("CoinTxt").GetComponent<Text>();
        goldEggText = GameObject.Find("GoldEggTxt").GetComponent<Text>();
        

        Debug.Log(coinAmount);
        Debug.Log(goldEggAmount);

        

    }
    // Update is called once per frame
    void Update()
    {
        
        coinText.text = coinCnt.ToString();
        goldEggText.text = goldenEggCnt.ToString();

        if (isBooster == true)
        {
            isGod = true;
            Time.timeScale = 2.4f;
            boosterCurTime += Time.deltaTime;
            
            if (boosterCurTime > boosterCoolTime)
            {
                boosterCurTime = 0;
                isBooster = false;

                Time.timeScale = 1f;
                isGod = false;
                
                gameObject.tag = "Player";
                
            }
        }
        boostFX.SetActive(isGod);
    }

    
    public void Jump()
    {
        

        if (jumpCnt < 2)
        {
            playerAnim.SetInteger("PLAYERSTATE", 1);
            pc.velocity = Vector3.zero;
            pc.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            GetComponent<BoxCollider>().center = new Vector3(0, 0.4f, 0);
            GetComponent<BoxCollider>().size = new Vector3(1, 0.9f, 0);
            jumpCnt++;
        }
        SFXManager.instance.PlaySFX("Jump");
    }
    public void SlideDown()
    {
        isSlide = true;
        playerAnim.SetInteger("PLAYERSTATE", 2);
        playerAnim.SetBool("ISSLIDE", true);
        GetComponent<BoxCollider>().size = new Vector3(0, 0.4f, 0);
        GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        SFXManager.instance.PlaySFX("Slide");
    }

    public void SlideUp()
    {
        isSlide = false;
        playerAnim.SetInteger("PLAYERSTATE", 0);
        playerAnim.SetBool("ISSLIDE", false);
        GetComponent<BoxCollider>().size = new Vector3(1, 1.3f, 0);
        GetComponent<BoxCollider>().center = new Vector3(0, 0.4f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                jumpCnt = 0;
                playerAnim.SetInteger("PLAYERSTATE", 0);
                GetComponent<BoxCollider>().size = new Vector3(1, 1.3f, 0);

                break;
            default:
                break;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Obstacle" && isGod == false)
        {
            hp -= 10f;
            gameObject.layer = 7;
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 0.4f);
            
            playerAnim.SetInteger("PLAYERSTATE", 3);

            isHit = true;
            Instantiate(hitFX, transform.position, transform.rotation);
            SFXManager.instance.PlaySFX("Hit");

            hitCurTime += Time.deltaTime;

            float randomX = Random.Range(cameraPos.position.x + 1f, cameraPos.position.x - 1f);
            cameraPos.position = new Vector3(randomX, cameraPos.position.y, cameraPos.position.z);

            shakeTime += Time.deltaTime;
            if (shakeTime > 0.15f)
                cameraPos.position = cameraOrigin;
            

            AnimatorClipInfo[] curClipInfo;
            curClipInfo = playerAnim.GetCurrentAnimatorClipInfo(0);
            if (hitCurTime > curClipInfo[0].clip.length)//3.567f
            {
                isHit = false;
                playerAnim.SetInteger("PLAYERSTATE", 0);
                hitCurTime = 0;
                shakeTime = 0;
                Destroy(hitFX);

            }

            Invoke("OffDamaged", 1.5f);

            if(gameObject.tag == "BoostMode")
            {
                hp -= 0;
                playerAnim.SetInteger("PLAYERSTATE", 0);
            }
        }


        if(other.gameObject.tag == "Coin")
        {
            coinCnt += 2;
            score += 1100;
            GameObject coin = Instantiate(fxPrefab[0], other.transform.position, other.transform.rotation);
            Destroy(coin, 0.6f);
            scoreText.text = score.ToString();
            
        }

        if(other.gameObject.tag == "Score")
        {
            score += 1200;
            scoreText.text = score.ToString();
            GameObject egg = Instantiate(fxPrefab[1], other.transform.position, other.transform.rotation);
            Destroy(egg, 0.6f);
        }

        if(other.gameObject.tag == "GoldEgg")
        {
            goldenEggCnt += 2;
            score += 1100;
            scoreText.text = score.ToString();
            GameObject goldEgg = Instantiate(fxPrefab[2], other.transform.position, other.transform.rotation);
            Destroy(goldEgg, 0.6f);
        }

        if(other.gameObject.tag == "Potion")
        {
            if (hp < maxHp)
            {
                hp += 5;
            }

            SFXManager.instance.PlaySFX("Potion");
        }

        if(other.gameObject.tag == "Booster")
        {
            isBooster = true;
            gameObject.tag = "BoosterMode";
            SFXManager.instance.PlaySFX("Booster");
            

        }

        
    }

    void OffDamaged()
    {
        gameObject.layer = 0;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    
}



