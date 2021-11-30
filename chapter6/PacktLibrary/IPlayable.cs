using static System.Console;

namespace Packt.Shared
{
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop() => WriteLine("Deafult implem for Stop()");
    }


    public class GenericThing<T> where T : IComparable
    {
        public T Data = default(T);
        public string Process(T input)
        {
            if (Data.CompareTo(input) == 0)
            {
                return "Data and input are the same.";
            }
            else
            {
                return "Data and input are NOT the same.";
            }
        }
    }


    public static class Squarer
    {
        public static double Square<T>(T input) where T : IConvertible
        {
            // convert using the current culture
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);
            return d * d;
        }

    }

    public struct DisplacementVector
    {
        public int X;
        public int Y;
        public DisplacementVector(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
        }
        public static DisplacementVector operator +(DisplacementVector vector1, DisplacementVector vector2)
        {
            return new DisplacementVector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }

    public class Animal : IDisposable
    {
        public string? Name = default;
        public Animal()
        {
            // allocate any unmanaged resources
        }
        ~Animal() // Finalizer aka destructor
        {
            WriteLine("Calling Destructor");
            // deallocate any unmanaged resources
            if (disposed) return;
            Dispose(false);
        }
        bool disposed = false; // have resources been released?
        public void Dispose()
        {
            WriteLine("Calling Dispose");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            // deallocate the *unmanaged* resource// ...
            if (disposing)
            {
                // deallocate any other *managed* resources
            }
            disposed = true;
        }

    }
}