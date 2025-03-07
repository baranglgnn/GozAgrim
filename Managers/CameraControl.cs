using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;
    public Transform room;
    public Transform activeRoom;

    public float dampSpeed=3f;

    public static CameraControl Instance;

    [Range(-10,10)]
    public float minModX,maxModX,minModY,maxModY;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Player = PlayerControl.Instance.gameObject.transform;
        activeRoom = Player;
    }

    
    void Update()
    {
        

        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y+minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y+maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x+minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x+maxModX;
        //Kameranýn sýnýrlarýný room'un BoxCollider'ýna göre ayarladým

        Vector3 clampedPos = new Vector3(Mathf.Clamp(Player.position.x, minPosX, maxPosX),
            Mathf.Clamp(Player.position.y, minPosY, maxPosY),
            Mathf.Clamp(Player.position.z, -10, -10));
        //Mathf.Clamp fonksiyonu ile kamerayý sýnýrlar içine aldým

        Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);
        //Geçiþlerdeki yumuþatmalar için Lerp fonksiyonunu kullandým.

        transform.position = smoothPos;
    }
}
