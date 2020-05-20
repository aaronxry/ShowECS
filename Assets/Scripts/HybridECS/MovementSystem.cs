/*

Hybried ECS 演示项目
title: 系统
        定义组件（实体)运动的速度与方向

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation,ref Movement movement) =>
        {
            translation.Value.y += movement.MoveSpeed * Time.DeltaTime;
            //Debug.Log("y = " + translation.Value.y);
            //上下移动边界数值控制
            if (translation.Value.y > 4f)
            {
                movement.MoveSpeed = -Mathf.Abs(movement.MoveSpeed);
            }
            if (translation.Value.y < -4f)
            {
                movement.MoveSpeed = Mathf.Abs(movement.MoveSpeed);
            }
        });
    }
}
