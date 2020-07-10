using System;
using System.IO;
using System.Xml;

public class Sample
{
    public static void Main()
    {

        TechcromeTransactionDetail detail = new TechcromeTransactionDetail()
        {
            AdminStatus = "AdminStatus",
            SenderId = "SenderId",
            ClientStatus = "ClientStatus",
            MessageId = "MessageId",
            MobileNo = "MobileNo",
            SmppdeliveryDate = DateTime.Now,
            Smppid = 1,


        };

        try
        {

            string path = @"d:\books.xml";

            if (!File.Exists(path))
            {
                using (XmlWriter writer = XmlWriter.Create(path))
                {

                    writer.WriteStartElement("SMSDLR");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }


            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();

            doc.Load(path);
            XmlNode parentNode = doc.SelectSingleNode("SMSDLR");
           
       
            //parentNode = doc.CreateElement("DLR");
            XmlElement DlrNode = doc.CreateElement("DLR");


            XmlElement MessageNode = doc.CreateElement("Smppid");
            MessageNode.InnerText =  detail.Smppid.ToString();
            DlrNode.AppendChild(MessageNode);


            XmlElement MessageNodeMobileNo = doc.CreateElement("MobileNo");
            MessageNodeMobileNo.InnerText = detail.MobileNo.ToString();
            DlrNode.AppendChild(MessageNodeMobileNo);



            XmlElement MessageNodeSenderId = doc.CreateElement("SenderId");
            MessageNodeSenderId.InnerText = detail.SenderId.ToString();
            DlrNode.AppendChild(MessageNodeSenderId);


            XmlElement MessageNodeClientStatus = doc.CreateElement("ClientStatus");
            MessageNodeClientStatus.InnerText = detail.ClientStatus.ToString();
            DlrNode.AppendChild(MessageNodeClientStatus);

            XmlElement MessageNodeAdminStatus = doc.CreateElement("AdminStatus");
            MessageNodeAdminStatus.InnerText = detail.AdminStatus.ToString();
            DlrNode.AppendChild(MessageNodeAdminStatus);


            XmlElement MessageNodeMessageId = doc.CreateElement("MessageId");
            MessageNodeMessageId.InnerText = detail.MessageId.ToString();
            DlrNode.AppendChild(MessageNodeMessageId);

            XmlElement MessageNodeSmppdeliveryDate = doc.CreateElement("SmppdeliveryDate");
            MessageNodeSmppdeliveryDate.InnerText = detail.SmppdeliveryDate.ToString();
            DlrNode.AppendChild(MessageNodeSmppdeliveryDate);


            parentNode.AppendChild(DlrNode);
            doc.Save(path);
            doc = null;

        }
        catch (Exception ex )
        {
            Console.WriteLine(ex);

            
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
