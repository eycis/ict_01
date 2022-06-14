namespace model
{
    /// <summary>
    /// výsledek frekvenční analýzy pro jeden zdroj (soubor, nebo url)
    /// </summary>
    public class FAResult
    {

        /// <summary>
        /// zdroj textu 
        /// </summary>
        public string Source { get; set; }

        public SourceType SourceType { get; set; }
        /// <summary>
        /// výsledná frekvenční analýza slov
        /// </summary>
        public Dictionary<string, int> Words { get; set; } = new Dictionary<string, int>();

<<<<<<< HEAD
        public Dictionary<string, int> GetTop10() 
            =>Words.OrderByDescending(kv => kv.Value)
            .Take(10).ToDictionary(kv => kv.Key, kv => kv.Value);

=======
        public Dictionary<string, int> GetTop10()=>(Dictionary<string,int>)Words.OrderByDescending(kv => kv.Value).Take(10);
>>>>>>> 48e661afbed4f5ec8cb9b9cc39a0a9ff8835a422

        public override string ToString()
        {
            return $"{Source} {Words?.Count}";
        }
    }
    public enum SourceType
    {
        URL, 
        FILE
    }

}