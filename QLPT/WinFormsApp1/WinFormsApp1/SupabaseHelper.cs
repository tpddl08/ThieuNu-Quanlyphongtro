using Supabase;
using System;
using System.Threading.Tasks;
using System.Configuration; 

public static class SupabaseHelper
{
    private static readonly Lazy<Task<Client>> _lazyClient = new Lazy<Task<Client>>(async () =>
    {
        string url = ConfigurationManager.AppSettings["SupabaseUrl"]
            ?? throw new InvalidOperationException("SupabaseUrl not found in config");

        string key = ConfigurationManager.AppSettings["SupabaseAnonKey"]
            ?? throw new InvalidOperationException("SupabaseAnonKey not found in config");

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