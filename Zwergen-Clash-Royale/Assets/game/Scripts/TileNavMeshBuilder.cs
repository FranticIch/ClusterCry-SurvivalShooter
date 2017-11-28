using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.AI;

public class TileNavMeshBuilder : MonoBehaviour {

	public Transform tlink_top_in;
	public Transform tlink_top_out;

	
	NavMeshDataInstance instance;
	NavMeshLinkInstance linstance_top;
	NavMeshLinkInstance linstance_right;	
	
    void Start () {
		CreateNavMesh();
		CreateLinks();
    }
	
	void OnDestroy(){
		NavMesh.RemoveNavMeshData(instance);
		// Destroy(m_NavMeshData);
	}

	void Update () {
		//NavMeshEditorHelpers.DrawBuildDebug(m_NavMeshData, NavMeshBuildDebugFlags.Regions | NavMeshBuildDebugFlags.SimplifiedContours);
	}
	
	void CreateNavMesh(){
		var bounds = new Bounds(transform.position, new Vector3(15.0f, 1.0f, 15.0f));
        var markups = new List<NavMeshBuildMarkup>();
        var sources = new List<NavMeshBuildSource>();
        UnityEngine.AI.NavMeshBuilder.CollectSources(bounds, ~0, NavMeshCollectGeometry.RenderMeshes, 0, markups, sources);
        var settings = NavMesh.GetSettingsByID(0);
        // var debug = new NavMeshBuildDebugSettings();
        // debug.flags = NavMeshBuildDebugFlags.All;
        // settings.debug = debug;

        NavMeshData m_NavMeshData = new NavMeshData();
        UnityEngine.AI.NavMeshBuilder.UpdateNavMeshData(m_NavMeshData, settings, sources, bounds);
		instance = NavMesh.AddNavMeshData(m_NavMeshData);
	}
	
	void CreateLinks(){
		NavMeshLinkData link_top = new NavMeshLinkData();
		link_top.agentTypeID = 0;
		link_top.area = 13;
		link_top.startPosition = tlink_top_in.position;
		link_top.endPosition = tlink_top_out.position;
		
		linstance_top = NavMesh.AddLink(link_top);
		
		// NavMeshLinkData link_top_out = new NavMeshLinkData();
		// link_top_out.agentTypeID = 0;
		// link_top_out.area = 13;
		// link_top_out.startPosition = tlink_top_in.position;
	}

}
