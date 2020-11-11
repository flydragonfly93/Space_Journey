using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _StarParticlePrefab;

    // -- 1st Version --{
    //private void OnColiisionEnter2D(Collision2D coliision)
    // {
    // if(collision.collider.GetComponent<Bird>() != null} //With the other object that we collided with that collider, try to get a bird component on that object, -- 
    // {                                                   // --if there's not a bird object then it's gonna give us a null back. 
    //     Destroy(gameObject);                        // If it isn't null, it means that we did get a bird back then destroy our game object
    //}
    //
    // -- 2nd Version --
    //{
    //    private void OnCollisionEnter2D(Collision2D collision)
    //   {
    //      bool didHitBird = collision.collider.GetComponent<Bird>() != null;
    //       if (didHitBird)
    //       {
    //           Destroy(gameObject);
    //       }
    //   }
    //}

    // -- 3rd Version --

    private void OnCollisionEnter2D(Collision2D collision) //Collision2D - info that collided, Checking if the collision is for Bird, --
    {                                                      // -- Collision2D type object named "collision"
        Ship ship = collision.collider.GetComponent<Ship>(); // bird = give us back to the actual bird that we crashed into them, We could say -- 
        if (ship != null)                                   // -- if the Bird is not equal to null, it exist.
        {
            Instantiate(_StarParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;             //We hit the enemies , we don't want to continue on.
        }
        //if hit from top
        if (collision.contacts[0].normal.y < -0.5) //[0] = reference is 1st contact. normal - angle that we hit from. give us an x and y, for now we care only for y value.
        {                                      // -0.5(top) or (if hit from top)
            Instantiate(_StarParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}