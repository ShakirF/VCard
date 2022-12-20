using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCard_project.Models;


namespace VCard_project
{
    public static class FileHelp
    {
        const string NewLine = "\r\n";
        const string Separator = ";";
        const string Header = "BEGIN:VCARD\r\nVERSION:2.1";
        const string Name = "N:";
        const string FormattedName = "FN:";
        const string OrganizationName = "ORG:";
        const string TitlePrefix = "TITLE:";
        const string PhotoPrefix = "PHOTO;ENCODING=BASE64;JPEG:";
        const string PhonePrefix = "TEL;TYPE=";
        const string PhoneSubPrefix = ",VOICE:";
        const string AddressPrefix = "ADR;TYPE=";
        const string AddressSubPrefix = ":;;";
        const string EmailPrefix = "EMAIL:";
        const string Footer = "END:VCARD";

        public static string CreateVCard(VCard vCard)
        {
            StringBuilder fw = new StringBuilder();
            fw.Append(Header);
            fw.Append(NewLine);

            //Full Name
            if (!string.IsNullOrEmpty(vCard.FirstName) || !string.IsNullOrEmpty(vCard.LastName))
            {
                fw.Append(Name);
                fw.Append(vCard.LastName);
                fw.Append(Separator);
                fw.Append(vCard.FirstName);
                fw.Append(Separator);
                fw.Append(NewLine);
            }


            //Phone
            if (!string.IsNullOrEmpty(vCard.Phone))
                fw.Append(PhonePrefix);
            fw.Append(vCard.Phone);
            fw.Append(NewLine);



            //Email
            if (!string.IsNullOrEmpty(vCard.Email))
            {
                fw.Append(EmailPrefix);
                fw.Append(vCard.Email);
                fw.Append(NewLine);
            }

            //Adresses
            if (!string.IsNullOrEmpty(vCard.Country) || !string.IsNullOrEmpty(vCard.City))
                fw.Append(AddressPrefix);
            fw.Append(vCard.Country);
            fw.Append(AddressSubPrefix);
            fw.Append(vCard.City);
            fw.Append(NewLine);

            fw.Append(Footer);

            return fw.ToString();
        }
    }

}

