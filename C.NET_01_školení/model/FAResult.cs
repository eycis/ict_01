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


        public Dictionary<string, int> GetTop10() => Words.OrderByDescending(kv => kv.Value).Take(10).ToDictionary(x => x.Key, x => x.Value);


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