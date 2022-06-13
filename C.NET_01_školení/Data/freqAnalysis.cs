﻿namespace Data
{
    public static class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string input)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var words = input.Replace(Environment.NewLine, " ")
                             .Replace("(", "")
                             .Replace(")", "")
                             .Replace(".", "")
                             .Replace(",", " ")
                             .Replace(":", " ")
                             .Split();

            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result.Add(word, 1);
                }
            }
            return result;
        }

        public static async Task<Dictionary<string, int>> FreqAnalysisFromUrl(string url)
        {
            //get content from url
            HttpClient httpClient = new HttpClient();
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