using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EditorUX.Business.Selection
{
    /// <summary>
    /// This is a basic selection query that can be used to drive autocomplete functionality from the first 50 pokemon
    /// </summary>
    [ServiceConfiguration(typeof(ISelectionQuery))]
    public class DemoSelectionQuery : ISelectionQuery
    {
        List<SelectItem> _items;
        public DemoSelectionQuery()
        {
            _items = GetItems().Result;
        }

        protected async virtual Task<List<SelectItem>> GetItems()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(15);
            HttpResponseMessage response = await client.GetAsync("pokemon/?limit=50").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return new List<SelectItem>();

            PokemonResultsList resultsList = response.Content.ReadAsAsync<PokemonResultsList>().Result;

            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            List<SelectItem> items = new List<SelectItem>();
            foreach (var result in resultsList.Results)
            {

                items.Add(new SelectItem { Text = ti.ToTitleCase(result.Name), Value = result.Name });
            }

            return items;
        }

        //Will be called when the editor types something in the selection editor.        
        public virtual IEnumerable<ISelectItem> GetItems(string query)
        {
            return _items.Where(i => i.Value.ToString().StartsWith(query, StringComparison.OrdinalIgnoreCase));
        }

        //Will be called when initializing an editor with an existing value to get the corresponding text representation.        
        public virtual ISelectItem GetItemByValue(string value)
        {
            ISelectItem current = _items.FirstOrDefault(i => i.Value.Equals(value));

            if (current != null)
                return current;

            return new SelectItem { Text = value, Value = value };
        }
    }

    public class PokemonResultsList
    {
        public int Count { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
        public IEnumerable<PokemonResult> Results { get; set; }
    }

    public class PokemonResult
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
