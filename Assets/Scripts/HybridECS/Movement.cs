/*
Hybried ECS 演示项目
title: 组件
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct Movement : IComponentData
{
    //运动组件 
    public float MoveSpeed;//不能有初始值
}
