namespace Gowri.Gowri.Labs.CSharp
{
    public class ArrayPractice
    {   public void ArrPractice() {

            Console.WriteLine("---------------------------------------------");
            int[] arr = { 10, 50, 20, 40, 30 };
            int[] arr2 = new int[] { 2,3};

            Console.WriteLine("arra2 length " + arr2.Length);

            Console.WriteLine("arr Last Element " + arr[^1]);
            Console.WriteLine("arr second Last Element " + arr[^2]);

            int[] arra3 = new int[3];
            Array.Sort(arr);

            Console.WriteLine("Sorted array is");
            foreach (int val in arr)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("arr[2] " + arr[2]);
            Console.WriteLine("arr[4] " + arr[4]);

            Console.WriteLine("Reversed Array");
           
            Array.Reverse(arr);
            foreach (int val in arr)
            {
                Console.WriteLine(val);
            }


            //accesing element using index

            Console.WriteLine("IndexOF 30 " + Array.IndexOf(arr, 30));

            Console.WriteLine("Last IndexOF 10  " + Array.LastIndexOf(arr, 10));

            // Copy the array
            int[] destination = new int[5];

            Console.WriteLine("Copy the array");
            Array.Copy(arr, destination, 3);
            foreach (int val in destination)
            {
                Console.WriteLine(val);
            }
            // check the elmt in array  using EXISTS mehtods
            Console.WriteLine("If 10 is presnt? " + Array.Exists(arr, x => x == 10));

            Console.WriteLine("If 10 is presnt? " + Array.Find(arr, x => x == 10));

            int index = Array.BinarySearch(arr, 30);
            Console.WriteLine(index);

            Array.Clear(destination, 2, 2);
            foreach (int val in destination)
            {
                Console.WriteLine(val);
            }

        }

    }
}
