using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvexHullScanning
{
    public interface ISeaDrawable
    {
        void DrawShips(Graphics graphics);
    }
}
