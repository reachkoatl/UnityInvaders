using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Proyectile laserPrefab;
    public SpriteRenderer spriteRenderer { get; private set; }
    public float speed = 5.0f;
    private bool _laserActive;
    private int initscore;
    public GameObject shootingsound;
    public GameObject diesound;
    public Sprite Die;
    private Vector3 _direction = Vector2.right;

   

    private void Update()
    {


        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.transform.position.x <= (leftEdge.x + 1.0f))
        {
            
        }else
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }

            
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            if( this.transform.position.x >= (rightEdge.x - 1.0f))
            {
            }else
            {
                this.transform.position += Vector3.right * this.speed * Time.deltaTime;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot();
        }


    }

    private void Shoot()
    {
        if(!_laserActive)
        {
            Proyectile proyectile =  Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            proyectile.destroyed += LaserDestroyed;
            _laserActive = true;
            Instantiate(shootingsound);
        }    
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    public void score(int score)
    {
        initscore = initscore + score;
        Debug.Log(initscore);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Invader") || 
           other.gameObject.layer == LayerMask.NameToLayer("Missile"))
           {
                StartCoroutine ("Esperar");

                Instantiate(diesound);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Die;
            }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }
}
