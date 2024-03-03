
using EMG_website.Models;

public class SupabaseService
{
    private Supabase.Client supabase;

    public SupabaseService(Supabase.Client supabase)
    {
        this.supabase = supabase;
    }

    public async Task<List<Voiture>> GetVoituresAsync()
    {
        var response = await supabase.From<Voiture>().Get();
        if (response.Models == null)
        {
            return new List<Voiture>();
        }

        return response.Models;
    }

    public async Task<Voiture> InsertVoitureAsync(Voiture voiture)
    {
        var response = await supabase
        .From<Voiture>()
        .Insert(voiture);

        Console.WriteLine(voiture);
        return response.Model;
    }

    public async Task<Voiture> UpdateVoitureAsync(Voiture voiture)
    {
        var response = await supabase
        .From<Voiture>()
        .Where (x => x.Id == voiture.Id)
        .Update(voiture);
        
        
        return response.Model;
    }

    public async Task<Voiture> DeleteVoitureAsync(Voiture voiture)
    {
        var response = await supabase
        .From<Voiture>()
        .Where (x => x.Id == voiture.Id)
        .Delete(voiture);
        return response.Model;
    }



    // Ajoutez d'autres méthodes pour INSERT, UPDATE, DELETE en suivant une approche similaire
}
