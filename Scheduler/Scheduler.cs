using NasaApolo.Client;
using System.Reflection;

namespace NasaApolo.Scheduler;

public class Scheduler : IHostedService, IDisposable
{
    private Timer _timer;
    private PruebaClient client = new PruebaClient();

    /// <summary>
    /// Metodo para iniciar el timer
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DownloadImages, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
        return Task.CompletedTask;
    }

    public void DownloadImages(Object state) 
    {
        client.DownloadAndSaveNasaImages();
    }

    /// <summary>
    /// Metodo para detener el timer
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}


