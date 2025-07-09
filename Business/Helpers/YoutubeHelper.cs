using System.Text.RegularExpressions;

namespace ItlaTv.Core.Application.Helpers
{
    public class YoutubeHelper
    {
        public static string GetYouTubeEmbedUrl(string url)
        {
            string videoId = ExtractYouTubeVideoId(url);
            return $"https://www.youtube.com/embed/{videoId}";
        }

        private static string ExtractYouTubeVideoId(string url)
        {
            string videoId = string.Empty;

            // Patrones de expresión regular para los diferentes formatos de URL
            string pattern1 = @"(?:youtu\.be\/|youtube\.com\/(?:watch\?v=|embed\/|v\/|.+\?v=))([^&\n?#]+)";
            string pattern2 = @"(?:youtube\.com\/watch\?v=|&v=)([^&\n]+)";
            string pattern3 = @"(?:youtu\.be\/|youtube\.com\/v\/)([^&\n?#]+)";

            // Probar con el primer patrón
            Match match = Regex.Match(url, pattern1);
            if (match.Success)
            {
                videoId = match.Groups[1].Value;
            }
            else
            {
                // Probar con el segundo patrón
                match = Regex.Match(url, pattern2);
                if (match.Success)
                {
                    videoId = match.Groups[1].Value;
                }
                else
                {
                    // Probar con el tercer patrón
                    match = Regex.Match(url, pattern3);
                    if (match.Success)
                    {
                        videoId = match.Groups[1].Value;
                    }
                }
            }

            return videoId;
        }
    }
}
