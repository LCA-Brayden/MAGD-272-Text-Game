using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour
{

    public Texture2D newCursor;
    Vector2 offset;

    // Use this for initialization
    void Start()
    {
        offset = new Vector2((newCursor.width * .25f), (newCursor.height * .25f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onMouseOver()
    {
        Cursor.SetCursor(newCursor, offset, CursorMode.Auto);
    }

    public void onMouseDefault()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
