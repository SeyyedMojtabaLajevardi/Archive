using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BLL.Enumerations
{
    public enum ConentTypeEnum
    {
        [Description:متن]
        Text,
        [Description:صوت]
        Sound,
        [Description:تصویر]
        Image,
        [Description:ویدئو]
        Video
    }
}
