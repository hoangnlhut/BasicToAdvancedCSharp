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


    #region Other example of polymophism
    public class TestPolymorphism()
    {
        public static void ImplementTestPolymorphism()
        {

            Window win = new Window(1, 2);
            ListBox lb = new ListBox(3, 4, " Stand alone list box");
            Button b = new Button(5, 6);
            win.DrawWindow();
            lb.DrawWindow();
            b.DrawWindow();
            Window[] winArray = new Window[3];
            winArray[0] = new Window(1, 2);
            winArray[1] = new ListBox(3, 4, "List box is array");
            winArray[2] = new Button(5, 6);
            for (int i = 0; i < 3; i++)
            {
                winArray[i].DrawWindow();
            }
        }
    }

    public class Window
    {
        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }
        // phương thức được khai báo ảo
        public virtual void DrawWindow()
        {
            Console.WriteLine("Window: drawing window at {0}, {1}", top, left);
        }
        // biến thành viên của lớp
        protected int top;
        protected int left;
    }

    public class ListBox : Window
    {
        // phương thức khởi dựng có tham số
        public ListBox(int top, int left, string contents) : base(top, left)
        {
            listBoxContents = contents;
        }
        // thực hiện việc phủ quyết phương thức DrawWindow
        public override void DrawWindow()
        {
            base.DrawWindow();
            Console.WriteLine(" Writing string to the listbox: {0}", listBoxContents);
        }
        // biến thành viên của ListBox
        private string listBoxContents;
    }

    public class Button : Window
    {
        public Button(int top, int left) : base(top, left)
        { }
        // phủ quyết phương thức DrawWindow của lớp cơ sở
        public override void DrawWindow()
        {
            Console.WriteLine(" Drawing a button at {0}: {1}", top, left);
        }
    }
    #endregion
}
