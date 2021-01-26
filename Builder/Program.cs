using System;

namespace Builder
{
    //Builder design pattern falls under the category of "Creational" design patterns. This pattern is used to build a complex object by using a step by step approach.
    class Program
    {
        public enum ScreenType
        {
            ScreenType_TOUCH_CAPACITIVE,
            ScreenType_NON_TOUCH
        };

        public enum Battery
        {
            MAH_1500,
            MAH_2000
        };

        public enum OperatingSystem
        {
            ANDROID,
            WINDOWS_PHONE,
            SYMBIAN
        };

        public class Phone
        {
            public string Name { get; set; }

            public ScreenType Screen { get; set; }

            public Battery Battery { get; set; }

            public OperatingSystem OS { get; set; }

            public override string ToString()
            {
                return string.Format("Name: {0}\nScreen: {1}\nBattery {2}\nOS: {3}",
                    Name, Screen, Battery, OS);
            }
        }

        public interface IPhoneBuilder
        {
            void BuildScreen();
            void BuildBattery();
            void BuildOS();
            Phone Phone();
        }

        public class AndroidPhoneBuilder : IPhoneBuilder
        {
            readonly Phone phone = new Phone();

            public AndroidPhoneBuilder()
            {
                phone.Name = "Android Phone";
            }

            public void BuildScreen()
            {
                phone.Screen = ScreenType.ScreenType_TOUCH_CAPACITIVE;
            }

            public void BuildBattery()
            {
                phone.Battery = Battery.MAH_1500;
            }

            public void BuildOS()
            {
                phone.OS = OperatingSystem.ANDROID;
            }

            public Phone Phone()
            {
                return phone;
            }
        }

        class WindowsPhoneBuilder : IPhoneBuilder
        {
            readonly Phone phone = new Phone();

            public WindowsPhoneBuilder()
            {
                phone.Name = "Windows Phone";
            }

            public void BuildScreen()
            {
                phone.Screen = ScreenType.ScreenType_TOUCH_CAPACITIVE;
            }

            public void BuildBattery()
            {
                phone.Battery = Battery.MAH_2000;
            }

            public void BuildOS()
            {
                phone.OS = OperatingSystem.WINDOWS_PHONE;
            }

            public Phone Phone()
            {
                return phone;
            }
        }

        class Manufacturer
        {
            public void Construct(IPhoneBuilder phoneBuilder)
            {
                phoneBuilder.BuildBattery();
                phoneBuilder.BuildOS();
                phoneBuilder.BuildScreen();
            }
        }
        static void Main(string[] args)
        {
            Manufacturer newManufacturer = new Manufacturer();

            IPhoneBuilder phoneBuilder = new AndroidPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone().ToString());

            phoneBuilder = new WindowsPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone().ToString());
        }
    }
}
