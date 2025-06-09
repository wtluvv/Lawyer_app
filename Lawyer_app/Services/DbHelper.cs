using Lawyer_app.Models;
using Supabase;

public class DbHelper
{
    private readonly Supabase.Client _supabase;

    public DbHelper()
    {
        var url = "https://wpbebvqcwmsuywkanppy.supabase.co";
        var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6IndwYmVidnFjd21zdXl3a2FucHB5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDk0OTEyMzgsImV4cCI6MjA2NTA2NzIzOH0.TFnsjXYMTJWwnwHC25t9L1m_SnHOHhEaMgdGn_JFHE8";

        _supabase = new Supabase.Client(url, key);
        _supabase.InitializeAsync().Wait(); // Инициализация
    }

    public async Task<List<LawyerTask>> GetTasks()
    {
        var response = await _supabase
            .From<LawyerTask>()
            .Get();

        return response.Models;
    }
}