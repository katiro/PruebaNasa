using NasaApolo.Data;
using NasaApolo.Models.Entities;
using NasaApolo.Models.JsonObjects;
using NasaApolo.Models.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NasaApolo.Client;

public class PruebaClient{

    

    private readonly string NasaUrl = "https://images-api.nasa.gov/search?q=apollo%2011";

    private PruebaService pruebaService = new PruebaService();

    /// <summary>
    /// Metodo para la obtencion de las imagenes en formato JSON desde la API
    /// </summary>
    /// <returns></returns>
    public async Task DownloadAndSaveNasaImages()
    {
        JsonObjectResponse jsonObjectResponse = new JsonObjectResponse();

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(NasaUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                jsonObjectResponse = JsonSerializer.Deserialize<JsonObjectResponse>(content);

            }
        }

        List<NasaImage> images = pruebaService.ConvertJsonObjectResponseToNasaImagenList(jsonObjectResponse);

        pruebaService.SaveNasaImagenListAsync(images);

    }

}

