using NasaApolo.Data;
using NasaApolo.Models.Entities;
using NasaApolo.Models.JsonObjects;

namespace NasaApolo.Models.Services;

public class PruebaService
{

    private NasaTestContext _db;

    public PruebaService () { }

    public PruebaService(NasaTestContext db)
    {
        _db = db;
    }


    /// <summary>
    /// Metodo para extraer la informacion requerida del Json Obtenido de la API
    /// </summary>
    /// <param name="jsonObjectResponse"></param>
    /// <returns></returns>
    public List<NasaImage> ConvertJsonObjectResponseToNasaImagenList(JsonObjectResponse jsonObjectResponse)
    {
        List<NasaImage> nasaImages = new List<NasaImage>();

        foreach (var item in jsonObjectResponse.collection.items)
        {
            foreach (var data in item.data)
            {
                NasaImage newNasaImage = new NasaImage();

                newNasaImage.Href = item.href;
                newNasaImage.Center = data.center;
                newNasaImage.Title = data.title;
                newNasaImage.NasaId = data.nasa_id;
                newNasaImage.Createdate = DateTime.Now;

                nasaImages.Add(newNasaImage);
            }

        }

        return nasaImages;
    }

    /// <summary>
    /// Metodo para almacenar a la base de datos la informacion de las imagenes
    /// </summary>
    public async Task SaveNasaImagenListAsync(List<NasaImage> nasaImages) 
    {
            try 
            {
                await _db.NasaImages.AddRangeAsync(nasaImages);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
    }

}