public class Lesson7
{
    public int I { get; set; }
    public string S { get; set; }
    public decimal D { get; set; }
    public char C { get; set; }

    public Lesson7() { }
    public Lesson7(int i) { this.I = i; }
    public Lesson7(int i, string s, decimal d, char c) { this.I = i; this.S = s; this.D = d; this.C = c; }


}