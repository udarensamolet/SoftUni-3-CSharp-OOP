using System;
using P02.Graphic_Editor.After.Contracts;

namespace P02.Graphic_Editor.After.Models
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}
