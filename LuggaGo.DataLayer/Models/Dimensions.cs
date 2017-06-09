namespace LuggaGo.DataLayer.Models
{
    public class Dimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public Dimensions()
        {

        }

        public Dimensions(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }
    }
}