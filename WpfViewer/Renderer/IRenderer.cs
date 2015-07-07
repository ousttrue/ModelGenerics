﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfViewer.Renderer
{
    public interface IRenderer
    {
        void Render(RenderFrame frame);
    }
}
