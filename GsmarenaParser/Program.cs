using ExpertSystem.Model;
using ExpertSystem.Service;

Console.WriteLine("Введите выходную папку");
var outputFolder = Console.ReadLine();
var smartphones = new List<Smartphone>();
var fileIOService = new FileIOService(outputFolder + "\\Smartphones.json");

using (var sr = new StreamReader("Sources.txt"))
{
    string url;
    while ((url = sr.ReadLine()) != null)
    {
        try
        {
            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    using (var responseMessage = await client.GetAsync(url))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var html = await responseMessage.Content.ReadAsStringAsync();
                            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                            document.LoadHtml(html);

                            var imageUrl = document.DocumentNode.SelectSingleNode(".//div[@class='specs-photo-main']//img").Attributes["src"].Value;
                            var startNameIndex = imageUrl.LastIndexOf('/') + 1;

                            using (var s = await new HttpClient().GetStreamAsync(imageUrl))
                            {
                                using (var fs = new FileStream(outputFolder + "\\" + imageUrl[startNameIndex..], FileMode.Create))
                                {
                                    await s.CopyToAsync(fs);
                                }
                            }

                            //Console.WriteLine(string.Join(' ', document.DocumentNode.SelectSingleNode(".//h1[@class='specs-phone-name-title']").InnerHtml.Split(" ")[1..]));
                            //Console.WriteLine(document.DocumentNode.SelectSingleNode(".//h1[@class='specs-phone-name-title']").InnerHtml.Split(" ")[0]);
                            ////Console.WriteLine(string.Join(' ', document.DocumentNode.SelectSingleNode(".//td[@data-spec='price']//a").InnerHtml.Split(' ', '.', ';')[0..]));
                            //Console.WriteLine(document.DocumentNode.SelectSingleNode(".//a[@data-spec='nettech']").InnerHtml);
                            //Console.WriteLine(int.Parse(document.DocumentNode.SelectSingleNode(".//span[@data-spec='ramsize-hl']").InnerHtml[0].ToString()));
                            //Console.WriteLine(int.Parse(document.DocumentNode.SelectSingleNode(".//span[@data-spec='storage-hl']").InnerHtml.Split("GB")[0]));
                            //Console.WriteLine(document.DocumentNode.SelectSingleNode(".//td[@data-spec='os']").InnerHtml.Split(" ")[0]);
                            //Console.WriteLine(string.Concat(document.DocumentNode.SelectSingleNode(".//td[@data-spec='displayresolution']").InnerHtml.Split(" ")[0..3]));
                            //Console.WriteLine(double.Parse(document.DocumentNode.SelectSingleNode(".//td[@data-spec='displaysize']").InnerHtml.Split(" ")[0].Replace('.', ',')));
                            //Console.WriteLine(document.DocumentNode.SelectSingleNode(".//td[@data-spec='cam1modules']").InnerHtml.Split(" ")[0] != "No");
                            //Console.WriteLine(imageUrl[startNameIndex..]);

                            smartphones.Add(new Smartphone()
                            {
                                Name = string.Join(' ', document.DocumentNode.SelectSingleNode(".//h1[@class='specs-phone-name-title']").InnerHtml.Split(" ")[1..]),
                                Company = document.DocumentNode.SelectSingleNode(".//h1[@class='specs-phone-name-title']").InnerHtml.Split(" ")[0],
                                Price = 100,
                                Network = document.DocumentNode.SelectSingleNode(".//a[@data-spec='nettech']").InnerHtml,
                                RAM = int.Parse(document.DocumentNode.SelectSingleNode(".//span[@data-spec='ramsize-hl']").InnerHtml[0].ToString()),
                                Storage = int.Parse(document.DocumentNode.SelectSingleNode(".//span[@data-spec='storage-hl']").InnerHtml.Split("GB")[0]),
                                OS = document.DocumentNode.SelectSingleNode(".//td[@data-spec='os']").InnerHtml.Split(" ")[0],
                                Resolution = string.Concat(document.DocumentNode.SelectSingleNode(".//td[@data-spec='displayresolution']").InnerHtml.Split(" ")[0..3]),
                                Size = double.Parse(document.DocumentNode.SelectSingleNode(".//td[@data-spec='displaysize']").InnerHtml.Split(" ")[0].Replace('.', ',')),
                                IsCamera = document.DocumentNode.SelectSingleNode(".//td[@data-spec='cam1modules']").InnerHtml.Split(" ")[0] != "No",
                                Image = imageUrl[startNameIndex..],
                            });
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Произошла ошибка");
        }
    }
}

fileIOService.SaveDate(smartphones);