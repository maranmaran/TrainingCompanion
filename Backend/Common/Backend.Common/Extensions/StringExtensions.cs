namespace Backend.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes http://, https:// or www. from url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RemoveHttpFromUrl(this string url)
        {
            if (url.Contains("http://"))
                return url.Replace("http://", string.Empty);
            if (url.Contains("https://"))
                return url.Replace("https://", string.Empty);
            if (url.Contains("www."))
                return url.Replace("www.", string.Empty);

            return url;
        }
    }
}
