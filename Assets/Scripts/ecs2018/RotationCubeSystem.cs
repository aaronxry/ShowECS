///***
// * 
// *   使用Untiy2018.3 版本，开始ECS的Hello World  
// *   
// *   定义ECS的“系统”
// * 
// */
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using Unity.Entities;  //引入命名空间

//public class RotationCubeSystem : ComponentSystem
//{
//    struct Group {
//        public RotationCubeComponent rotaion;
//        public Transform transform;
//    }

//    protected override void OnUpdate()
//    {
//        foreach (var en in GetEntities<Group>())
//        {
//            en.transform.Rotate(Vector3.down,en.rotaion.speed*Time.deltaTime);
//        }
//    }
//}
