using DocumentFormat.OpenXml.Wordprocessing;
using GCScript.Database.MongoDB;
using GCScript.Database.MongoDB.DataAccess;
using GCScript.Database.MongoDB.Models;
using GCScript.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCScript.Client.Windows.Blazor.Pages;

public partial class Data
{   private string searchString1 = "";
    private string mudSelect_Companies_Text;
    private List<string> mudSelect_Companies_List = new();
    private Element selectedItem1 = null;
    private HashSet<Element> selectedItems = new HashSet<Element>();

    private IEnumerable<Element> Elements = new List<Element>();

    protected override async Task OnInitializedAsync()
    {
        SettingsDB.MongoDbUsername = "gcs5stars";
        SettingsDB.MongoDbPassword = "157131413";
        await LoadCompanies();
        //foreach (var comp in companies)
        //{
        //    cmb_Search.Properties.Items.Add(comp.Name);
        //}

        // Crie uma lista de elementos
        Elements = new List<Element>
        {
            new Element { Number = 1, Sign = "H", Name = "Hydrogen", Position = "1,1", Molar = "1.00794" },
            new Element { Number = 2, Sign = "He", Name = "Helium", Position = "18,1", Molar = "4.002602" },
            new Element { Number = 3, Sign = "Li", Name = "Lithium", Position = "1,2", Molar = "6.941" },
            new Element { Number = 4, Sign = "Be", Name = "Beryllium", Position = "2,2", Molar = "9.012182" },
            new Element { Number = 5, Sign = "B", Name = "Boron", Position = "13,2", Molar = "10.811" },
            new Element { Number = 6, Sign = "C", Name = "Carbon", Position = "14,2", Molar = "12.0107" },
            new Element { Number = 7, Sign = "N", Name = "Nitrogen", Position = "15,2", Molar = "14.0067" },
            new Element { Number = 8, Sign = "O", Name = "Oxygen", Position = "16,2", Molar = "15.9994" },
            new Element { Number = 9, Sign = "F", Name = "Fluorine", Position = "17,2", Molar = "18.9984032" },
            new Element { Number = 10, Sign = "Ne", Name = "Neon", Position = "18,2", Molar = "20.1797" },
            new Element { Number = 11, Sign = "Na", Name = "Sodium", Position = "1,3", Molar = "22.98976..." },
            new Element { Number = 12, Sign = "Mg", Name = "Magnesium", Position = "2,3", Molar = "24.305" },
            new Element { Number = 13, Sign = "Al", Name = "Aluminium", Position = "13,3", Molar = "26.9815386" },
        };
    }

    private async Task LoadCompanies()
    {
        CompanyDataAccess cda = new();
        var result = await cda.GetAllAsync();
        result = result.OrderBy(x => x.Name).ToList();
        mudSelect_Companies_List = result.Select(x => x.Name).ToList();
    }

    private async Task<List<MCompany>> LoadCompaniesAsync()
    {
        CompanyDataAccess cda = new();
        var companies = await cda.GetAllAsync();
        return [.. companies.OrderBy(x => x.Name)];
    }

    private bool FilterFunc1(Element element) => FilterFunc(element, searchString1);

    private bool FilterFunc(Element element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.Sign.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{element.Number} {element.Position} {element.Molar}".Contains(searchString))
            return true;
        return false;
    }

    private class Element
    {
        public int Number { get; set; }
        public string Sign { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Molar { get; set; }
    }
    private Task LoadCompanyData()
    {
        throw new NotImplementedException();
    }
}
