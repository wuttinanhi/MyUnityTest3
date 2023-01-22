using UnityEngine;
using Mirror;
public class PlayerController : NetworkBehaviour
{
    float horizontal;
    float vertical;
    public float speed = 5f;

    NetworkIdentity identity;

    // Start is called before the first frame update
    void Start()
    {
        identity = GetComponent<NetworkIdentity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, vertical, 0);
            transform.Translate(direction * speed * Time.deltaTime);
        }

        // if key space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // call the CmdTest function on the server
            CmdTest();
        }
    }


    [Command]
    void CmdTest()
    {
        Debug.Log("CMdTest");
        if (isServer)
        {
            Debug.Log("isServer");
        }
        else if (isClient)
        {
            Debug.Log("isClient");
        }

        NetworkIdentity networkIdentity = this.GetComponent<NetworkIdentity>();
        Debug.Log(networkIdentity);
    }
}
