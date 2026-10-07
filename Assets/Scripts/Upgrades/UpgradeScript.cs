using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UpgradeScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<Transform> Dependencies = new List<Transform>();
    public List<Transform> Influences = new List<Transform>();
    public bool isUnlocked = false;
    public int upgradeID;
    public ArrowManager arrowManager;
    List<Arrow> myArrows = new List<Arrow>();  
    List<GameObject> Heads = new List<GameObject>();  
    public GameObject ArrowHead;
    //piority int>??
    void Start()
    {
        //myArrows = arrowManager.AddArrow(Vector3.zero, new Vector3(3, 1, 0), Color.red);
        ArrowHead = Resources.Load<GameObject>("ArrowHead");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(gameObject.GetComponent<UpgradeScript>().Dependencies.Count > 0 || gameObject.GetComponent<UpgradeScript>().Influences.Count > 0) {
            
            foreach(var Dep in Dependencies) {
                if (Dep == null) continue;
                // arrow from this object to the dependency
                myArrows.Add(arrowManager.AddArrow(transform.position, Dep.transform.position, Color.red));
            }
            foreach(var Inf in Influences) {
                if (Inf == null) continue;
                // arrow from the influence to this object
                myArrows.Add(arrowManager.AddArrow(Inf.transform.position, transform.position, Color.green));
            }
        }
    }
    void Update()
    {
        for (int i = 0; i < myArrows.Count; i++)
        {
            var arrow = myArrows[i];

            if (i >= Heads.Count)
                Heads.Add(Instantiate(ArrowHead, arrow.line.transform));

            Heads[i].transform.position = arrow.end;
            Heads[i].transform.rotation = Quaternion.Euler(0, 0, arrow.AngleZ());
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var arrow in myArrows)
            arrowManager.RemoveArrow(arrow);

        myArrows.Clear();

        foreach (var head in Heads)
            Destroy(head);

        Heads.Clear();
    }
    public void RefreshInfluences() {
        foreach (var x in Influences)
        {
            bool CorrectYLoop = true;
            //Debug.Log("1");
            foreach (var y in x.GetComponent<UpgradeScript>().Dependencies)
            {
                //Debug.Log("2");
                if(y.GetComponent<UpgradeScript>().isUnlocked != true)
                {
                    Debug.Log("Broke on Dependency" + y.name);
                    CorrectYLoop = false;
                    break;
                    
                }
                else {
                    Debug.Log("Continued on Dependency " + y.name);
                }
            }
            if(CorrectYLoop) {
                Debug.Log("Unlocked " + x.name);
                //unlock logic
            }
            
            //x.GetComponent<UpgradeScript>().PurchaseBlock(upgradeID);
            
        }
    }

}
