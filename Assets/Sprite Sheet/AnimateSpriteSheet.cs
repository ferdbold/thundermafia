using UnityEngine;
using System.Collections;

public class AnimateSpriteSheet : MonoBehaviour
{
    public int Columns = 8;
    public int Rows = 9;
    public float FramesPerSecond = 1f;
    public bool RunOnce = true;
 
	public Texture texture;
	public GameObject powPrefab;
	
	private GameObject prefab;
	
    public float RunTimeInSeconds
    {
        get
        {
            return ( (1f / FramesPerSecond) * (Columns * Rows) );
        }
    }
 
    private Material materialCopy = null;
 
    void Start()
    {		
		materialCopy = new Material(powPrefab.renderer.material);
        powPrefab.renderer.material = materialCopy;
 
        Vector2 size = new Vector2(1f / Columns, 1f / Rows);
        powPrefab.renderer.material.SetTextureScale("_MainTex", size);
    }
	
	void Update() {
		if (Input.GetKeyUp (KeyCode.H)) {
			GameObject.Instantiate(powPrefab, transform.position, transform.rotation);	
		}
	}		
	
	public void Animate(float x, float y, float z)
	{	
		prefab = (GameObject)Instantiate(powPrefab, new Vector3(x, y , z), powPrefab.transform.rotation);
		
		StartCoroutine(UpdateTiling());
	}
	
	private IEnumerator UpdateTiling()
    {
        float x = 0f;
        float y = 0f;
        Vector2 offset = Vector2.zero;
 
        while (true)
        {
            for (int i = Rows-1; i >= 0; i--) // y
            {
                y = (float) i / Rows;
 
                for (int j = 0; j <= Columns-1; j++) // x
                {
                    x = (float) j / Columns;
 
                    offset.Set(x, y);
					
                    prefab.renderer.material.SetTextureOffset("_MainTex", offset);
                    yield return new WaitForSeconds(0.005f / FramesPerSecond);
                }
            }
 
            if (RunOnce)
            {
				prefab.transform.Translate(new Vector3(0, 0, -100)); //shame
                yield break;
            }
        }
    }
}
