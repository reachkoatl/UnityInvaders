using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    private int score;
    public GameObject destructionsound;
    public Sprite DieInvasor;


    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("ScoreTotal").GetComponent<ScoreController>();
        
        
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
                if(hp==1)
                {
                    score = 1;
                    player.SetScore(score);
                }

                if (hp==2)
                {
                    score = 2;
                    player.SetScore(score);
                }

                if (hp==3)
                {
                    score = 3;
                    player.SetScore(score);
                }

                Instantiate(destructionsound);
                StartCoroutine("Muerte");
            }          
        }    
    } 

    IEnumerator Muerte()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DieInvasor;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
        this.killed.Invoke();
    }
}
