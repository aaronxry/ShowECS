///***
// * 
// *   ECS技术Hello World项目演示（Unity2019版本）
// *   
// *   实体管理器  (所属类型： “混合ECS”开发模式)
// * 
// *
// */
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using Unity.Entities;

//public class EntitiesManger : MonoBehaviour,IConvertGameObjectToEntity
//{
//    //Cube 旋转速度
//    public float FloCubeSpeed;


//    /// <summary>
//    /// 把GameObject 转为 “实体”(Entity)
//    /// </summary>
//    /// <param name="entity"></param>
//    /// <param name="dstManager"></param>
//    /// <param name="conversionSystem"></param>
//    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
//    {
//        //创建一个“组件”
//        RotationCubeComponet data = new RotationCubeComponet { Speed = FloCubeSpeed };
//        //"组件"加入EntityManger 中，让Unity 内置的环境实体管理器，进行管理。
//        dstManager.AddComponentData(entity,data);
//    }
//}
