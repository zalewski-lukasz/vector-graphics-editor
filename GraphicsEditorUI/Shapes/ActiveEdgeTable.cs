using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditorUI.Shapes
{
    public class ActiveEdgeTable
    {
        Polygon CheckedPolygon { get; set; }
        public List<AETNode> Nodes { get; set; }
        public List<AETNode> SortedNodes { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        public ActiveEdgeTable(Polygon poly)
        {
            CheckedPolygon = poly;
            Nodes = new List<AETNode>();
            SortedNodes = new List<AETNode>();

            for (int i = 0; i < CheckedPolygon.Vertices.Count - 1; i++)
            {
                Nodes.Add(new AETNode(CheckedPolygon.Vertices[i].Y, CheckedPolygon.Vertices[i + 1].Y,
                                      CheckedPolygon.Vertices[i].X, CheckedPolygon.Vertices[i + 1].X));
            }

            SortedNodes = Nodes.Where(x => x.TestSlope() == false).
                                OrderBy(x => x.NodeMinY).
                                ThenBy(x => x.NodeMaxY).
                                ThenBy(x => x.ValX).ToList();

            MinY = SortedNodes.Min(x => x.NodeMinY);
            MaxY = SortedNodes.Max(x => x.NodeMaxY);
        }
    }

    public class AETNode
    {
        public int NodeMinY { get; set; }
        public int NodeMaxY { get; set; }

        public double ValX { get; set; }
        public double MaxX { get; set; }

        public int CoefficientSign { get; set; }
        public int HelperVariable { get; set; }

        public int dx { get; set; }
        public int dy { get; set; }

        public double TestInvOfM()
        {
            return ((MaxX - ValX) / (NodeMaxY - NodeMinY));
        }

        public bool TestSlope()
        {
            return NodeMaxY - NodeMinY == 0 ? true : false;
        }

        public AETNode(int y1, int y2, int x1, int x2)
        {
            HelperVariable = 0;

            if (y1 < y2)
            {
                NodeMinY = y1;
                NodeMaxY = y2;
                ValX = x1;
                MaxX = x2;
            }
            else if (y1 > y2)
            {
                NodeMinY = y2;
                NodeMaxY = y1;
                ValX = x2;
                MaxX = x1;
            }
            else
            {
                NodeMinY = NodeMaxY = y1;
                ValX = x1 <= x2 ? x1 : x2;
                MaxX = x1 <= x2 ? x2 : x1;
            }
            if (MaxX > ValX)
            {
                CoefficientSign = 1;
            }
            else
            {
                CoefficientSign = -1;
            }
            dx = Math.Abs(x1 - x2);
            dy = Math.Abs(y1 - y2);


        }
    }
}
