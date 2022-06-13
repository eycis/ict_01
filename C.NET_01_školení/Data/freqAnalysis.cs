namespace Data
{
    public static class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string input)
        {
            throw new NotImplementedException();
        }

        public static async Task<Dictionary<string, int>> FreqAnalysisFromUrl(string url)
        {
            //get content from url
            HttpClient httpClient = new ();
            var content = await httpClient.GetStringAsync(url);

            return FreqAnalysisFromString(content);
        }
        public static Dictionary<string, int> FreqAnalysisFromFile(string file)
        {
            //todo get content from file
            var content = File.ReadAllText(file);

            return FreqAnalysisFromString(content);
        }
    }
}