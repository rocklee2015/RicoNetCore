using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BookDemo.S04.S401
{
    class S401 : IBookDemo
    {
        public void Main()
        {
            var provider = new ServiceCollection()
              .AddTransient<IFoo, Foo>()
              .AddScoped<IBar>(_ => new Bar())
              .AddSingleton<IBaz, Baz>()
              .BuildServiceProvider();
            Debug.Assert(provider.GetService<IFoo>() is Foo);
            Debug.Assert(provider.GetService<IBar>() is Bar);
            Debug.Assert(provider.GetService<IBaz>() is Baz);
        }
    }
    public interface IFoo { }
    public interface IBar { }
    public interface IBaz { }
    public interface IFoobar<T1, T2> { }
    public class Base : IDisposable
    {
        public Base() => Console.WriteLine($"An instance of {GetType().Name} is created.");
        public void Dispose() => Console.WriteLine($"The instance of {GetType().Name} is disposed.");
    }

    public class Foo : Base, IFoo, IDisposable { }
    public class Bar : Base, IBar, IDisposable { }
    public class Baz : Base, IBaz, IDisposable { }
    public class Foobar<T1, T2> : IFoobar<T1, T2>
    {
        public IFoo Foo { get; }
        public IBar Bar { get; }
        public Foobar(IFoo foo, IBar bar)
        {
            Foo = foo;
            Bar = bar;
        }
    }
}
