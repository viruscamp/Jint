using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Marshal
{
    public static class ExplicitInterfaceHelper
    {
        // targetType 是不是显式实现 interfaceType
        // 未实现接口时抛出异常
        public static bool IsExplicitInterface(Type targetType, Type interfaceType)
        {
            var interfaceMap = targetType.GetInterfaceMap(interfaceType);
            foreach (var targetMethod in interfaceMap.TargetMethods)
            {
                // 接口方法对应的类方法都是 public 才是隐式实现
                // TODO 接口的父项的方法不在列表 需要检查吗 ?
                if (!targetMethod.IsPublic)
                {
                    // 接口方法对应的类方法 只要有一个不是 public 就是显式实现
                    return true;
                }
            }
            return false;
        }

        public static Type GetImplicitIListType(Type type)
        {
            var typeIList = typeof(System.Collections.IList);
            if (typeIList.IsAssignableFrom(type) &&
                !IsExplicitInterface(type, typeIList))
            {
                // 隐式实现 IList
                return typeIList;
            }

            foreach (var ti in type.GetInterfaces())
            {
                if (ti.IsGenericType &&
                    ti.GetGenericTypeDefinition() == typeof(IList<>) &&
                    !IsExplicitInterface(type, ti))
                {
                    // 隐式实现 IList<>
                    return ti;
                }
            }

            return null;
        }

        public static Type GetImplicitIDictionaryType(Type type)
        {
            var typeIDictionary = typeof(System.Collections.IDictionary);
            if (typeIDictionary.IsAssignableFrom(type) &&
                !IsExplicitInterface(type, typeIDictionary))
            {
                // 隐式实现 IDictionary
                return typeIDictionary;
            }

            foreach (var ti in type.GetInterfaces())
            {
                if (ti.IsGenericType &&
                    ti.GetGenericTypeDefinition() == typeof(IDictionary<,>) &&
                    !IsExplicitInterface(type, ti))
                {
                    // 隐式实现 IDictionary<,>
                    return ti;
                }
            }

            return null;
        }
    }
}
