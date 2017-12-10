using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.AI;


public class NavMeshGenerator : MonoBehaviour {

	NavMeshDataInstance instance;	
	NavMeshData m_NavMeshData;
	
    void Start () {
    }

	void Update () {
		NavMeshEditorHelpers.DrawBuildDebug(m_NavMeshData, NavMeshBuildDebugFlags.Regions | NavMeshBuildDebugFlags.SimplifiedContours);
	}
	
	void CalculateMesh(int width, Vector3 position){
		var bounds = new Bounds(transform.position, new Vector3(width*15, 1.0f, width*15));
        var markups = new List<NavMeshBuildMarkup>();
        var sources = new List<NavMeshBuildSource>();
        UnityEngine.AI.NavMeshBuilder.CollectSources(bounds, ~0, NavMeshCollectGeometry.PhysicsColliders, 0, markups, sources);
        var settings = NavMesh.GetSettingsByID(0);
        // var debug = new NavMeshBuildDebugSettings();
        // debug.flags = NavMeshBuildDebugFlags.All;
        // settings.debug = debug;

        m_NavMeshData = new NavMeshData();
        UnityEngine.AI.NavMeshBuilder.UpdateNavMeshData(m_NavMeshData, settings, sources, bounds);
		
		instance = NavMesh.AddNavMeshData(m_NavMeshData);
	}
	
	public void RecalculateMesh(int width, Vector3 position) {
		Unload();
		CalculateMesh(width, position);
	}
	
	void Unload(){
		NavMesh.RemoveNavMeshData(instance);
	}
}