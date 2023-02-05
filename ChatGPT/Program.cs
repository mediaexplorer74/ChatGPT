using System;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

async Task<Response> GetResponse(string text, string lang)
{
    using (var client = new HttpClient())
    {
        var queryString = $"text={text}&lang={lang}";
        var response = await client.GetAsync($"https://api.pawan.krd/chat/gpt?{queryString}");
        var responseData = await response.Content.ReadAsStringAsync();

        Response result = null;

        try
        {
            result = JsonConvert.DeserializeObject<Response>(responseData);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("[ex] Exception: " + ex.Message);
        }

        return result;
    }
}

Response response;

Console.WriteLine("********* CHATGPT Q&A ***********");
Console.WriteLine("REQUEST:");
Console.WriteLine("Explain quantum computing in simple terms, en");
//Console.WriteLine("Что лучше - капитализм или коммунизм?, ru");

Console.WriteLine("RESPONSE:");
response = await GetResponse("Explain quantum computing in simple terms", "en");
//response = await GetResponse("Что лучше - капитализм или коммунизм?", "ru");
if (response != null)
{
    //Console.WriteLine(response.State);
    Console.WriteLine(response.Reply);
    //Console.WriteLine(response.Markdown);
    //Console.WriteLine(response.Html);
}

Console.WriteLine("REQUEST:");
Console.WriteLine("продолжай, ru");

Console.WriteLine("RESPONSE:");
response = await GetResponse("продолжай", "ru");
if (response != null)
{
    //Console.WriteLine(response.State);
    Console.WriteLine(response.Reply);
    //Console.WriteLine(response.Markdown);
    //Console.WriteLine(response.Html);
}


Console.WriteLine("REQUEST:");
Console.WriteLine("continue, ru");

Console.WriteLine("RESPONSE:");
response = await GetResponse("continue", "ru");
if (response != null)
{
    //Console.WriteLine(response.State);
    Console.WriteLine(response.Reply);
    //Console.WriteLine(response.Markdown);
    //Console.WriteLine(response.Html);
}

