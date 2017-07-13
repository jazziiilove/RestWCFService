/* 
 * Programmer: Baran Topal                       *
 * Solution name: RestWCFService                 * 
 * Project name: RestWCFService                  *
 * File name: RestWCFService.svc.cs              *
 *                                               *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */


using System;
using System.IO;
using System.Text;
using System.Xml;

namespace RestWCFService
{

    public class RestWCFServiceImpl : IRestWCFService
    {
        public string XMLData(string id)
        {
            return "You request product " + id;
        }

        public string JSONData(string id)
        {
            return "You request product " + id;
        }


        public string DoSomeWork(Stream data)
        {

            StreamReader reader = new StreamReader(data, Encoding.UTF8);

            string xmlString = reader.ReadToEnd();

            var xmlReader = XmlReader.Create(new StringReader(xmlString));

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            var test = string.Empty;


            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {

                xmlDoc.WriteTo(xmlTextWriter);
                var node = xmlDoc.SelectSingleNode("//root/someNode");
                if (node != null)
                {
                    node.InnerText = "baran";
                    test = node.InnerText;
                }
                xmlTextWriter.Flush();

                // test = stringWriter.GetStringBuilder().ToString();                               
            }

            Console.WriteLine("In");
            return test;
        }
    }
}
