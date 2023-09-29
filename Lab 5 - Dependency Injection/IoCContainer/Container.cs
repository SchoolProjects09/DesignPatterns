using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class Container
    {
        private Dictionary<Type, Func<object>> registeredTypes = new Dictionary<Type, Func<object>>();

        public ConstructorInfo GetLargestConstructor(Type type)
        {
            ConstructorInfo[] CInfo = type.GetConstructors();
            ConstructorInfo Largest = CInfo[0]; //First object in array is set as largest

            foreach (ConstructorInfo info in CInfo) //For every constructor in array:
            {
                int maxParams = Largest.GetParameters().Length; //First is largest
                if (info.GetParameters().Length > maxParams)
                {
                    Largest = info;
                }
            }
            return Largest; //Return largest ConstructorInfo
        }

        public object GetInstance(Type type)
        {
            if (registeredTypes.ContainsKey(type)) //Check registry
            {
                //type = registeredTypes[type];

                return registeredTypes[type]();
            }

            ConstructorInfo CInfo = GetLargestConstructor(type);
            ParameterInfo[] PInfo = CInfo.GetParameters();

            int numParams = PInfo.Length;
            object[] instantiatedParameters = new object[numParams];

            for (int i = 0; i < numParams; i++)
            {
                ParameterInfo info = PInfo[i];
                Type parameterType = info.ParameterType;

                object instantiatedParameter = GetInstance(parameterType);
                instantiatedParameters[i] = instantiatedParameter;
            }

            return Activator.CreateInstance(type, instantiatedParameters);
        }

        public void RegisterSingleton<T>(object obj)
        {
            registeredTypes.Add(typeof(T), () => obj);
        }

        public T GetInstance<T>()
        {
            return (T)GetInstance(typeof(T));
        }

        public void Register(Type in_type, Type out_type)
        {
            registeredTypes.Add(in_type, () => GetInstance(out_type));
        }

        public void Register<in_type, out_type>()
        {
            Register(typeof(in_type), typeof(out_type));
        }
    }
}
