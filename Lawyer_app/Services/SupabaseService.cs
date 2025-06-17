using Lawyer_app.Models;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lawyer_app.Services
{
    public class SupabaseService
    {
        private readonly Client _supabaseClient; 

        public SupabaseService(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        // Дела
        public async Task<List<Case>> GetCases() =>
            (await _supabaseClient.From<Case>().Get()).Models;

        public async Task<List<Case>> SearchCases(string query) =>
            (await _supabaseClient.From<Case>()
                .Where(x => x.CaseNumber.Contains(query) ||
                          x.Description.Contains(query))
                .Get()).Models;

        public async Task AddCase(Case newCase) =>
            await _supabaseClient.From<Case>().Insert(newCase);

        // Клиенты
        public async Task<List<Client>> GetClients() =>
            (await _supabaseClient.From<Models.Client>().Get()).Models; // Явное указание Models.Client

        public async Task AddClient(Lawyer_app.Models.Client newClient) =>
            await _supabaseClient.From<Models.Client>().Insert(newClient); // Явное указание Models.Client

        // Документы
        public async Task<List<Document>> GetDocuments(int caseId) =>
            (await _supabaseClient.From<Models.Document>() // Явное указание Models.Document
                .Where(x => x.CaseId == caseId)
                .Get()).Models;

        public async Task UploadDocument(Document doc) =>
            await _supabaseClient.From<Models.Document>().Insert(doc); // Явное указание Models.Document
    }
}