//用来记录绘图过程为xml流
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace DrawSomething
{
    class TraceToXML
    {
        Point beginPoint;
        XmlDocument xmlDocument;
        XmlDeclaration xmlDeclare;
        XmlElement elementRoot;
        XmlElement elementSection;

        public TraceToXML(Point beginPoint, String penColor, String penWidth)
        {
            this.beginPoint = beginPoint;
            //创建 XML 对象
            xmlDocument = new XmlDocument();
            //声明 XML
            xmlDeclare = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            //创建根节点
            elementRoot = xmlDocument.CreateElement("Trace");
            xmlDocument.AppendChild(elementRoot);

            //创建第一个节点
            //创建节点 Section
            elementSection = xmlDocument.CreateElement("Section");
            elementSection.SetAttribute("penColor", penColor);
            elementSection.SetAttribute("penWidth", penWidth);
            elementRoot.AppendChild(elementSection);
            //创建 Section 的子节点 Point
            XmlElement elementPoint = xmlDocument.CreateElement("Point");
            elementPoint.SetAttribute("time", "0");
            elementPoint.InnerText = beginPoint.ToString();
            elementSection.AppendChild(elementPoint);
        }

        public void addNewSection(String penColor, String penWidth)
        {
            //创建节点 Section
            elementSection = xmlDocument.CreateElement("Section");
            elementSection.SetAttribute("penColor", penColor);
            elementSection.SetAttribute("penWidth", penWidth);
            elementRoot.AppendChild(elementSection);
        }

        public void add(Point tracePoint,String traceTime)
        {
            //创建 Section 的子节点 Point
            XmlElement elementPoint = xmlDocument.CreateElement("Point");
            elementPoint.SetAttribute("time", traceTime);
            elementPoint.InnerText = tracePoint.ToString();
            elementSection.AppendChild(elementPoint);
        }

        public void finish()
        {
            //保存xml
            xmlDocument.Save(System.Environment.CurrentDirectory.ToString()+"\\Trace.xml");
        }
    }
}
