using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part11_12OOP
{
    #region case not having virtual so we can not process polymophism
    public class Animal
    {
        public void Eat() => Console.WriteLine("Animal is eating");
        public void Walk() => Console.WriteLine("Animal is walking");
    }

    public class Cat : Animal
    {
        public void Eat() => Console.WriteLine("Cat is eating");
        public void Walk() => Console.WriteLine("Cat is walking");
    }

    public class Dog : Animal
    {
        public void Eat() => Console.WriteLine("Dog is eating");
        public void Walk() => Console.WriteLine("Dog is walking");
    }

    #endregion

    #region case HAVING virtual so we can not process polymophism
    public class AnimalTrue
    {
        public virtual void Eat() => Console.WriteLine("Animal is eating");
        public virtual void Walk() => Console.WriteLine("Animal is walking");
    }

    public class CatTrue : AnimalTrue
    {
        public override void Eat() => Console.WriteLine("Cat is eating");
        public override void Walk() => Console.WriteLine("Cat is walking");
    }

    public class DogTrue : AnimalTrue
    {
        public override void Eat() => Console.WriteLine("Dog is eating");
        public override void Walk() => Console.WriteLine("Dog is walking");
    }

    #endregion
    public class Polymorphism
    {
        public void ImplementWrong()
        {
            //animal
            Animal animal = new Animal();
            animal.Eat();
            animal.Walk();

            //Cat??? not still animalll
            Animal cat = new Cat();
            cat.Eat();
            cat.Walk();

            //Dog??? not still animalll
            Animal dog = new Dog();
            dog.Eat();
            dog.Walk();

            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ImplementTrue()
        {
            //animal
            AnimalTrue animal = new AnimalTrue();
            animal.Eat();
            animal.Walk();

            //Cat??? not still animalll
            AnimalTrue cat = new CatTrue();
            cat.Eat();
            cat.Walk();

            //Dog??? not still animalll
            AnimalTrue dog = new DogTrue();
            dog.Eat();
            dog.Walk();
        }
    }


}
