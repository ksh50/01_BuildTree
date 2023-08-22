using TreeOpr;

var parts = new List<Part>
{
    new Part { Name = "A", ParentName = null },
    new Part { Name = "B", ParentName = "A" },
    new Part { Name = "C", ParentName = "B" },
    new Part { Name = "D", ParentName = "A" },
};

var tree = ListOpr.BuildTree(parts);
ListOpr.PrintTree(tree);





namespace TreeOpr
{
    //  部品クラスの定義
    public class Part
    {
        public string? Name { get; set; } = "";
        public string? ParentName { get; set; } = "";
        public List<Part> Children { get; set; } = new List<Part>();
    }

    class ListOpr
    {
        // リストからツリー構造の作成
        public static List<Part> BuildTree(List<Part> parts)
        {
            var lookup = parts.ToLookup(part => part.ParentName);
            foreach (var part in parts)
            {
                part.Children.AddRange(lookup[part.Name]);
            }
            return lookup[null].ToList();
        }

        // ツリー構造の操作や表示
        public static void PrintTree(List<Part> tree, string indent = "")
        {
            foreach (var part in tree)
            {
                Console.WriteLine($"{indent}部品名: {part.Name}");
                PrintTree(part.Children, indent + "  ");
            }
        }
    }
}


