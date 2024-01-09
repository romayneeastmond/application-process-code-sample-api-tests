<Query Kind="Program" />

public string StringatizeDemNums (params int[] v)
{
    string s = "";
    for(int i = 0; i < v.Length; i++)
    {
        string temp = String.Format("{0}", v[i]);
        s += temp;
        s += ", ";
    }
    return s;
}

void Main()
{
	int[] numbers = { 10, 20, 30, 40, 50 };
	
	StringatizeDemNums(numbers).Dump();	
}

// Define other methods and classes here
