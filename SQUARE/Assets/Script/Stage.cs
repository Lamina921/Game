using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Stage_start();
        Destroy(this);
    }

    public virtual   void Stage_start() {

    }
}
