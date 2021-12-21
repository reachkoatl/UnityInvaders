using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites = new Sprite[0];
    public float animationTime = 1.0f;
    public System.Action killed;
    public SpriteRenderer spriteRenderer { get; private set; }
    public int animationFrame { get; private set; }
    public int maxhp;
    public int hp;
    ScoreController player;
    public int score;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("ScoreTotal").GetComponent<ScoreController>();
        //point = PlayerPrefs.GetInt("score");
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
        
    }

    private void AnimateSprite()
    {
        this.animationFrame++;
        
        if (this.animationFrame >= this.animationSprites.Length)
        {
            this.animationFrame = 0;
        }

        this.spriteRenderer.sprite = this.animationSprites[this.animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            

            maxhp--;
            
            if(maxhp==0){

                Debug.Log("pego");
                if(hp==1)
                {
                    score = 10;
                
                    player.SetScore(score);
                    
                }

                if (hp==2)
                {
                    score = 20;
                    player.SetScore(score);
                    
                }

                if (hp==3)
                {
                    score = 30;
                    player.SetScore(score);
                
                }

                this.killed.Invoke();
                this.gameObject.SetActive(false); 
            }
            

            //point++;
            
            //PlayerPrefs.SetInt("score", point);
            //point = PlayerPrefs.GetInt("score");
            //Debug.Log(point);
            
        }
    
    } 
}
