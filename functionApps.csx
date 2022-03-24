#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];
    string pilihan = req.Query["pilihan"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;
    pilihan = pilihan ?? data?.pilihan;

    string responseMessage;
        if (string.IsNullOrEmpty(pilihan) || string.IsNullOrEmpty(name)){
            responseMessage = "Selamat datang di Hilangin.bg.\nApa kebutuhan anda?\n1.Mengganti/menghilangkan background foto.\n2. Mengganti atau menghilangkan background video.";
        } else {
            if(pilihan == "1" ) responseMessage = $"Halo, {name}.\nSilahkan upload foto kamu dilink berikut ...........";
            else if(pilihan == "2") responseMessage = $"Hai, {name}.\nSilahkan upload video kamu dilink berikut .......";
            else if(pilihan == "masukkanPilihan") responseMessage = "Selamat datang di Hilangin.bg.\nApa kebutuhan anda?\n1.Mengganti/menghilangkan background foto.\n2. Mengganti atau menghilangkan background video.";
            else responseMessage = "silahkan mengisi pilihan yang anda inginkan di website kami";
        }
            return new OkObjectResult(responseMessage);
}
