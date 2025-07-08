
#region Giriş

internal class Program
{
    private static void Main(string[] args)
    {
        int i = 3;
        string s = "Hello";
        char c = 'A';

        // Polimorfizim
        A a = new B();

        // Covariance
        object names = new string[] { "Ali", "Veli" };
        A[] array = new B[3];
        IEnumerable<object> objects = new List<string> { "Ali", "Veli" };
        IEnumerable<A> aEnumerable = new List<B>();

        IEnumerable<B> bEnumerable = new List<B>();
        IEnumerable<A> aEnumarable = bEnumerable;

        Func<A> funcA = GetB;
        B GetB() => new();

        // Contravariance
        Action<string> xDelegate = XMethod;
        void XMethod(object o) { }

        Action<B> bDelegate = AMethod;
        void AMethod(A a) { }

        #endregion

        #region Covariance

        #region Array Types

        Animal[] animals = new Cat[3];
        object[] objectsArray = new string[3];

        IEnumerable<Animal> animalEnumerable = new List<Cat>();
        IEnumerable<Cat> catEnumerable = new List<Cat>();

        #endregion

        #region Delegate Types

        Func<Animal> getAnimal = GetCat;
        Cat GetCat() => new();


        #endregion

        #region Return Types

        XHandler<A> aHandler = GetAA;
        XHandler<B> bHandler = GetBB;

        aHandler = bHandler;


        A GetAA() => new();
        B GetBB() => new();

        #endregion

        #region Generic Types

        ISoftware<Bird> birdSoftware = new Software<Bird>();
        ISoftware<Bird> software2 = new Software<Eagle>();

        IBaseInterface<object> baseInterface = new DerivedClass<object>();
        IBaseInterface<object> baseInterface1 = new DerivedClass<string>();

        #endregion

        #endregion

        #region Contravariance

        #region Delegate Types

        Action<A> action = a => { };

        Action<B> actionB = action;

        #endregion

        #region Generic Types

        IHardware<Bird> animalHardware = new Hardware<Bird>();
        //IHardware<Animal> hardware2 = new Hardware<Cat>(); // Contravariance 
        IHardware<Eagle> eagleHardware = new Hardware<Eagle>(); // Contravariance


        YHandler<Bird> birdHandler = GetBird;
        YHandler<Eagle> eagleHandler = GetEagle;

        birdHandler = (YHandler<Bird>)eagleHandler;

        void GetBird(Bird bird) { }
        void GetEagle(Eagle eagle) { }

        #endregion

        #endregion
    }
}




interface IBaseInterface<out T> { T GetValue(); }

class DerivedClass<T> : IBaseInterface<T> { public T GetValue() => default!; }

delegate T XHandler<out T>();

delegate void YHandler<in T>(T t);

interface ISoftware<out T> { }
class Software<T> : ISoftware<T> { }

interface IHardware<in T> { }
class Hardware<T> : IHardware<T> { }

class Bird { }
class Eagle : Bird { }

class Araba
{
    public virtual Araba GetAraba() => new();
}
class Mercedes : Araba
{
    public override Araba GetAraba() => new();
}

class Animal { }
class Cat : Animal { }
class A { }
class B : A { }