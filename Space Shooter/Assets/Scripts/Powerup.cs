using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int _powerupID; // 0 = Triple Shot, 1 = Speed, 2 = Shields

    [SerializeField]
    private AudioClip _clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);


        if (transform.position.y < -6.0f)
        {
            Destroy(this.gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Powerup collected logic here

            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            //_audioSource.Play();
            if (player != null)
            {
                
            switch(_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    default:
                        Debug.LogError("Invalid powerup ID");
                        break;
                }

                //player.TripleShotActive();
            } else             {
                Debug.LogError("Player component not found on the collided object.");
            }

            Destroy(this.gameObject);

        }
    }

}
