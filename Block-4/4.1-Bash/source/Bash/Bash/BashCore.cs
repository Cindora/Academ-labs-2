namespace Bash
{
    class BashCore
    {
        public void Run()
        {
            string[] input_str;

            while (true)
            {
                Console.Write(": ");

                input_str = Console.ReadLine().Split();

                int input_length = input_str.Length;

                foreach(string el in input_str)
                {
                    Console.WriteLine(el);
                }
            }
        }


    }
}