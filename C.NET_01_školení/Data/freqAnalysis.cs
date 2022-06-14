using model;

namespace Data
{
    public static class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string input)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            
            var words = input.Split(Environment.NewLine);

            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]+=1;
                }
                else
                {
                    result.Add(word, 1);
                }
            }
            return result;
        }

        public static async Task<FAResult> FreqAnalysisFromUrl(string url)
        {
            //get content from url
            HttpClient httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(url);
            var dict =  FreqAnalysisFromString(content);

            return new FAResult()
            {
                Source = url,
                SourceType = SourceType.URL,
                Words = dict
            };
        }
        public static FAResult FreqAnalysisFromFile(string file)
        {
            //get content from file
            var content = File.ReadAllText(file);
            var dict = FreqAnalysisFromString(content);

            return new FAResult()
            {
                Source = file,
                SourceType = SourceType.FILE,
                Words = dict
            };
        }
    }
}