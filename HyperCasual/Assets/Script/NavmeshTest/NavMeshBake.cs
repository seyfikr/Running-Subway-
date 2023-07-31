using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;

public class NavMeshBake : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;
    [SerializeField] private Transform Player;
    [SerializeField] private float UpdateRate = 0.1f;
    [SerializeField] private float MovementThresHold = 3;
    [SerializeField] private Vector3 NavMeshSize = new Vector3(5,0,1200);
    private Vector3 WorlAnchor;
    private NavMeshData NavMeshData;
    private List<NavMeshBuildSource> Sources = new List<NavMeshBuildSource>();
    private void Start()
    {
        NavMeshData=new NavMeshData();
        NavMesh.AddNavMeshData(NavMeshData);
        BuildNavMesh(false);
        StartCoroutine(CheckPlayerMovement());


    }
    private IEnumerator CheckPlayerMovement()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
        while (true)
        {
            if (Vector3.Distance(WorlAnchor, Player.transform.position) > MovementThresHold)
            {
                BuildNavMesh(true);
                WorlAnchor = Player.transform.position;
            }
            yield return Wait;

        }
    }
    private void BuildNavMesh(bool Async)
    {
        Bounds navMeshBounds = new Bounds(Player.transform.position, NavMeshSize);
        List<NavMeshBuildMarkup> markups=new List<NavMeshBuildMarkup>();
        List<NavMeshModifier> modifiers;
        if (surface.collectObjects == CollectObjects.Children)
        {
            modifiers=new List<NavMeshModifier>(surface.GetComponentsInChildren<NavMeshModifier>());

        }
        else
        {
            modifiers=NavMeshModifier.activeModifiers;
        }
        for(int i = 0; i < modifiers.Count; i++)
        {
            if (((surface.layerMask & (1 << modifiers[i].gameObject.layer)) == 1) && modifiers[i].AffectsAgentType(surface.agentTypeID))
            {
                markups.Add(new NavMeshBuildMarkup()
                {
                    root = modifiers[i].transform,
                    overrideArea = modifiers[i].overrideArea,
                    area = modifiers[i].area,
                    ignoreFromBuild = modifiers[i].ignoreFromBuild
                });
            }
        }
        if(surface.collectObjects == CollectObjects.Children)
        {
            NavMeshBuilder.CollectSources(surface.transform, surface.layerMask, surface.useGeometry, surface.defaultArea, markups, Sources);
        }
        else
        {
            NavMeshBuilder.CollectSources(navMeshBounds, surface.layerMask, surface.useGeometry, surface.defaultArea, markups, Sources);
        }
        Sources.RemoveAll(source=>source.component!= null&&source.component.gameObject.GetComponent<NavMeshAgent>()!=null);
        if (Async)
        {
            NavMeshBuilder.UpdateNavMeshDataAsync(NavMeshData, surface.GetBuildSettings(), Sources, new Bounds(Player.transform.position, NavMeshSize));
        }
        else
        {
            NavMeshBuilder.UpdateNavMeshData(NavMeshData, surface.GetBuildSettings(), Sources, new Bounds(Player.transform.position, NavMeshSize));
        }
    }

    }


