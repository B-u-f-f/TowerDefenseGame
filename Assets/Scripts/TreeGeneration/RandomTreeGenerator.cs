using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelTree))]
public class RandomTreeGenerator : MonoBehaviour {
    
    [SerializeField] private Transform m_leafPosition;
    [SerializeField] private Vector3 m_leafdir;
    private Vector3 m_growDirection = new Vector3(0f, 0f, 1f);

    //[Range(min: 1, max: 3)]
    //[SerializeField] private float m_meanChildren = 1.0f;
    //[SerializeField] private float m_stdChildren = 0.0f;

    [SerializeField] private int m_nleaf = 10;
    [SerializeField] private float m_width;
    [SerializeField] private float m_padding;


    [SerializeField] private float m_junctionRadius = 3.0f;
    [SerializeField] private float m_roadLen = 5.0f;

    private LevelTree m_tree;
        
    // Start is called before the first frame update
    public void display() {
        
        if(m_tree != null){
            clearChildren();
        }

        m_tree = createLevelTree();
        m_tree.applyInPostorder(lt => {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            g.transform.position = lt.position;
            g.transform.parent = this.transform; 

            return g;
        });       
    }
    
    public void clearChildren(){
        for(int i = transform.childCount - 1; i >= 0; i--){
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private LevelTree createLevelTree(){
        List<LevelTree> leafpositions = new List<LevelTree>();


        Vector3 position = m_leafPosition.transform.position;
        for(int i = 0; i < m_nleaf; i++){
            LevelTree lvl = new LevelTree();
            lvl.position = position;
            leafpositions.Add(lvl);

            position += m_leafdir * (m_width + m_padding); 
        }
        
        while(leafpositions.Count > 1){
            List<LevelTree> parents = new List<LevelTree>();

            int n = leafpositions.Count;
            for(int i = 0; i < n; i++){

                LevelTree parent = new LevelTree();

                int nodeLeft = n - i;
                int children = Mathf.CeilToInt(Random.Range(1.0f, nodeLeft > 3 ? 3.0f : nodeLeft));
                
                if(children == 1){
                    parent.addChild(leafpositions[i]);
                    parent.position = getParentPosition(leafpositions[i].position);

                }
                else if (children == 2){
                    Vector3 pos = (leafpositions[i].position 
                            + leafpositions[i + 1].position) / 2.0f;
                    
                    parent.addChild(leafpositions[i]);
                    parent.addChild(leafpositions[i + 1]);
                    
                    parent.position = getParentPosition(pos);
                    i += 1;
                } else {
                    parent.addChild(leafpositions[i]);
                    parent.addChild(leafpositions[i + 1]);
                    parent.addChild(leafpositions[i + 2]);
                    
                    parent.position = getParentPosition(leafpositions[i + 1].position);

                    i += 2;
                }

                parents.Add(parent);
            }

            leafpositions = parents;
        }


        return leafpositions[0];
    } 

    private Vector3 getParentPosition(Vector3 pos){
        return pos + (m_roadLen + 2.0f * m_junctionRadius) * m_growDirection; 
    }

    private void createSphereAtPos(Vector3 pos){
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        g.transform.position = pos;
    }
}
