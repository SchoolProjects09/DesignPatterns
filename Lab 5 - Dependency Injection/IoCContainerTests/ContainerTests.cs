using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

//See also https://www.automatetheplanet.com/mstest-cheat-sheet/
namespace IoC.Tests
{
    /// <summary>
    /// Every test is going to need a container 
    /// </summary>
    public class ContainerTestBase
    {
        protected Container container;

        [TestInitialize]
        public void BeforeEach()
        {
            container = new Container();
        }

        [TestCleanup]
        public void AfterEach()
        {
            container = null;
        }
    }

    [TestClass()]
    public class ContainerInstantiationTests : ContainerTestBase
    {
        //Test name format:  UnitOfWork_InitialCondition_ExpectedResult
        //NOTE:  Uncomment a block of code with the shortcut Ctrl+K, U 
        //       Comment out a block of code with Ctrl+K, C

        [TestMethod]
        public void TestTest()
        {
            Assert.IsFalse(false);
        }

        [TestMethod()]
        public void GetInstance_ClassWithDefaultConstructor_ReturnsExpectedType()
        {
            var subject = (SomeClassA)(object)container.GetInstance(typeof(SomeClassA));

            subject.Should().BeOfType<SomeClassA>();
        }

        [TestMethod()]
        public void GetInstance_SupportsGeneric_ReturnsExpectedType()
        {
            SomeClassA subject = container.GetInstance<SomeClassA>();

            subject.Should().NotBeNull();
        }

        [TestMethod()]
        public void GetInstance_ForConstructorThatNeedsParams_ReturnsExpectedType()
        {
            AnotherClassB subject = container.GetInstance<AnotherClassB>();

            subject.A.Should().BeOfType<SomeClassA>();
        }

        [TestMethod()]
        public void GetInstance_ForClassWithNoArgsConstructor_ReturnsExpectedType()
        {
            var subject = container.GetInstance<ClassCNoParams>();

            subject.Invoked.Should().BeTrue();
        }

        class SomeClassA
        {

        }

        class AnotherClassB
        {
            public SomeClassA A { get; }

            public AnotherClassB(SomeClassA a)
            {
                A = a;
            }
        }

        class ClassCNoParams
        {
            public bool? Invoked { get; set; }

            public ClassCNoParams()
            {
                Invoked = true;
            }
        }
    }

    [TestClass()]
    public class ContainerRegisterTests : ContainerTestBase
    {
        [TestMethod()]
        public void GetInstance_WhenAskedForPet_ReturnsDog()
        {
            //Arrange
            container.Register(in_type: typeof(IPet), out_type: typeof(Dog));

            //Act
            IPet pet = container.GetInstance<IPet>();

            //Assert
            pet.Should().BeOfType<Dog>();
            pet.MakeSound();  // Woof!
        }


        [TestMethod()]
        public void GetInstanceGeneric_WhenAskedForPet_ReturnsCat()
        {
            container.Register<IPet, Cat>();

            IPet pet = container.GetInstance<IPet>();

            pet.Should().NotBeOfType<Dog>();

            pet.Should().BeOfType<Cat>();
            pet.MakeSound();  // Mreeow.
        }


        public interface IPet
        {
            void MakeSound();
        }

        public class Dog : IPet
        {
            public void MakeSound()
            {
                Console.WriteLine("Woof!");
            }
        }

        public class Cat : IPet
        {
            public void MakeSound()
            {
                Console.WriteLine("No."); //In remembrance of the late Grumpy Cat
            }
        }
    }

    [TestClass()]
    public class ContainerSingletonTests : ContainerTestBase
    {
        [TestMethod()]
        public void GetInstance_WhenAskedForSingleton_ReturnsSameInstance()
        {
            //Arrange
            Singleton s1 = new Singleton();
            container.RegisterSingleton(s1);

            //Act
            var s2 = container.GetInstance<Singleton>();

            //Assert
            s2.Should().BeOfType<Singleton>();
            s2.Should().Be(s1);
        }

        class Singleton
        {

        }
    }
}