/*
Hybried ECS 演示项目
title: 创建海量cube 实体管理器
*/

using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CreateCubesEntitesManager : MonoBehaviour
{
    //游戏对象预设
    public GameObject goPrefab;
    //对象克隆数量
    public int XNum = 10;
    public int YNum = 10;
    //实体对象
    Entity entity;

    //实体管理器
    EntityManager entityMgr;

    private void Start()
    {
        //参数检查
        if (goPrefab)
        {
            Debug.Log(GetType() + "/Start()/游戏预设没有指定");
        }

        //游戏对象转为实体(entity)
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(goPrefab, settings);
        //得到实体管理器(EntityManger)
        entityMgr = World.DefaultGameObjectInjectionWorld.EntityManager;
        //按照指定数量，克隆大量实体，且指定分布位置
        for (int x = 0; x < XNum; x++)
        {
            for(int y = 0; y < YNum; y++)//z轴
            {
                //从“实体预设”，大量克隆实体
                Entity entityClone  = entityMgr.Instantiate(entity);
                //对克隆实体，定义其初始位置
                Vector3 position = transform.TransformPoint(new float3(x-XNum/2,noise.cnoise(new float2(x,y)*0.21f),y-YNum/2));
                //实体管理器设置其中的组件参数
                entityMgr.SetComponentData(entityClone, new Translation() { Value = position });
                //把定义的组件加入实体管理器
                entityMgr.AddComponentData(entityClone, new Movement { MoveSpeed = 1f });
            }
        }
    }



}
