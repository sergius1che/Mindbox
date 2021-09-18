using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeArea
{
    public class Shape2DArea
    {
        private static Shape2DArea _instance;

        private readonly IDictionary<Type, object> _resolvers;

        private Shape2DArea()
        {
            /* Создаём словарь где ключом будет тип фигуры (реализация IShape2D)
             * А значением - экземпляр реализации IAreaResolver<>
             */
            _resolvers = typeof(IShape2D).Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract)
                .Where(x => x.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Any(i => i.GetGenericTypeDefinition() == typeof(IAreaResolver<>)))
                .SelectMany(x =>
                {
                    var instance = Activator.CreateInstance(x);
                    return x.GetInterfaces()
                        .First(i => i.IsGenericType)
                        .GetGenericArguments()
                        .Where(i => i.GetInterfaces().Any(ii => ii == typeof(IShape2D)))
                        .Select(i => (Type: i, Resolver: instance));
                })
                .ToDictionary(k => k.Type, v => v.Resolver);
        }

        public static Shape2DArea Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Shape2DArea();
                }

                return _instance;
            }
        }

        public double Calc<TShape2D>(TShape2D shape)
            where TShape2D : IShape2D
        {
            if (_resolvers.TryGetValue(shape.GetType(), out var resolver))
            {
                return ((IAreaResolver<TShape2D>)resolver).Calc(shape);
            }

            throw new NotSupportedException($"Shape type of '{shape.GetType().FullName}' is not supported");
        }
    }
}
