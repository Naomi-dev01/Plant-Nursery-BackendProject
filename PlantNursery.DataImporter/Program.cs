namespace PlantNursery.DataImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using global::PlantNursery.DAL.Context;
    using global::PlantNursery.DAL.Entities;
   using static global::PlantNursery.DataImporter.JasonProduct;
   

    namespace PlantNursery.DataImporter
    {
        // Converter להמרת string ל-decimal
        public class StringToDecimalConverter : JsonConverter<decimal>
        {
            public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    string stringValue = reader.GetString();
                    if (decimal.TryParse(stringValue, out decimal value))
                    {
                        return value;
                    }
                    // אם לא ניתן להמיר, החזר 0
                    return 0;
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetDecimal();
                }

                return 0; // ערך ברירת מחדל
            }

            public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    // קריאת קובץ JSON
                    var json = File.ReadAllText("Data/dataBaseFlowers.json");

                    // הגדרת אפשרויות JSON עם הconverter
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new StringToDecimalConverter() }
                    };

                    // Deserialization עם האפשרויות החדשות
                    var root = JsonSerializer.Deserialize<Root>(json, options);

                    // הכנת רשימת כל המוצרים עם סוג הקטגוריה
                    var allJsonProducts = new List<(JsonProduct product, string categoryName)>();

                    void AddProducts(List<JsonProduct> list, string category)
                    {
                        if (list != null)
                        {
                            foreach (var item in list)
                                allJsonProducts.Add((item, category));
                        }
                    }

                    // הוספת כל המוצרים
                    AddProducts(root?.AllProducts?.Flowers, "flowers");
                    AddProducts(root?.AllProducts?.Trees, "trees");
                    AddProducts(root?.AllProducts?.MoreStuff, "moreStuff");
                    AddProducts(root?.AllProducts?.Bouquets, "bouquets");
                    AddProducts(root?.AllProducts?.GardenDesign, "gardenDesign");

                    // עבודה עם בסיס הנתונים
                    using var db = new PlantNurseryDbContext();

                    foreach (var (jsonProduct, categoryName) in allJsonProducts)
                    {
                        // חיפוש קטגוריה
                        var category = db.Categories.FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());
                        if (category == null)
                        {
                            Console.WriteLine($"⚠️ קטגוריה לא נמצאה: {categoryName}");
                            continue;
                        }

                        // יצירת מוצר חדש
                        var product = new Product
                        {
                            Id = Guid.NewGuid(),
                            Name = jsonProduct.Name,
                            Type = categoryName,
                            CategoryId = category.Id,
                            GrowingConditions = jsonProduct.GrowingConditions,
                            Color = jsonProduct.Colors,
                            Height = jsonProduct.Height,
                            Care = jsonProduct.Care,
                            MainUses = jsonProduct.MainUses,
                            SpecialFeatures = jsonProduct.SpecialFeatures,
                            Description = jsonProduct.Description,
                            Image = jsonProduct.Image,
                            Stock = jsonProduct.Stock,
                            Price = jsonProduct.Price // עכשיו זה יעבוד עם הconverter
                        };

                        db.Products.Add(product);
                    }

                    // שמירת השינויים
                    db.SaveChanges();
                    Console.WriteLine("✅ All products imported successfully.");
                }
                catch (JsonException jsonEx)
                {
                    Console.WriteLine($"❌ שגיאה בקריאת JSON: {jsonEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ שגיאה כללית: {ex.Message}");
                }
            }
        }
    }
}