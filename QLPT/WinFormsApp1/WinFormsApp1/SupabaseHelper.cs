using Supabase;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

public static class SupabaseHelper
{
    private static readonly Lazy<Task<Client>> _lazyClient = new Lazy<Task<Client>>(async () =>
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string url = config["Supabase:Url"]
            ?? throw new InvalidOperationException("Supabase Url not found in config");

        string key = config["Supabase:AnonKey"]
            ?? throw new InvalidOperationException("Supabase AnonKey not found in config");

        var options = new SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        var client = new Client(url, key, options);
        await client.InitializeAsync();

        return client;
    });

    public static Task<Client> GetClientAsync()
    {
        return _lazyClient.Value;
    }
}
