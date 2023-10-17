using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WaypointManagingWindow : EditorWindow
{
    [MenuItem("Tools/Waypoint Editor")]

    public static void Open(){
        GetWindow<WaypointManagingWindow>();
    }
    
    public Transform waypointRoot;


    private void OnGUI(){

        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));


        if(waypointRoot == null){
            EditorGUILayout.HelpBox("root harus di select dulu", MessageType.Warning);
        }else {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();

    }

    void DrawButtons(){
        if(GUILayout.Button("Create Waypoint")){
            CreateWaypoint();
        }

        if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<WaypointAja>()){
            if(GUILayout.Button("Create WayPoint Before")){
                CreateWaypointBefore();
            }

            if(GUILayout.Button("Create WayPoint After")){
                CreateWaypointAfter();
            }

            if(GUILayout.Button("Remove Waypoint")){
                RemoveWaypoint();
            }

            if(GUILayout.Button("Create Branch")){
                CreateCabang();
            }
        }
    }


    void CreateWaypoint(){
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(WaypointAja));
        waypointObject.transform.SetParent(waypointRoot, false);

        WaypointAja waypoint = waypointObject.GetComponent<WaypointAja>();

        if(waypointRoot.childCount > 1)
        {
            waypoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<WaypointAja>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;


    }

    void CreateWaypointBefore(){
        GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(WaypointAja));
        waypointObject.transform.SetParent(waypointRoot, false);

        WaypointAja newWaypoint = waypointObject.GetComponent<WaypointAja>();

        WaypointAja selectedWaypoint = Selection.activeGameObject.GetComponent<WaypointAja>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        if(selectedWaypoint.previousWaypoint != null){
            newWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
            selectedWaypoint.previousWaypoint.nextWaypoint = newWaypoint;
        }

        newWaypoint.nextWaypoint = selectedWaypoint;

        selectedWaypoint.previousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newWaypoint.gameObject;

    }

    void CreateWaypointAfter(){
         GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(WaypointAja));
        waypointObject.transform.SetParent(waypointRoot, false);

        WaypointAja newWaypoint = waypointObject.GetComponent<WaypointAja>();

        WaypointAja selectedWaypoint = Selection.activeGameObject.GetComponent<WaypointAja>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        newWaypoint.previousWaypoint = selectedWaypoint;

        if(selectedWaypoint.nextWaypoint != null){
            selectedWaypoint.nextWaypoint.previousWaypoint = newWaypoint;
            newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
        }

        selectedWaypoint.nextWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void RemoveWaypoint(){
        WaypointAja selectedWaypoint = Selection.activeGameObject.GetComponent<WaypointAja>();

        if(selectedWaypoint.nextWaypoint != null){
            selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
        }

        if(selectedWaypoint.previousWaypoint != null){
            selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
            Selection.activeGameObject = selectedWaypoint.previousWaypoint.gameObject;
        }

        DestroyImmediate(selectedWaypoint.gameObject);
    }

    void CreateCabang(){
        GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(WaypointAja));
        waypointObject.transform.SetParent(waypointRoot, false);

        WaypointAja waypoint = waypointObject.GetComponent<WaypointAja>();

        WaypointAja branchedFrom = Selection.activeGameObject.GetComponent<WaypointAja>();
        branchedFrom.perempatan.Add(waypoint);


        waypoint.transform.position = branchedFrom.transform.position;
        waypoint.transform.forward = branchedFrom.transform.forward;

        Selection.activeGameObject = waypoint.gameObject;
    }
}
