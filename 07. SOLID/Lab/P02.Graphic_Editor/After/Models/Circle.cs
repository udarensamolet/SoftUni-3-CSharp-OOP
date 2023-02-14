using P02.Graphic_Editor.After.Contracts;

namespace P02.Graphic_Editor.After.Models
{
    public class Circle : IShape
    {
        public string Draw()
        {
            return $"I am a circle";
        }
    }
}
