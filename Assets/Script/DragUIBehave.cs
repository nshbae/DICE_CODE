using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragUIBehave : MonoBehaviour
{
    public GameObject dice;
    public float sizeMulti;
    public SpriteRenderer SpriteRenderer;

    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer = this.GetComponent<SpriteRenderer>();
        SpriteRenderer.size = new Vector2(3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = dice.transform.position;
    }

    public void setDragUI(Vector2 dir)
    {
        SpriteRenderer.size = new Vector2(3, sizeMulti * dir.magnitude);
        if (Physics.gravity.normalized == Vector3.down || Physics.gravity.normalized == Vector3.up)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(-dir.y, dir.x) * Mathf.Rad2Deg + 90f, 0));
            arrow.transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        else if (Physics.gravity.normalized == Vector3.left)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Atan2(-dir.y, dir.x) * Mathf.Rad2Deg + 90f, 0, 0));
            arrow.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Physics.gravity.normalized == Vector3.right)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg + 90f, 0, 0));
            arrow.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Physics.gravity.normalized == Vector3.forward || Physics.gravity.normalized == Vector3.back)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg + 90f));
            arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
