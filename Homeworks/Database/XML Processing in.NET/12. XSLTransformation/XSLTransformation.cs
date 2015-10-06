namespace XSLTransformation
{
    using System.Xml.Xsl;

    public class XSLTransformation
    {
        private static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xsl");
            xslt.Transform("../../../catalog.xml", "../../catalog.html");
        }
    }
}