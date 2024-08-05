Console.WriteLine("Hello, World!");

int[] arr = new int[2];

for (int i = 0; i < arr.Length; i++)
{
    arr.SetValue(i, i);
}

int[,,,,] arr2 = new int[3, 5, 7, 9, 11];


int[] arr3 = (int[])Array.CreateInstance(typeof(int), 5);
int[,] arr4 = (int[,])Array.CreateInstance(typeof(int), 5, 4);
int[,,] arr5 = (int[,,])Array.CreateInstance(typeof(int), 5, 4, 7);

(int a, string b)[] arr6 = new (int a, string b)[]
{
    (0,"0"),
    (1,"1"),
    (2,"2")
};


(int b, string c, bool t)[] arr7 = new (int b, string c, bool t)[]
{
    (0,"0",false),
    (1,"1",true),
    (2,"2",false)
};

(int _a, string _c)[,] arr8 = new (int _a, string _c)[2, 2]
{
    {(0,"0"),(1,"1") },
    {(0,"0"),(1,"1") }
};