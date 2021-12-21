using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;
    public int score;
    public GameObject scoretotal;

  

    public void Start(){

        //scoretotal = GameObject.Find("ScoreTotal").GetComponent<ScoreTotal>();
      
        
        
    }


    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        


        if (this.destroyed != null)
        {
            this.destroyed.Invoke();
        }
        Destroy(this.gameObject);
    }
}
