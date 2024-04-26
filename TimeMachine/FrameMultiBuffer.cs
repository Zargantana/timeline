using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine
{
    public class FrameBuf
    {
        public string _buffer;
    }

    public class FrameMultiBuffer : MultiBuffer<FrameBuf>
    { }
}
