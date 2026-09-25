using UnityEngine;
//attached to collectable used to remove object when needed
//get the value of the given collectable
public class CollectableData : MonoBehaviour
{
    //Data for our collectables
    [SerializeField]
    private int collectableValue;
    public void destroyCollectable()
    {
        Destroy(this.gameObject);
    }
    public int getCollectableValue()
    {
        return collectableValue;
    }
}
