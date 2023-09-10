﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace Dependency_injection
{

    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }
    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }
    class Horn {
        int level = 0;
        public Horn(int level) => this.level = level;
        public void Beep() => System.Console.WriteLine("Beep - Bepp");
    }

    class Car{
         Horn horn {set; get;}
        // inject bang phuong thuc khoi tao
        public Car(Horn _horn)=> horn = _horn;
        public void Beep(){

            horn.Beep();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Inverse of Control ( Dependency Inverse )
            // dependency injection 
            // dependency - phu thuoc 
            // Giả sử bạn có một lớp classA, lớp này có sử dụng 
            // một chức năng từ đối tượng lớp classB (classA hoạt động dựa vào classB). 
            // Lúc đó classB gọi là phụ thuộc (dependency) (của classA)
            // var b = new ClassB();
            // b.ActionB();

            // Inversion of Control (IoC - Đảo ngược điều khiển) là một nguyên lý thiết kế
            // trong công nghệ phần mềm trong đó các thành phần nó dựa vào để làm việc bị đảo
            // ngược quyền điều khiển khi so sánh với lập trình hướng thủ thục truyền thống.

            // IClassC objectC = new ClassC1();
            // IClassB objectB = new ClassB1(objectC);
            // ClassA objectA = new ClassA(objectB);

            // objectA.ActionA();
 
            // Horn horn = new Horn(7);
            // Car car = new Car(horn);
            // car.Beep();

            // thu vien dependency Injection
            // DI Container : ServiceCollection
            // dang ky cac dich vu ( class )
            // ServiceProvider => get Service 
            // thu vien unity, ninject  

            var services = new ServiceCollection();
            // dang ky cac dich vu 
            // IClassC, ClassC, ClassC1

            // Singleton
            // services.AddSingleton<IClassC, ClassC1>();

            //Transient
            // services.AddTransient<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();
            // var classc = providder.GetService<IClassC>();
            for(int i = 0; i<5; i++){
                IClassC c = provider.GetService<IClassC>();
                System.Console.WriteLine(c.GetHashCode());
            }   

            // Scoped
            services.AddScoped<IClassC, ClassC1>();
            using (var scope = provider.CreateScope()){
                var provider1 = scope.ServiceProvider;
                for(int i = 0; i<5; i++){
                IClassC c = provider1.GetService<IClassC>();
                System.Console.WriteLine(c.GetHashCode());
            }   
            }




        }

        // class ClassA{
        //     public void ActionA() => System.Console.WriteLine("Action A");
        // }
        // class ClassB{
        //     public void ActionB(){
        //         System.Console.WriteLine("Action B");
        //         var a = new ClassA();
        //         a.ActionA(); 
        //     }
        // }

    }
}