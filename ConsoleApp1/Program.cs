using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

public class Sample
{
    public static void Main()
    {
        string path = @"d:\books.xml";


        try
        {
            TechcromeTransactionDetail detail = new TechcromeTransactionDetail() 
                                                    { 
                AdminStatus= "AdminStatus",
                SenderId= "SenderId",
                ClientStatus= "ClientStatus",
                MessageId= "MessageId" ,
                MobileNo= "MobileNo",
                SmppdeliveryDate= DateTime.Now,
                Smppid= 1,


            };

            if (!File.Exists(path))
            {
                using (XmlWriter writer = XmlWriter.Create(path))
                {

                    writer.WriteStartElement("SMSDLR");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }

            XDocument testXML = XDocument.Load(path);

            XElement newStudent = new XElement("DLR",
                                           new XElement("Smppid", detail.Smppid),
                                           new XElement("MobileNo", detail.MobileNo),
                                           new XElement("MessageId", detail.MessageId),
                                           new XElement("SenderId", detail.SenderId),
                                           new XElement("SmppdeliveryDate", detail.SmppdeliveryDate),
                                           new XElement("AdminStatus", detail.AdminStatus),
                                           new XElement("ClientStatus", detail.ClientStatus)
                                       );

            //var lastStudent = testXML.Descendants("SMSDLR").Last();

            //int newID = Convert.ToInt32(lastStudent.Attribute("ID").Value);
            newStudent.SetAttributeValue("ID", detail.MessageId);
            testXML.Element("SMSDLR").Add(newStudent);
            testXML.Save(path);
            testXML = null;
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }

    }
}

class TechcromeTransactionDetail
{

    public string MobileNo { get; set; }
    public string MessageId { get; set; }
    public long Smppid { get; set; }
    public string SenderId { get; set; }
    public DateTime? SmppdeliveryDate { get; set; }
    public string ClientStatus { get; set; }
    public string AdminStatus { get; set; }

}

