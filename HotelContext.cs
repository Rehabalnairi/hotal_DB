using hotal_DB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace hotal_DB.Data
{
    public static class FileHotelContext
    {
        private static string filePath = "hotelData.json";

        public static List<Guest> LoadGuests()
        {
            if (!File.Exists(filePath))
                return new List<Guest>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Guest>>(json) ?? new List<Guest>();
        }

        public static void SaveGuests(List<Guest> guests)
        {
            var json = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
