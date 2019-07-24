using Solid.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Layouts
{
    public class XmlLayOut : ILayout
    {
        public string Format => "<log>\n"+
                                "   <date>{0}</date>\n"+
                                "   <level>{1}</level>\n"+
                                "   <message>{2}</message>\n"+
                                "</log>";
    }
}
