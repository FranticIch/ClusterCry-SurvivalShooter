using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TileNavMeshBuilder : MonoBehaviour {

    public GameObject boundsBox;
    List<NavMeshBuildSource> sources;
    NavMeshData data;

    void Start () {

        sources = new List<NavMeshBuildSource>();

        Collider boundsBoxCollider = boundsBox.GetComponent<Collider>();

        Bounds bounds = new Bounds();
        bounds.center = boundsBoxCollider.bounds.center;
        bounds.size = boundsBoxCollider.bounds.size;
        bounds.SetMinMax(boundsBoxCollider.bounds.min, boundsBoxCollider.bounds.max);

        NavMeshBuilder.CollectSources(bounds, 0, NavMeshCollectGeometry.PhysicsColliders, 0, new List< NavMeshBuildMarkup>(), sources);
        
        data = NavMeshBuilder.BuildNavMeshData(NavMesh.GetSettingsByID(0), sources, bounds, bounds.center, Quaternion.identity);
        Debug.Log(data != null);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //void Generate(Mesh mesh) {

    //    var filter = tile.AddComponent<MeshFilter>();
    //    filter.mesh = mesh;

    //    NavMeshBuildSource src = new NavMeshBuildSource();
    //    src.transform = transform.localToWorldMatrix;
    //    src.shape = NavMeshBuildSourceShape.Mesh;
    //    src.sourceObject = filter.mesh;
    //    src.area = 0;
    //    //source.size = mesh.bounds.size;

    //    var sources = new List<NavMeshBuildSource>();
    //    sources.Add(src);

    //    NavMeshBuilder.UpdateNavMeshData(navData, NavMesh.GetSettingsByIndex(0), sources, mesh.bounds);
    //}
}
