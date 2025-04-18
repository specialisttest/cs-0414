namespace CollectionsProjects
{
    class Test
    { 
        public string Data { get; init; }
        public Test(string data) => Data = data;
        public override string ToString() => Data;

        public override int GetHashCode() => Data.GetHashCode();
        public override bool Equals(object? obj)
        {
            if (obj is Test t) return this.Data == t.Data;
            return base.Equals(obj);
        }
    }
    internal class Program
    {
        static bool TestString(string s)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(' || c == '[')
                    st.Push(c);
                if (c == ')' && (st.Count == 0 || st.Pop() != '('))
                    return false;
                if (c == ']' && (st.Count == 0 || st.Pop() != '['))
                    return false;
            }
            return st.Count == 0;
        }
        static void Main(string[] args)
        {
            string s = " ( [ ] )  [ (  ) ] (( )) [[ ]]";
            Console.WriteLine(TestString(s));

            IDictionary<string, int> persons =
                new Dictionary<string, int>();

            persons.Add("Sergey", 37);
            persons.Add("Andrey", 40);
            persons["Sergey"]++;

            string name = "Sergey";
            if (persons.ContainsKey(name))
            {
                int age = persons[name];
                Console.WriteLine("{0} : {1}", name, age);
            }

            ISet<Test> set = new HashSet<Test>();
            set.Add(new Test("one"));
            set.Add(new Test("two"));
            set.Add(new Test("one"));

            Console.WriteLine(set.Count);
            foreach (var t in set)
                Console.WriteLine(t);
        }
    }
}
