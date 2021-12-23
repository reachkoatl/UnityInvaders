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
   

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
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
