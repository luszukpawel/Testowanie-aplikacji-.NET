using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Games.Controllers
{
    public static class BubbleSort
    {
        public static String Sort(string str)
        {
            char temp;

            char[] arr = str.ToCharArray();
            for (int i = 0; i < 1; i++)
            {
                Random rnd = new Random();
                char[] MyRandomArray = arr.OrderBy(x => rnd.Next()).ToArray();

                arr = MyRandomArray;
                for (int write = 0; write < arr.Length; write++)
                {
                    for (int sort = 0; sort < arr.Length - 1; sort++)
                    {
                        if (arr[sort] > arr[sort + 1])
                        {
                            temp = arr[sort + 1];
                            arr[sort + 1] = arr[sort];
                            arr[sort] = temp;
                        }
                    }

                }
            }
            String ret = new string(arr);
            return ret;

        }

    
    }
}