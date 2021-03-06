﻿using System.Web.Mail;
using System.Data;
using HRMS_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ErrorHandler;
using HRMS_Connection;


namespace HRMS_Class
{
    public class MailMasterManager
    {
        public static bool SendEmail(string pTo, string pSubject, string pBody)
        {

            string pGmailEmail = "contact.fhel@gmail.com";
            string pGmailPassword = "fhel@123";
            string smtpServer = "smtp.gmail.com";
            string smtpServerPort = "465";
            System.Web.Mail.MailFormat pFormat = System.Web.Mail.MailFormat.Html;
            string pAttachmentPath = string.Empty;


            System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", smtpServerPort);
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            //sendusing: cdoSendUsingPort, value 2, for sending the message using 
            //the network.

            //smtpauthenticate: Specifies the mechanism used when authenticating 
            //to an SMTP 
            //service over the network. Possible values are:
            //- cdoAnonymous, value 0. Do not authenticate.
            //- cdoBasic, value 1. Use basic clear-text authentication. 
            //When using this option you have to provide the user name and password 
            //through the sendusername and sendpassword fields.
            //- cdoNTLM, value 2. The current process security context is used to 
            // authenticate with the service.
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //Use 0 for anonymous
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", pGmailEmail);
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", pGmailPassword);
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            myMail.From = pGmailEmail;
            myMail.To = pTo;
            myMail.Subject = pSubject;
            myMail.BodyFormat = pFormat;
            myMail.Body = pBody;
            if (pAttachmentPath.Trim() != "")
            {
                MailAttachment MyAttachment =
                new MailAttachment(pAttachmentPath);
                myMail.Attachments.Add(MyAttachment);
                myMail.Priority = System.Web.Mail.MailPriority.High;
            }
            System.Web.Mail.SmtpMail.Send(myMail);

            return true;
        }
    }
}
