using System.Security.Cryptography;
using Util;
class Program
{
    

    static void Main(string[] args)
    {
        bool[][] arr = new bool[8][];
        int[][] nums = new int[8][];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = new bool[8];
            nums[i] = new int[8];
            for (int j = 0; j < arr[i].Length; j++)
            {
                nums[i][j] = RandomNumberGenerator.GetInt32(0,3);
            }
        }
        arr[0][0] = true;
        
        Util.callMenu(arr,nums,0,0,3,0);
    }



}