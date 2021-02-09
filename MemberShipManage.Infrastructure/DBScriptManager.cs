using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.XPath;

namespace MemberShipManage.Infrastructurer
{
    public static class DBScriptManager
    {
        public static string GetScript(Type remotingClassType, string key)
        {
            string xmlScriptPath = CustomSettings.AppSettings.DbScriptXmlPath;
            string xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlScriptPath);
            xmlFile = Path.Combine(xmlFile, remotingClassType.Name + ".xml");

            string xPathExpression = "/Scripts/Script[@Key='" + key.Trim() + "']/text()";
            return ExecuteXPath(xmlFile, xPathExpression);
        }

        public static string GetScript(string remotingClassFullName, string key)
        {
            string folder = CustomSettings.AppSettings.DbScriptXmlPath;
            folder = ParseFolder(folder);
            string xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
            xmlFile = Path.Combine(xmlFile, remotingClassFullName + ".xml");

            string xPathExpression = "/Scripts/Script[@Key='" + key.Trim() + "']/text()";
            return ExecuteXPath(xmlFile, xPathExpression);
        }

        private static string ExecuteXPath(string fileName, string xPathExpression)
        {
            XPathNavigator xpn;
            try
            {
                XPathDocument xpd = new XPathDocument(fileName);
                xpn = xpd.CreateNavigator();

                XPathExpression xpe = xpn.Compile(xPathExpression);
                if (xpe.ReturnType == XPathResultType.String)
                {
                    return xpn.Evaluate(xpe).ToString();
                }
                else if (xpe.ReturnType == XPathResultType.NodeSet)
                {
                    XPathNodeIterator xpi = xpn.Select(xpe);
                    if (xpi.Count == 1)
                    {
                        xpi.MoveNext();
                        return xpi.Current.Value;
                    }
                    else
                    {
                        throw new ApplicationException("Xml file format is not correct,Please check!");
                    }
                }
                else
                {
                    throw new ApplicationException("Xml file format is not correct,Please check!");
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (XPathException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private static string ParseFolder(string folder)
        {
            string newFolder = folder.TrimStart('/');
            if (!newFolder.EndsWith("/"))
            {
                newFolder = string.Concat(newFolder, "/");
            }

            return newFolder;
        }
    }
}
