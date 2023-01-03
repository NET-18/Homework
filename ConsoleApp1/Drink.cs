using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Drink
    {
        public int IdDrink { set; get; }
        public string? StrDrink { set; get; }
        public string? StrDrinkAlternate { set; get; }
        public string? StrTags { set; get; }
        public string? StrVideo { set; get; }
        public string? StrCategory { set; get; }
        public string? StrIBA { set; get; }
        public string? StrAlcoholic { set; get; }
        public string? StrGlass { set; get; }
        public string? StrInstructions { set; get; }
        public string? StrInstructionsES { set; get; }
        public string? StrInstructionsDE { set; get; }
        public string? StrInstructionsIT { set; get; }
        [JsonProperty("strInstructionsZH-HANS")]
        public string? StrInstructionsZH_HANS { set; get; }
        [JsonProperty("strInstructionsZH-HANT")]
        public string? StrInstructionsZH_HANT { set; get; }
        public string? StrDrinkThumb { set; get; }
        public string? StrIngredient1 { set; get; }
        public string? StrIngredient2 { set; get; }
        public string? StrIngredient3 { set; get; }
        public string? StrIngredient4 { set; get; }
        public string? StrIngredient5 { set; get; }
        public string? StrIngredient6 { set; get; }
        public string? StrIngredient7 { set; get; }
        public string? StrIngredient8 { set; get; }
        public string? StrIngredient9 { set; get; }
        public string? StrIngredient10 { set; get; }
        public string? StrIngredient11 { set; get; }
        public string? StrIngredient12 { set; get; }
        public string? StrIngredient13 { set; get; }
        public string? StrIngredient14 { set; get; }
        public string? StrIngredient15 { set; get; }
        public string? StrMeasure1 { set; get; }
        public string? StrMeasure2 { set; get; }
        public string? StrMeasure3 { set; get; }
        public string? StrMeasure4 { set; get; }
        public string? StrMeasure5 { set; get; }
        public string? StrMeasure6 { set; get; }
        public string? StrMeasure7 { set; get; }
        public string? StrMeasure8 { set; get; }
        public string? StrMeasure9 { set; get; }
        public string? StrMeasure10 { set; get; }
        public string? StrMeasure11 { set; get; }
        public string? StrMeasure12 { set; get; }
        public string? StrMeasure13 { set; get; }
        public string? StrMeasure14 { set; get; }
        public string? StrMeasure15 { set; get; }
        public string? StrImageSource { set; get; }
        public string? StrImageAttribution { set; get; }
        public string? StrCreativeCommonsConfirmed { set; get; }
        public string? DateModified { set; get; }

        public Drink(int idDrink, string? strDrink, string? strDrinkAlternate, string? strTags, string? strVideo, string? strCategory, string? strIBA, string? strAlcoholic, string? strGlass, string? strInstructions, string? strInstructionsES, string? strInstructionsDE, string? strInstructionsIT, string? strInstructionsZH_HANS, string? strInstructionsZH_HANT, string? strDrinkThumb, string? strIngredient1, string? strIngredient2, string? strIngredient3, string? strIngredient4, string? strIngredient5, string? strIngredient6, string? strIngredient7, string? strIngredient8, string? strIngredient9, string? strIngredient10, string? strIngredient11, string? strIngredient12, string? strIngredient13, string? strIngredient14, string? strIngredient15, string? strMeasure1, string? strMeasure2, string? strMeasure3, string? strMeasure4, string? strMeasure5, string? strMeasure6, string? strMeasure7, string? strMeasure8, string? strMeasure9, string? strMeasure10, string? strMeasure11, string? strMeasure12, string? strMeasure13, string? strMeasure14, string? strMeasure15, string? strImageSource, string? strImageAttribution, string? strCreativeCommonsConfirmed, string dateModified)
        {
            IdDrink = idDrink;
            StrDrink = strDrink;
            StrDrinkAlternate = strDrinkAlternate;
            StrTags = strTags;
            StrVideo = strVideo;
            StrCategory = strCategory;
            StrIBA = strIBA;
            StrAlcoholic = strAlcoholic;
            StrGlass = strGlass;
            StrInstructions = strInstructions;
            StrInstructionsES = strInstructionsES;
            StrInstructionsDE = strInstructionsDE;
            StrInstructionsIT = strInstructionsIT;
            StrInstructionsZH_HANS = strInstructionsZH_HANS;
            StrInstructionsZH_HANT = strInstructionsZH_HANT;
            StrDrinkThumb = strDrinkThumb;
            StrIngredient1 = strIngredient1;
            StrIngredient2 = strIngredient2;
            StrIngredient3 = strIngredient3;
            StrIngredient4 = strIngredient4;
            StrIngredient5 = strIngredient5;
            StrIngredient6 = strIngredient6;
            StrIngredient7 = strIngredient7;
            StrIngredient8 = strIngredient8;
            StrIngredient9 = strIngredient9;
            StrIngredient10 = strIngredient10;
            StrIngredient11 = strIngredient11;
            StrIngredient12 = strIngredient12;
            StrIngredient13 = strIngredient13;
            StrIngredient14 = strIngredient14;
            StrIngredient15 = strIngredient15;
            StrMeasure1 = strMeasure1;
            StrMeasure2 = strMeasure2;
            StrMeasure3 = strMeasure3;
            StrMeasure4 = strMeasure4;
            StrMeasure5 = strMeasure5;
            StrMeasure6 = strMeasure6;
            StrMeasure7 = strMeasure7;
            StrMeasure8 = strMeasure8;
            StrMeasure9 = strMeasure9;
            StrMeasure10 = strMeasure10;
            StrMeasure11 = strMeasure11;
            StrMeasure12 = strMeasure12;
            StrMeasure13 = strMeasure13;
            StrMeasure14 = strMeasure14;
            StrMeasure15 = strMeasure15;
            StrImageSource = strImageSource;
            StrImageAttribution = strImageAttribution;
            StrCreativeCommonsConfirmed = strCreativeCommonsConfirmed;
            DateModified = dateModified;
        }
    }
}

