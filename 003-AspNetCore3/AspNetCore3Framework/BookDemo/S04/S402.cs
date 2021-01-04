using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BookDemo.S04.S402
{
    public class S402 : IBookDemo
    {
        public void Main()
        {
            var provider = new ServiceCollection()
                .AddTransient<IFoo, Foo>()
                .AddTransient<IBar, Bar>()
                .AddTransient(typeof(IFoobar<,>), typeof(Foobar<,>))
                .BuildServiceProvider();

            var foobar = (Foobar<IFoo, IBar>)provider.GetService<IFoobar<IFoo, IBar>>();
            Debug.Assert(foobar.Foo is Foo);
            Debug.Assert(foobar.Bar is Bar);
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
