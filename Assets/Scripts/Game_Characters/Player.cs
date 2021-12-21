using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Proyectile laserPrefab;
    
    public float speed = 5.0f;
    private bool _laserActive;
    private int initscore;


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
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           }
        

        

    }
}
