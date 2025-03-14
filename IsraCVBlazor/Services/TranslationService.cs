using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class TranslationService
{
    private Dictionary<string, string> _translations = new();
    public string CurrentLanguage { get; private set; } = "sv";

    public event Action? OnLanguageChanged; // <-- Agregamos el evento

    public async Task LoadTranslations(string languageCode)
    {
        CurrentLanguage = languageCode;
        var filePath = Path.Combine("wwwroot", "Localization", $"{languageCode}.json");

        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            var wrapper = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);

            if (wrapper != null && wrapper.ContainsKey("translation"))
            {
                _translations = wrapper["translation"];
            }
            else
            {
                var translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (translations != null)
                {
                    _translations = translations;
                }
            }
        }

        OnLanguageChanged?.Invoke(); // <-- Notificamos a los componentes que el idioma cambió
    }

    public string T(string key)
    {
        return _translations.TryGetValue(key, out var value) ? value : key;
    }
}
