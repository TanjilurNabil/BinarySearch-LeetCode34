namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 7, 7, 7, 8 };
            int[] arr = new int[] { 1, 1, 2};
            int query = 1;
            Console.WriteLine(Find(arr, query));
            Console.WriteLine(FindLeft(arr, query));
            Console.WriteLine(FindRight(arr, query));
        }

        public delegate string Condition(int mid);
        public static int binary_search(int lo, int hi, Condition cond)
        {
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                string result = cond(mid);
                if (result == "found")
                {
                    return mid;
                }
                else if (result == "left")
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }

            }
            return -1;
        }

        public static int Find(int[]nums,int target)
        {
            Array.Sort(nums);
            int lo = 0,hi= nums.Length-1;
            string condLeft(int mid)
            {
                if (nums[mid] == target)
                {
                    if(mid>0 && nums[mid] - 1 == target)
                    {
                        return "left";
                    }
                    return "found";
                }
                else if (nums[mid]<target) {
                    return "right";
                }
                else
                { return "left"; }
            }
            return binary_search(lo, hi, condLeft);
        }
        public static int FindLeft(int[] nums, int target)
        {
            Array.Sort(nums);
            int lo = 0, hi = nums.Length - 1;
            string condLeft(int mid)
            {
                if (nums[mid] == target)
                {
                    if (mid-1 >= 0 && nums[mid-1] == target)
                    {
                        return "left";
                    }
                    return "found";
                }
                else if (nums[mid] > target)
                {
                    return "left";
                }
                else
                { return "right"; }
            }
            return binary_search(lo, hi, condLeft);
        }
        public static int FindRight(int[] nums, int target)
        {
            Array.Sort(nums);
            int lo = 0, hi = nums.Length - 1;
            string condLeft(int mid)
            {
                if (nums[mid] == target)
                {
                    if (mid+1 <nums.Length && nums[mid+1] == target)
                    {
                        return "right";
                    }
                    return "found";
                }
                else if (nums[mid] > target)
                {
                    return "left";
                }
                else
                { return "right"; }
            }
            return binary_search(lo, hi, condLeft);
        }
    }
}