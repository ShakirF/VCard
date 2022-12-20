using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VCard_project;
using VCard_project.Models;

public class Proqram
    {
        public static void Main()
        {
        int input = Convert.ToInt32(Console.ReadLine());
        HttpClient httpClient = new HttpClient();
        var result = httpClient.GetStreamAsync($"https://randomuser.me/api?results={input}").Result;
        StreamReader streamReader = new StreamReader(result);
        var json = streamReader.ReadToEndAsync().Result;
        var deserializeObject = JsonConvert.DeserializeObject<Root>(json);

        var res = deserializeObject.results.ToList();
      
        foreach(var item in res)
        {
            VCard vCard = new VCard();
            vCard.FirstName = item.name.first;
            vCard.LastName = item.name.last;
            vCard.Id = item.id.value;
            vCard.Email = item.email;
            vCard.Phone = item.phone;
            vCard.Country = item.location.country;
            vCard.City = item.location.city;
            string vcardcontents = FileHelp.CreateVCard(vCard);
            string SavePath = System.IO.Path.Combine(AppContext.BaseDirectory, $"output_{item.id.value}.vcf");
            System.IO.File.WriteAllText(SavePath, vcardcontents);
            Console.WriteLine("File saved at " + SavePath.Trim());

        }
        
    }

}
