/**
 * Pure ECS 项目演示
 * 
 * 实体管理器控制
 * 
 */ 
 
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;


public class PureECSManager : MonoBehaviour
{
    //生成精灵的数量
    public int intCreatePlaneNumber = 10;
    // Unity集合
    private NativeArray<Entity> entityArray;
   
    [SerializeField] //序列化字段
    private Mesh _Mesh;
    [SerializeField]
    private Material _Material;

    private void Start()
    {
        //创建实体管理器
        EntityManager entityMgr = World.DefaultGameObjectInjectionWorld.EntityManager;

        //创建 “实体原型类型”
        EntityArchetype entityAr = entityMgr.CreateArchetype(
            typeof(Times),//时间组件 
            typeof(Moving),//自定义组件 
            typeof(Translation),//移动组件 
            typeof(RenderMesh),//渲染组件 
            typeof(LocalToWorld)//渲染支持组件
        );
        //建立本地集合类型
        entityArray = new NativeArray<Entity>(intCreatePlaneNumber, Allocator.Persistent);

        //创建实体，且连接“实体原型类型”与“本地集合类型” 结合起来
        entityMgr.CreateEntity(entityAr, entityArray);

        //循环迭代，给本地集合中每一个实体，添加组件
        for(int i = 0; i < entityArray.Length; i++)
        {
            //设置时间组件
            entityMgr.SetComponentData(entityArray[i],new Times { timeByComponet = 1f});
            //设置自定义移动组件
            entityMgr.SetComponentData(entityArray[i], new Moving { MoveSpeed = UnityEngine.Random.Range(1,5) });
            //设置系统组件(确定每个实体随机方位)
            entityMgr.SetComponentData(entityArray[i], new Translation { Value = new Unity.Mathematics.float3(
                0, UnityEngine.Random.Range(-5, 5), 0) });
            //添加共享组件，进行实体渲染
            entityMgr.SetSharedComponentData(entityArray[i], new RenderMesh {
                material = _Material,
                mesh = _Mesh,
            });
        }


    }

    private void OnDestroy()
    {
        if (entityArray != null){
            entityArray.Dispose();
        }
    }
}
